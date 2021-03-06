﻿using Sistema_de_ventas.Others;
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
using Sistema_de_ventas.Control;
using Sistema_de_ventas.Control.Usuarios;
using Sistema_de_ventas.Data.DataTransferObject;
using Sistema_de_ventas.Business.Usuarios;

namespace Sistema_de_ventas.GUI.Usuario_y_servicios
{
    public partial class frm_nuevo_usuario : Form
    {
        private Form caller;
        private Control_nuevo_usuario control;
        private Support support;

        public frm_nuevo_usuario(Form caller)
        {
            InitializeComponent();
            control = new Control_nuevo_usuario();
            support = Support.GetSupport();
            this.caller = caller;
            this.llenarComboRoles();
        }

        private void llenarComboRoles()
        {
            cbo_roles.DataSource = control.obtener_roles();
            cbo_roles.DisplayMember = "Nombre"; //nombre del campo que lista el combo, por ejemplo "Nombre"
            cbo_roles.ValueMember = "IdRol"; // nombre del campo Id que se guarda en cada ítems de la lista, ejemplo idRol
            cbo_roles.SelectedIndex = -1; // para que el combo no aparezca con algo seleccionado
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
            bool resultado;
            if(this.validarCamposObligatorios()==null)
            {
                DialogResult respuesta = MessageBox.Show("¿Desea guardar este usuario?","Nuevo usuario",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(respuesta == DialogResult.Yes)
                {
                    resultado = control.registrar_nuevo_usuario(this.crearDTO());
                    if(resultado == true)
                    {
                        MessageBox.Show("Usuario registrado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.limpiar_campos();
                    }
                    else
                    {                       
                        MessageBox.Show("Fallo al registrar el usuario, revise los datos ingresados y intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;

                    }
                }                     
                else
                {
                    MessageBox.Show("Registro cancelado", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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

        private DTO_Usuario crearDTO()
        {
            DTO_Usuario dto = new DTO_Usuario();
            dto.Nombre_usuario = txt_nombre_usuario.Text;
            dto.Password = txt_contraseña_usuario.Text;
            dto.Nombre = txt_nombre.Text;
            dto.Apellido = txt_apellido.Text;
            dto.Legajo = txt_legajo.Text;
            dto.Email = txt_email.Text;
            dto.IdRol = Convert.ToInt32(cbo_roles.SelectedValue.ToString());
            return dto;
        }

        private void frm_nuevo_usuario_Load(object sender, EventArgs e)
        {
            this.llenarComboRoles();
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
