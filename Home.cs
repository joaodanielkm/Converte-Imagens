using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Security;

namespace ConverteFotos
{
    public partial class Home : Form
    {
        private readonly OpenFileDialog? _openFileDialog;

        public Home()
        {
            InitializeComponent();
            _openFileDialog = new OpenFileDialog
            {
                Multiselect = true
            };
        }

        private void BtnSelecioneImagens_Click(object sender, EventArgs e)
        {
            if (_openFileDialog?.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txtImagens.Clear();
                    System.Text.StringBuilder sb = new();

                    foreach (var imagem in _openFileDialog.SafeFileNames)
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

        private void ConvertaImagens()
        {
            string? pastaOrigem = Path.GetDirectoryName(_openFileDialog?.FileName);
            string pastaDestino = @$"{pastaOrigem}\Imagens Convertidas";

            if (!Directory.Exists(pastaDestino))
            {
                Directory.CreateDirectory(pastaDestino);
            }

            string[] arquivos = [];

            if (_openFileDialog is not null)
            {
                arquivos = _openFileDialog.FileNames;
            }

            foreach (string arquivo in arquivos)
            {
                if (EhImagem(arquivo))
                {
                    using Image? imagemOriginal = Image.FromFile(arquivo);
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
            MessageBox.Show("Imagens convertidas!");
            LimpeCampos();
            Process.Start("explorer.exe", pastaDestino);
        }

        private void LimpeCampos()
        {
            txtImagens.Clear();
            chkMantenhaProporcao.Checked = true;
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

        private void BtnConvertaFotos_Click(object sender, EventArgs e) => ConvertaImagens();

        private void BtnFechar_Click(object sender, EventArgs e) => Close();

        private void ChkMantenhaProporcao_CheckStateChanged(object sender, EventArgs e)
        {
            txtAltura.Enabled = !chkMantenhaProporcao.Checked;
            txtLargura.Enabled = !chkMantenhaProporcao.Checked;
        }

        private void BtnLimpar_Click(object sender, EventArgs e) => LimpeCampos();
    }
}
