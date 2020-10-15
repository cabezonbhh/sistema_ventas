using Sistema_de_ventas.Business;
using Sistema_de_ventas.Control.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_ventas.GUI.Usuario_y_servicios
{
    public partial class frm_login : Form
    {
        private Control_iniciar_sesion control;
        public frm_login()
        {
            InitializeComponent();
            control = new Control_iniciar_sesion();
        }

        private void btn_iniciar_sesion_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(txt_nombre_usuario.Text) && !String.IsNullOrWhiteSpace(txt_contraseña.Text))
            {
                var usuario = control.iniciar_sesion(txt_nombre_usuario.Text, txt_contraseña.Text);
                if(usuario != null)
                {
                    Sesion.getSesion().cargarLogueado(usuario);
                    this.iniciar_main();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al iniciar sesion, verifique su usuario y contraseña e intente nuevamente","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void iniciar_main()
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Main_Test);
            if(frm == null || frm.IsDisposed == true)
            {
                frm = new Main_Test();
                frm.ShowDialog();
            }
            else
            {
                frm.BringToFront();
            }

        }    
    }
}
