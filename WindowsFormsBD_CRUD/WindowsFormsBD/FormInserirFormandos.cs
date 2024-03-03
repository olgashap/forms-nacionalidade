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
    public partial class FormInserirFormandos : Form
    {
        DBConnect conn = new DBConnect();
        private string contactoAux = "";
        public FormInserirFormandos()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (VerificarCampos())
            {
                //Vamos gravar
                if (conn.Insert(nudID.Value.ToString(), txtNome.Text, txtMorada.Text, contactoAux, mtxtIBAN.Text, Genero(), 
                    DateTime.Parse(mtxtDataNascimento.Text).ToString("yyyy-MM-dd")))
                {
                    MessageBox.Show("Gravado com sucesso!");
                    Limpar();
                    txtNome.Focus();
                }
                else
                {
                    MessageBox.Show("Erro na gravação do registo!");
                }
            }
        }

        private void Limpar()
        {
            nudID.Value = conn.DevolveUltimaID();
            txtNome.Text = "";
            txtMorada.Clear();
            mtxtContacto.Clear();
            mtxtIBAN.Text = string.Empty;
            rbFeminino.Checked = false;
            rbMasculino.Checked = false;
            rbOutro.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
            mtxtDataNascimento.Clear();
        }

        private void FormInserirFormandos_Load(object sender, EventArgs e)
        {
            nudID.Value = conn.DevolveUltimaID();
        }

        private bool VerificarCampos()
        {
            if (nudID.Value == 0) 
            {
                MessageBox.Show("Erro no campo ID!");
                nudID.Focus();
                return false; 
            }

            txtNome.Text = Geral.TirarEspacos(txtNome.Text);
            if (txtNome.Text.Length < 3)
            {
                MessageBox.Show("Erro no campo Nome!");
                txtNome.Focus();
                return false;
            }

            txtMorada.Text = Geral.TirarEspacos(txtMorada.Text);
            if (txtMorada.Text.Length < 3)
            {
                MessageBox.Show("Erro no campo Morada!");
                txtMorada.Focus();
                return false;
            }

            //falta verificar o campo contacto
            contactoAux = mtxtContacto.Text.Replace(" ", "");
            //if (mtxtContacto.Text.Length != 0 && mtxtContacto.Text.Length != 9)
            if (contactoAux.Length != 0 && contactoAux.Length != 9)
            {
                MessageBox.Show("Erro no campo Contacto!");
                mtxtContacto.Focus();
                return false;
            }


            if (mtxtIBAN.Text.Length < 25) 
            {
                MessageBox.Show("Erro no campo IBAN!");
                mtxtIBAN.Focus();
                return false;
            }

            if (Genero() == 'T')
            {
                MessageBox.Show("Erro no campo Género!");
                rbFeminino.Focus();
                return false;
            }

            if (mtxtDataNascimento.Text.Length != 10 || Geral.CheckDate(mtxtDataNascimento.Text) == false)
            {
                MessageBox.Show("Erro no campo Data Nascimento!");
                mtxtDataNascimento.Focus();
                return false;
            }

            return true;
        }

        private char Genero()
        {
            char genero = 'T';
            if (rbFeminino.Checked)
            {
                genero = 'F';
            }
            else if (rbMasculino.Checked)
            {
                genero = 'M';
            } 
            else if (rbOutro.Checked)
            {
                genero = 'O';
            }
            return genero;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            mtxtDataNascimento.Text = dateTimePicker1.Value.ToShortDateString();
        }

        private void mtxtDataNascimento_TextChanged(object sender, EventArgs e)
        {
            int dia, mes, ano;
            string textoData;
            DateTime data;

            if (mtxtDataNascimento.MaskCompleted == true)
            {
                textoData = mtxtDataNascimento.Text;
                dia = int.Parse(textoData.Substring(0,2));
                mes = int.Parse(textoData.Substring(3,2));
                ano = int.Parse(textoData.Substring(6));
                try
                {
                    data = DateTime.Parse(dia + "-" + mes + "-" + ano);
                    dateTimePicker1.Value = data;
                }
                catch 
                { 
                    MessageBox.Show("Data incorreta!", "Erro!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    mtxtDataNascimento.Focus();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
