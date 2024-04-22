namespace ConverteFotos
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            chkMantenhaProporcao = new CheckBox();
            btnConvertaFotos = new Button();
            txtQualidade = new TextBox();
            SuspendLayout();
            // 
            // chkMantenhaProporcao
            // 
            chkMantenhaProporcao.AutoSize = true;
            chkMantenhaProporcao.Location = new Point(295, 256);
            chkMantenhaProporcao.Name = "chkMantenhaProporcao";
            chkMantenhaProporcao.Size = new Size(122, 19);
            chkMantenhaProporcao.TabIndex = 0;
            chkMantenhaProporcao.Text = "Manter proporção";
            chkMantenhaProporcao.UseVisualStyleBackColor = true;
            // 
            // btnConvertaFotos
            // 
            btnConvertaFotos.Location = new Point(480, 253);
            btnConvertaFotos.Name = "btnConvertaFotos";
            btnConvertaFotos.Size = new Size(75, 23);
            btnConvertaFotos.TabIndex = 1;
            btnConvertaFotos.Text = "Converter";
            btnConvertaFotos.UseVisualStyleBackColor = true;
            btnConvertaFotos.Click += BtnConvertaFotos_Click;
            // 
            // txtQualidade
            // 
            txtQualidade.Location = new Point(366, 204);
            txtQualidade.Name = "txtQualidade";
            txtQualidade.Size = new Size(100, 23);
            txtQualidade.TabIndex = 2;
            txtQualidade.Text = "90";
            txtQualidade.TextAlign = HorizontalAlignment.Center;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtQualidade);
            Controls.Add(btnConvertaFotos);
            Controls.Add(chkMantenhaProporcao);
            Name = "Home";
            Text = "home";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox chkMantenhaProporcao;
        private Button btnConvertaFotos;
        private TextBox txtQualidade;
    }
}
