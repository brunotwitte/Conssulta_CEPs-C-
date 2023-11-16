using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultarCEPs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            textEstado.Text = String.Empty;
            textBairro.Text = String.Empty;
            textCidade.Text = String.Empty;
            textRua.Text = String.Empty;
            textCEP.Text = String.Empty;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textCEP.Text))
            {
                using (var ws = new WSCorreios.AtendeClienteClient())
                {
                    try
                    {
                        var endereco = ws.consultaCEP(textCEP.Text.Trim());
                        textEstado.Text = endereco.uf;
                        textCidade.Text = endereco.cidade;
                        textBairro.Text = endereco.bairro;
                        textRua.Text = endereco.end;
                      
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
            else
            {
                MessageBox.Show("Informe um CEP Valido...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }

}

