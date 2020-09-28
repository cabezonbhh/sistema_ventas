namespace Sistema_de_ventas
{
    partial class manual_connection
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_info = new System.Windows.Forms.Label();
            this.lbl_description = new System.Windows.Forms.Label();
            this.txt_encrypt = new System.Windows.Forms.TextBox();
            this.btn_encrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_info.Location = new System.Drawing.Point(14, 32);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(271, 24);
            this.lbl_info.TabIndex = 0;
            this.lbl_info.Text = "Ingrese la cadena de conexion";
            // 
            // lbl_description
            // 
            this.lbl_description.AutoSize = true;
            this.lbl_description.Location = new System.Drawing.Point(15, 66);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Size = new System.Drawing.Size(721, 13);
            this.lbl_description.TabIndex = 1;
            this.lbl_description.Text = "Esto permite crear un archivo, cuyo contenido, sera la cadena de conexion encript" +
    "ada. De esta forma tu conexion es mas segura ante posibles ataques";
            // 
            // txt_encrypt
            // 
            this.txt_encrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_encrypt.Location = new System.Drawing.Point(18, 115);
            this.txt_encrypt.Name = "txt_encrypt";
            this.txt_encrypt.Size = new System.Drawing.Size(718, 29);
            this.txt_encrypt.TabIndex = 2;
            // 
            // btn_encrypt
            // 
            this.btn_encrypt.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_encrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_encrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_encrypt.Location = new System.Drawing.Point(265, 162);
            this.btn_encrypt.Name = "btn_encrypt";
            this.btn_encrypt.Size = new System.Drawing.Size(193, 46);
            this.btn_encrypt.TabIndex = 3;
            this.btn_encrypt.Text = "Generar";
            this.btn_encrypt.UseVisualStyleBackColor = false;
            // 
            // manual_connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 233);
            this.Controls.Add(this.btn_encrypt);
            this.Controls.Add(this.txt_encrypt);
            this.Controls.Add(this.lbl_description);
            this.Controls.Add(this.lbl_info);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "manual_connection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conexion Manual";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.Label lbl_description;
        private System.Windows.Forms.TextBox txt_encrypt;
        private System.Windows.Forms.Button btn_encrypt;
    }
}

