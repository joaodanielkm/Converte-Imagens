namespace ConverteFotos
{
    partial class Converter
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
            txtAltura = new TextBox();
            txtLargura = new TextBox();
            label2 = new Label();
            label3 = new Label();
            btnLimpar = new Button();
            lbTamanhoTotal = new Label();
            prossBar = new ProgressBar();
            SuspendLayout();
            // 
            // chkMantenhaProporcao
            // 
            chkMantenhaProporcao.AutoSize = true;
            chkMantenhaProporcao.Checked = true;
            chkMantenhaProporcao.CheckState = CheckState.Checked;
            chkMantenhaProporcao.Location = new Point(335, 56);
            chkMantenhaProporcao.Name = "chkMantenhaProporcao";
            chkMantenhaProporcao.Size = new Size(122, 19);
            chkMantenhaProporcao.TabIndex = 1;
            chkMantenhaProporcao.Text = "Manter proporção";
            chkMantenhaProporcao.UseVisualStyleBackColor = true;
            chkMantenhaProporcao.CheckStateChanged += ChkMantenhaProporcao_CheckStateChanged;
            // 
            // btnConvertaFotos
            // 
            btnConvertaFotos.BackColor = Color.FromArgb(192, 255, 192);
            btnConvertaFotos.Location = new Point(335, 180);
            btnConvertaFotos.Name = "btnConvertaFotos";
            btnConvertaFotos.Size = new Size(127, 36);
            btnConvertaFotos.TabIndex = 5;
            btnConvertaFotos.Text = "Converter";
            btnConvertaFotos.UseVisualStyleBackColor = false;
            btnConvertaFotos.Click += BtnConvertaFotos_Click;
            // 
            // txtQualidade
            // 
            txtQualidade.Location = new Point(411, 151);
            txtQualidade.Name = "txtQualidade";
            txtQualidade.Size = new Size(51, 23);
            txtQualidade.TabIndex = 4;
            txtQualidade.Text = "90";
            txtQualidade.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(332, 154);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 3;
            label1.Text = "Qualidade %";
            // 
            // btnSelecioneImagens
            // 
            btnSelecioneImagens.Location = new Point(332, 12);
            btnSelecioneImagens.Name = "btnSelecioneImagens";
            btnSelecioneImagens.Size = new Size(130, 36);
            btnSelecioneImagens.TabIndex = 0;
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
            btnFechar.BackColor = Color.LightCoral;
            btnFechar.Location = new Point(335, 307);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(125, 36);
            btnFechar.TabIndex = 7;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = false;
            btnFechar.Click += BtnFechar_Click;
            // 
            // txtAltura
            // 
            txtAltura.Enabled = false;
            txtAltura.Location = new Point(411, 81);
            txtAltura.Name = "txtAltura";
            txtAltura.Size = new Size(51, 23);
            txtAltura.TabIndex = 2;
            txtAltura.Text = "1200";
            txtAltura.TextAlign = HorizontalAlignment.Center;
            // 
            // txtLargura
            // 
            txtLargura.Enabled = false;
            txtLargura.Location = new Point(411, 113);
            txtLargura.Name = "txtLargura";
            txtLargura.Size = new Size(51, 23);
            txtLargura.TabIndex = 3;
            txtLargura.Text = "800";
            txtLargura.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(333, 87);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 10;
            label2.Text = "Altura";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(332, 116);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 11;
            label3.Text = "Largura";
            // 
            // btnLimpar
            // 
            btnLimpar.BackColor = Color.FromArgb(255, 255, 192);
            btnLimpar.Location = new Point(335, 265);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(125, 36);
            btnLimpar.TabIndex = 6;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = false;
            btnLimpar.Click += BtnLimpar_Click;
            // 
            // lbTamanhoTotal
            // 
            lbTamanhoTotal.AutoSize = true;
            lbTamanhoTotal.Location = new Point(12, 382);
            lbTamanhoTotal.Name = "lbTamanhoTotal";
            lbTamanhoTotal.Size = new Size(0, 15);
            lbTamanhoTotal.TabIndex = 14;
            // 
            // prossBar
            // 
            prossBar.Location = new Point(10, 349);
            prossBar.Name = "prossBar";
            prossBar.Size = new Size(447, 23);
            prossBar.TabIndex = 15;
            // 
            // Converter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(472, 416);
            ControlBox = false;
            Controls.Add(prossBar);
            Controls.Add(lbTamanhoTotal);
            Controls.Add(btnLimpar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtLargura);
            Controls.Add(txtAltura);
            Controls.Add(btnFechar);
            Controls.Add(txtImagens);
            Controls.Add(btnSelecioneImagens);
            Controls.Add(label1);
            Controls.Add(txtQualidade);
            Controls.Add(btnConvertaFotos);
            Controls.Add(chkMantenhaProporcao);
            Name = "Converter";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Converte Imagens";
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
        private TextBox txtAltura;
        private TextBox txtLargura;
        private Label label2;
        private Label label3;
        private Button btnLimpar;
        private Label label4;
        private Label lbTamanhoTotal;
        private ProgressBar prossBar;
    }
}
