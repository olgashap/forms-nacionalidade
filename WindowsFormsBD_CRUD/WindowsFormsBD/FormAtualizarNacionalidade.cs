using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsBD
{
    public partial class FormAtualizarNacionalidade : Form
    {

        DBConnect conn = new DBConnect();
        private string idNacionalidade = "";

        public FormAtualizarNacionalidade()
        {
            InitializeComponent();
        }


        private void FormAtualizarNacionalidade_Load(object sender, EventArgs e)
        {
            conn.PreencherComboNacionalidade(ref cmbNacionalidade);

            txtALF2.ReadOnly = true;
            txtNacionalidade.ReadOnly = true;
            
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
           
                if (VerificarCampos())
                {
                    //Vamos Atualizar
                    if (conn.AtualizarNacionalidade( idNacionalidade, txtALF2.Text, txtNacionalidade.Text))
                    {
                        MessageBox.Show("Atualizado com sucesso!");
                        conn.PreencherComboNacionalidade(ref cmbNacionalidade);
                        btnCancelar_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Erro na atualização do registo!");
                    }
                }
         }

        private bool VerificarCampos()
        {
               

            txtALF2.Text = Geral.TirarEspacos(txtALF2.Text);
            if (txtALF2.Text.Length > 2)
            {
                MessageBox.Show("Erro no campo ALF2!");
                txtALF2.Focus();
                return false;
            }

            txtNacionalidade.Text = Geral.TirarEspacos(txtNacionalidade.Text);
            if (txtNacionalidade.Text.Length < 3)
            {
                MessageBox.Show("Erro no campo Nacionalidade!");
                txtNacionalidade.Focus();
                return false;
            }
        return true; 

        }

        private void Limpar()
        {
           
            txtALF2.Text = " ";
            txtNacionalidade.Clear();
            cmbNacionalidade.Text = " ";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = true;
            btnAtualizar.Enabled = false;
            cmbNacionalidade.Focus();
            txtALF2.ReadOnly = true;
            txtNacionalidade.ReadOnly = true;

            Limpar();
          
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
            txtALF2.ReadOnly = false;
            txtNacionalidade.ReadOnly = false;
        }
    }
}
