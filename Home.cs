using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Security;

namespace ConverteFotos
{
    public partial class Home : Form
    {
        private readonly OpenFileDialog? _openFileDialog;
        private string? _pastaOrigem;
        private long _tamanhoTotalMB;

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
                    long tamanhoTotalBytes = 0;
                    txtImagens.Clear();
                    System.Text.StringBuilder sb = new();
                    _pastaOrigem = Path.GetDirectoryName(_openFileDialog?.FileName);

                    foreach (string imagem in _openFileDialog.SafeFileNames)
                    {
                        sb.AppendLine(imagem);
                        tamanhoTotalBytes += new FileInfo(@$"{_pastaOrigem}\{imagem}").Length;
                    }

                    txtImagens.Text = sb.ToString();
                    lbTamanhoTotal.Text = $"Tamanho total: {ObtenhaStringTamanhoTotal(ObtenhaTamanhoTotal(tamanhoTotalBytes))}";
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
            if (string.IsNullOrEmpty(txtImagens.Text))
            {
                MessageBox.Show("Selecione ao menos uma imagem!");
                return;
            }

            string pastaDestino = @$"{_pastaOrigem}\Imagens Convertidas";
            long tamanhoTotalFinal = 0;

            if (!Directory.Exists(pastaDestino))
            {
                Directory.CreateDirectory(pastaDestino);
            }

            string[] arquivos = _openFileDialog.SafeFileNames;

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
                tamanhoTotalFinal += new FileInfo(@$"{pastaDestino}\{arquivo}").Length;
            }
            double diferencaoTotal = (_tamanhoTotalMB - ObtenhaTamanhoTotal(tamanhoTotalFinal));

            MessageBox.Show($"Imagens convertidas!\n Ganho de {ObtenhaStringTamanhoTotal(diferencaoTotal)}");
            LimpeCampos();
            Process.Start("explorer.exe", pastaDestino);
        }

        private static double ObtenhaTamanhoTotal(double tamanho) => tamanho / (1024.0 * 1024.0);

        private static string ObtenhaStringTamanhoTotal(double tamanho) => tamanho < 1 ? $"{(int)(tamanho * 1024.0)} KB" : $"{tamanho:F2} MB";

        private void LimpeCampos()
        {
            txtImagens.Clear();
            chkMantenhaProporcao.Checked = true;
            lbTamanhoTotal.Text = string.Empty;
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
