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
            label1 = new Label();
            btnSelecioneImagens = new Button();
            txtImagens = new TextBox();
            btnFechar = new Button();
            SuspendLayout();
            // 
            // chkMantenhaProporcao
            // 
            chkMantenhaProporcao.AutoSize = true;
            chkMantenhaProporcao.Location = new Point(335, 272);
            chkMantenhaProporcao.Name = "chkMantenhaProporcao";
            chkMantenhaProporcao.Size = new Size(122, 19);
            chkMantenhaProporcao.TabIndex = 0;
            chkMantenhaProporcao.Text = "Manter proporção";
            chkMantenhaProporcao.UseVisualStyleBackColor = true;
            // 
            // btnConvertaFotos
            // 
            btnConvertaFotos.Location = new Point(332, 307);
            btnConvertaFotos.Name = "btnConvertaFotos";
            btnConvertaFotos.Size = new Size(121, 36);
            btnConvertaFotos.TabIndex = 1;
            btnConvertaFotos.Text = "Converter";
            btnConvertaFotos.UseVisualStyleBackColor = true;
            btnConvertaFotos.Click += BtnConvertaFotos_Click;
            // 
            // txtQualidade
            // 
            txtQualidade.Location = new Point(335, 233);
            txtQualidade.Name = "txtQualidade";
            txtQualidade.Size = new Size(51, 23);
            txtQualidade.TabIndex = 2;
            txtQualidade.Text = "90";
            txtQualidade.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(392, 236);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 3;
            label1.Text = "Qualidade";
            // 
            // btnSelecioneImagens
            // 
            btnSelecioneImagens.Location = new Point(332, 12);
            btnSelecioneImagens.Name = "btnSelecioneImagens";
            btnSelecioneImagens.Size = new Size(121, 36);
            btnSelecioneImagens.TabIndex = 5;
            btnSelecioneImagens.Text = "Selecione";
            btnSelecioneImagens.UseVisualStyleBackColor = true;
            btnSelecioneImagens.Click += BtnSelecioneImagens_Click;
            // 
            // txtImagens
            // 
            txtImagens.Location = new Point(12, 12);
            txtImagens.Multiline = true;
            txtImagens.Name = "txtImagens";
            txtImagens.ScrollBars = ScrollBars.Vertical;
            txtImagens.Size = new Size(314, 331);
            txtImagens.TabIndex = 6;
            // 
            // btnFechar
            // 
            btnFechar.Location = new Point(332, 54);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(121, 36);
            btnFechar.TabIndex = 7;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += BtnFechar_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(463, 364);
            ControlBox = false;
            Controls.Add(btnFechar);
            Controls.Add(txtImagens);
            Controls.Add(btnSelecioneImagens);
            Controls.Add(label1);
            Controls.Add(txtQualidade);
            Controls.Add(btnConvertaFotos);
            Controls.Add(chkMantenhaProporcao);
            Name = "Home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "home";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox chkMantenhaProporcao;
        private Button btnConvertaFotos;
        private TextBox txtQualidade;
        private Label label1;
        private Button btnSelecioneImagens;
        private TextBox txtImagens;
        private Button btnFechar;
    }
}
