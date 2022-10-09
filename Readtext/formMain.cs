using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Readtext;
using System.Speech.Synthesis;
using System.IO;

namespace Readtext
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
            paneldecontrolo.Visible = false;
        }


        SpeechSynthesizer sp = new SpeechSynthesizer();

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (richTextBox2.SelectedText == "")
            {
                // Caso ele esteja falando
                if (sp.State == SynthesizerState.Speaking)
                    sp.SpeakAsyncCancelAll();
                sp.SpeakAsync((richTextBox2.Text).ToString());
            }
            else
            {
                speech.speak(richTextBox2.SelectedText.ToString());
            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            sp.SpeakAsyncCancelAll();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sp.State == SynthesizerState.Speaking)
            {
                gunaTransition1.ShowSync(paneldecontrolo);
            }
            else
            {
                gunaTransition1.HideSync(paneldecontrolo);
            }
        }

        private void Copiar()
        {
            if (richTextBox2.SelectionLength > 0)
            {
                richTextBox2.Copy();
            }
        }

        private void Colar()
        {
            richTextBox2.Paste();
        }
        
        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void AbrirArquivo()
        {
            //define as propriedades do controle 
            //OpenFileDialog
            this.ofd1.Multiselect = true;
            this.ofd1.Title = "Selecionar Arquivo";
            ofd1.InitialDirectory = @"C:\Dados\";
            //filtra para exibir somente arquivos textos
            ofd1.Filter = "Images (*.TXT)|*.TXT|" + "All files (*.*)|*.*";
            ofd1.CheckFileExists = true;
            ofd1.CheckPathExists = true;
            ofd1.FilterIndex = 1;
            ofd1.RestoreDirectory = true;
            ofd1.ReadOnlyChecked = true;
            ofd1.ShowReadOnly = true;
            DialogResult dr = this.ofd1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    FileStream fs = new FileStream(ofd1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader m_streamReader = new StreamReader(fs);
                    // Lê o arquivo usando a classe StreamReader
                    m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    // Lê cada linha do stream e faz o parse até a última linha
                    this.richTextBox2.Text = "";
                    string strLine = m_streamReader.ReadLine();
                    while (strLine != null)
                    {
                        this.richTextBox2.Text += strLine + "\n";
                        strLine = m_streamReader.ReadLine();
                    }
                    // Fecha o stream
                    m_streamReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            AbrirArquivo();
        }


        private void gunaButton3_Click(object sender, EventArgs e)
        {
            //define o titulo
            saveFileDialog1.Title = "Salvar Arquivo Texto";
            //Define as extensões permitidas
            saveFileDialog1.Filter = "Text File|.txt";
            //define o indice do filtro
            saveFileDialog1.FilterIndex = 0;
            //Atribui um valor vazio ao nome do arquivo
            saveFileDialog1.FileName = "Mac_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
            //Define a extensão padrão como .txt
            saveFileDialog1.DefaultExt = ".txt";
            //define o diretório padrão
            saveFileDialog1.InitialDirectory = @"c:\dados";
            //restaura o diretorio atual antes de fechar a janela
            saveFileDialog1.RestoreDirectory = true;

            //Abre a caixa de dialogo e determina qual botão foi pressionado
            DialogResult resultado = saveFileDialog1.ShowDialog();

            //Se o ousuário pressionar o botão Salvar
            if (resultado == DialogResult.OK)
            {
                //Cria um stream usando o nome do arquivo
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);

                //Cria um escrito que irá escrever no stream
                StreamWriter writer = new StreamWriter(fs);
                //escreve o conteúdo da caixa de texto no stream
                writer.Write(richTextBox2.Text);
                //fecha o escrito e o stream
                writer.Close();
            }
            else
            {
                //exibe mensagem informando que a operação foi cancelada
                MessageBox.Show("Operação cancelada");
            }
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void Negritar()
        {
            string nome_fonte = null;
            float tamanho_fonte = 0;
            bool negrito = false;
            nome_fonte = richTextBox2.Font.Name;
            tamanho_fonte = richTextBox2.Font.Size;
            negrito = richTextBox2.Font.Bold;
            if (negrito == false)
            {
                richTextBox2.SelectionFont = new Font(nome_fonte, tamanho_fonte, FontStyle.Bold);
            }
            else
            {
                richTextBox2.SelectionFont = new Font(nome_fonte, tamanho_fonte, FontStyle.Regular);
            }
        }

        private void gunaButton7_Click(object sender, EventArgs e)
        {
            Negritar();
        }

        private void Italico()
        {
            string nome_fonte = null;
            float tamanho_fonte = 0;
            bool italico = false;
            nome_fonte = richTextBox2.Font.Name;
            tamanho_fonte = richTextBox2.Font.Size;
            italico = richTextBox2.Font.Italic;
            if (italico == false)
            {
                richTextBox2.SelectionFont = new Font(nome_fonte, tamanho_fonte, FontStyle.Italic);
            }
            else
            {
                richTextBox2.SelectionFont = new Font(nome_fonte, tamanho_fonte, FontStyle.Italic);
            }
        }

        private void gunaButton9_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void Sublinhar()
        {
            string nome_fonte = null;
            float tamanho_fonte = 0;
            bool sublinha = false;
            nome_fonte = richTextBox2.Font.Name;
            tamanho_fonte = richTextBox2.Font.Size;
            sublinha = richTextBox2.Font.Underline;
            if (sublinha == false)
            {
                richTextBox2.SelectionFont = new Font(nome_fonte, tamanho_fonte, FontStyle.Underline);
            }
            else
            {
                richTextBox2.SelectionFont = new Font(nome_fonte, tamanho_fonte, FontStyle.Underline);
            }
        }

        private void gunaButton8_Click(object sender, EventArgs e)
        {
            Sublinhar();
        }

        private void gunaButton10_Click(object sender, EventArgs e)
        {
            DialogResult result = fontdlg1.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (richTextBox2.SelectionFont != null)
                {
                    richTextBox2.SelectionFont = fontdlg1.Font;
                }
            }
        }

        private void gunaButton13_Click(object sender, EventArgs e)
        {
            richTextBox2.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void gunaButton11_Click(object sender, EventArgs e)
        {
            richTextBox2.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void gunaButton12_Click(object sender, EventArgs e)
        {
            richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
        }

    }
}
