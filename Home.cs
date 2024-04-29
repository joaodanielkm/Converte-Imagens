using System.Drawing.Imaging;
using System.Security;

namespace ConverteFotos
{
    public partial class Home : Form
    {
        private OpenFileDialog openFileDialog;
        private string _pastaOrigem = string.Empty;

        public Home()
        {
            InitializeComponent();
            SelecioneImagens();
        }

        private void SelecioneImagens()
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            Controls.Add(btnSelecioneImagens);
            Controls.Add(txtImagens);
        }

        private void BtnSelecioneImagens_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txtImagens.Clear();
                    System.Text.StringBuilder sb = new();
                    _pastaOrigem = Path.GetDirectoryName(openFileDialog.FileName);//todos da pasta
                    foreach (var imagem in openFileDialog.SafeFileNames)
                    {
                        sb.AppendLine(imagem);
                    }
                    txtImagens.Text = sb.ToString();
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show(@$"Erro ao selecionar imagem {ex.Message}
                    Detalhe:
                    {ex.StackTrace}");
                }
            }
        }

        private void ConverteFotos()
        {
            string pastaDestino = @$"{_pastaOrigem}\ImagensConvertidas";

            if (!Directory.Exists(pastaDestino))
            {
                Directory.CreateDirectory(pastaDestino);
            }

            string[] arquivos = openFileDialog.FileNames;

            foreach (string arquivo in arquivos)
            {
                if (EhImagem(arquivo))
                {
                    using Image imagemOriginal = Image.FromFile(arquivo);
                    int novaLargura = Convert.ToInt32(txtLargura.Text);
                    int novaAltura = Convert.ToInt32(txtAltura.Text);

                    bool ehParaManterProporcao = chkMantenhaProporcao.Checked;

                    if (ehParaManterProporcao)
                    {
                        novaAltura = (int)((double)imagemOriginal.Height / imagemOriginal.Width * novaLargura);
                    }

                    using Image novaImagem = new Bitmap(imagemOriginal, novaLargura, novaAltura);
                    EncoderParameters parametros = new(count: 1);

                    long qualidade = string.IsNullOrEmpty(txtQualidade.Text) ? 90L : Convert.ToInt32(txtQualidade.Text);

                    parametros.Param[0] = new EncoderParameter(Encoder.Quality, qualidade);
                    ImageCodecInfo? codecInfo = ObtenhaCodec(Path.GetExtension(arquivo));

                    if (codecInfo is not null)
                    {
                        novaImagem.Save(Path.Combine(pastaDestino, Path.GetFileName(arquivo)), codecInfo, parametros);
                    }
                }
            }
        }

        private static bool EhImagem(string arquivo)
        {
            try
            {
                using var bitmap = new Bitmap(arquivo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static ImageCodecInfo? ObtenhaCodec(string extension)
        {
            foreach (ImageCodecInfo? codec in from ImageCodecInfo codec in ImageCodecInfo.GetImageEncoders()
                                              where codec?.FilenameExtension is not null && codec.FilenameExtension.Contains(extension, StringComparison.CurrentCultureIgnoreCase)
                                              select codec)
            {
                return codec;
            }

            return null;
        }

        private void BtnConvertaFotos_Click(object sender, EventArgs e)
        {
            ConverteFotos();
        }

        private void BtnFechar_Click(object sender, EventArgs e) => Close();

        private void ChkMantenhaProporcao_CheckStateChanged(object sender, EventArgs e)
        {
            txtAltura.Enabled = !chkMantenhaProporcao.Checked;
            txtLargura.Enabled = !chkMantenhaProporcao.Checked;
        }

        private void btnLimpar_Click(object sender, EventArgs e) => txtImagens.Clear();
    }
}
