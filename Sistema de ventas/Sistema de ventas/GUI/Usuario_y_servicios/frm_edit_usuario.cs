using Sistema_de_ventas.Control.Usuarios;
using Sistema_de_ventas.Data.DataTransferObject;
using Sistema_de_ventas.Others;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_ventas.GUI.Usuario_y_servicios
{
    public partial class frm_edit_usuario : Form
    {
        private Form caller;
        private Control_Editar_Usuario control;
        private Support support;
        private DTO_Usuario seleccionado;//variable para almacenar el id de un usuario y asi poder 
                                                //reutilizar este form para ver/editar datos del mismo.
        public frm_edit_usuario(int id, Form caller)
        {
            InitializeComponent();
            control= new Control_Editar_Usuario();
            support = Support.GetSupport();
            this.seleccionado = control.usuarioPorID(id);
            this.caller = caller;
        }

        private void frm_edit_usuario_Load(object sender, EventArgs e)
        {
            this.llenarCampos();
        }
        private void llenarCampos()
        {
            this.limpiar_campos();
            txt_nombre_usuario.Text = seleccionado.Nombre_usuario;
            txt_nombre.Text = seleccionado.Nombre;
            txt_apellido.Text = seleccionado.Apellido;
            txt_legajo.Text = seleccionado.Legajo;
            txt_email.Text = seleccionado.Email;
            this.llenarComboRoles();
            if(seleccionado != null && control.tengoPermisoDeVer()==true)
            {
                txt_contraseña_usuario.Enabled = true;
                txt_contraseña_usuario.Text = control.getContraseñaDesencriptada();
                if(control.tengoPermiso()==true)
                {
                    cbo_roles.Enabled = true;
                }
            }
            else
            {
                txt_contraseña_usuario.Enabled = false;
                txt_contraseña_usuario.Text = seleccionado.Password;
            }
        }
        private void llenarComboRoles()
        {
            cbo_roles.DataSource = control.obtener_roles();
            cbo_roles.DisplayMember = "Nombre"; //nombre del campo que lista el combo, por ejemplo "Nombre"
            cbo_roles.ValueMember = "IdRol"; // nombre del campo Id que se guarda en cada ítems de la lista, ejemplo idRol
            cbo_roles.SelectedIndex = seleccionado.IdRol-1; // para que el combo no aparezca con algo seleccionado
        }

        private string validarCamposObligatorios()  // metodo para validar que ingreso nombre y apellido, ya que ambos son obligatorios. 
                                                    //Si alguno esta vacio retorna un string indicando el campo que falta
        {
            {
                if (String.IsNullOrWhiteSpace(txt_nombre_usuario.Text))
                {
                    txt_nombre_usuario.Focus();
                    txt_nombre_usuario.SelectAll();
                    return "Ha dejado vacio el campo Nombre de usuario";
                }
                if (String.IsNullOrWhiteSpace(txt_contraseña_usuario.Text))
                {
                    txt_contraseña_usuario.Focus();
                    txt_contraseña_usuario.SelectAll();
                    return "Ha dejado vacio el campo Contraseña";
                }
                if (this.validarFormatoMail() == false)
                {
                    txt_email.Focus();
                    txt_email.SelectAll();
                    return "El mail ingresado no tiene el formato correcto. Por favor ingrese un mail con el formato 'nombreElegido'@'dominio', "
                            + "Ejemplo: usuario@gmail.com";
                }
                if (this.validarFormatoContraseña() == true)
                {
                    txt_contraseña_usuario.Focus();
                    txt_contraseña_usuario.SelectAll();
                    return "No se permiten espacios en la contraseña";
                }

                return null;
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {

        }

        private void txt_nombre_usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            support.soloLetras(sender, e);
        }

        private void txt_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            support.soloLetrasSiEspacio(sender, e);
        }

        private void txt_apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            support.soloLetrasSiEspacio(sender, e);
        }

        private void txt_legajo_KeyPress(object sender, KeyPressEventArgs e)
        {
            support.noEspacios(sender, e);
        }
        private bool validarFormatoMail()
        {
            string cadena = txt_email.Text;
            return Regex.IsMatch(cadena, "^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$");
        }
        private bool validarFormatoContraseña()
        {
            string cadena = txt_contraseña_usuario.Text;
            return Regex.IsMatch(cadena, "\\s+");
        }

        private DTO_Usuario crearDTO(bool permiso)
        {
            DTO_Usuario dto = new DTO_Usuario();
            dto.Nombre_usuario = txt_nombre_usuario.Text;
            dto.Nombre = txt_nombre.Text;
            dto.Apellido = txt_apellido.Text;
            dto.Legajo = txt_legajo.Text;
            dto.Email = txt_email.Text;
            dto.IdRol = Convert.ToInt32(cbo_roles.SelectedValue.ToString());
            if(permiso == true)
            {
                dto.Password = txt_contraseña_usuario.Text;
            }
            else
            {
                dto.Password = seleccionado.Password;
            }
            return dto;
        }
        private void limpiar_campos()
        {
            txt_nombre.Clear();
            txt_apellido.Clear();
            txt_nombre_usuario.Clear();
            txt_contraseña_usuario.Clear();
            txt_email.Clear();
            txt_legajo.Clear();
            cbo_roles.SelectedIndex = -1;
        }

    }
}
