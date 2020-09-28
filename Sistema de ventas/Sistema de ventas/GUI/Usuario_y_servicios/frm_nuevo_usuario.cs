using Sistema_de_ventas.Others;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Sistema_de_ventas.GUI.Usuario_y_servicios
{
    public partial class frm_nuevo_usuario : Form
    {
        private Support support;
        public frm_nuevo_usuario()
        {
            InitializeComponent();
            support = Support.GetSupport();
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
                    
                //if (cbo_roles.SelectedIndex == -1)
                  //  return "Rol";     
                return null;
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if(this.validarCamposObligatorios()==null)
            {
                
            }
            else
            {
                MessageBox.Show(this.validarCamposObligatorios()+" . Complete los datos he intente nuevamente","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void txt_nombre_usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            support.soloLetras(sender,e);
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

    }
}
