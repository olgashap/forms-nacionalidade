using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsBD
{
    public partial class FormApagarNacionalidades : Form
    {
        DBConnect ligacao = new DBConnect();
        private string idNacionalidade = "";
        public FormApagarNacionalidades()
        {
            InitializeComponent();
        }

        private void FormApagarNacionalidades_Load(object sender, EventArgs e)
        {

            ligacao.PreencherComboNacionalidade(ref cmbNacionalidade);

            txtALF2.ReadOnly = true;
            txtNacionalidade.ReadOnly = true;
            btnApagar.Enabled = false;
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Deseja eliminar o registo ID " + idNacionalidade.ToString(), "Eliminar",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                { 
                    if (ligacao.DeleteNacionalidade(idNacionalidade))
                {
                    MessageBox.Show("Registo eliminado!");
                    ligacao.PreencherComboNacionalidade(ref cmbNacionalidade);
                    btnCancelar_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Erro na atualização do registo!");
                }
            }
        }

        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = true;
            btnApagar.Enabled = false;
            cmbNacionalidade.Focus();
            txtALF2.ReadOnly = true;
            txtNacionalidade.ReadOnly = true;

            Limpar();
        }

        private void Limpar()
        {

            txtALF2.Text = " ";
            txtNacionalidade.Clear();
            cmbNacionalidade.Text = " ";
        }

        private void cmbNacionalidade_SelectedIndexChanged(object sender, EventArgs e)
        {
                string selectedText = cmbNacionalidade.SelectedItem.ToString();
                string[] parts = selectedText.Split('-');
                string alf2 = parts[0].Trim();
                string nacionalidade = parts[1].Trim();

                idNacionalidade = parts[2].Trim();

                txtALF2.Text = alf2;
                txtNacionalidade.Text = nacionalidade;
                btnApagar.Enabled = true;
        }
    }
}
