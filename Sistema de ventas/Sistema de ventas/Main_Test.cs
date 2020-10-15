
using Sistema_de_ventas.Business;
using Sistema_de_ventas.Control.Usuarios;
using Sistema_de_ventas.Data.DataTransferObject;
using Sistema_de_ventas.GUI.Usuario_y_servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_ventas
{
    public partial class Main_Test : Form
    {
        Control_obtener_usuarios control;
        IList<DTO_Usuario> lista_usuarios;
        DTO_Usuario seleccionado;
        public Main_Test()
        {
            InitializeComponent();
            control = new Control_obtener_usuarios();
            lista_usuarios = control.getUsuarios();
            seleccionado = new DTO_Usuario();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if(dgv.CurrentRow !=null)
            {
                int id = Convert.ToInt32(dgv.CurrentRow.Cells["col_id"].Value.ToString());
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frm_nuevo_usuario);
                if (frm == null || frm.IsDisposed == true)
                {
                    frm = new frm_edit_usuario(id, this);
                    frm.ShowDialog();
                }
                else
                {
                    frm.BringToFront();
                }
            }
           else
            {
                MessageBox.Show("No ha seleccionado ningun usuario, seleccione uno.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frm_nuevo_usuario);
            if (frm == null || frm.IsDisposed == true)
            {
                frm = new frm_nuevo_usuario(this);
                frm.ShowDialog();
            }
            else
            {
                frm.BringToFront();
            }

        }

        private void Main_Test_Load(object sender, EventArgs e)
        {
            this.cargarGrilla();
            label1.Text = Sesion.getSesion().getNombreUsuarioLogueado();
        }

        private void actualizarListaUsuarios()
        {
            lista_usuarios = control.getUsuarios();
        }

        private void cargarGrilla()
        {
            dgv.Rows.Clear();           
            if(lista_usuarios != null && lista_usuarios.Count > 0)
            {
                lbl_no_data.Visible = false;
                foreach(DTO_Usuario dto in lista_usuarios)
                {
                    dgv.Rows.Add(new Object[]
                    {
                        dto.Idusuario.ToString(),
                        dto.Nombre_usuario,
                        dto.Password,
                        dto.Rol
                    });
                }
            }
            else
            {
                lbl_no_data.Visible = true;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
