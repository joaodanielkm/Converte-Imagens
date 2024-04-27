using System.Drawing.Imaging;
using System.Security;

namespace ConverteFotos
{
    public partial class Home : Form
    {
        private OpenFileDialog openFileDialog;

        public Home()
        {
            InitializeComponent();
            SelecioneImagens();
        }

        private void SelecioneImagens()
        {
            openFileDialog = new OpenFileDialog();
            Controls.Add(btnSelecioneImagens);
            Controls.Add(txtImagens);
        }

        private void ConverteFotos()
        {
            string pastaOrigem = @"C:\Users\User\Pictures\Screenshots";
            string pastaDestino = @"C:\Users\User\Pictures\Screenshots\Convertidas";

            if (!Directory.Exists(pastaDestino))
            {
                Directory.CreateDirectory(pastaDestino);
            }

            string[] arquivos = Directory.GetFiles(pastaOrigem);

            foreach (string arquivo in arquivos)
            {
                if (EhImagem(arquivo))
                {
                    using Image imagemOriginal = Image.FromFile(arquivo);
                    int novaLargura = 800;
                    int novaAltura = 1200;

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

        private void BtnSelecioneImagens_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(openFileDialog.FileName);
                    SetTextoImagens(sr.ReadToEnd());
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void SetTextoImagens(string textoImagens) => txtImagens.Text = textoImagens;

        private void BtnFechar_Click(object sender, EventArgs e) => Close();
    }
}
