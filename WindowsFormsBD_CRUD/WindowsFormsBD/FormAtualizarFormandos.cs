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
    public partial class FormAtualizarFormandos : Form
    {
        DBConnect conn = new DBConnect();
        private string contactoAux = ""; 
        public FormAtualizarFormandos()
        {
            InitializeComponent();
        }

        private void FormAtualizarFormandos_Load(object sender, EventArgs e)
        {
            //txtNome.ReadOnly = true;
            //txtMorada.ReadOnly = true;
            //mtxtContacto.ReadOnly = true;
            //mtxtIBAN.ReadOnly = true;
            //rbFeminino.Enabled = false;
            //rbMasculino.Enabled = false;
            //rbOutro.Enabled = false;
            //mtxtDataNascimento.ReadOnly = true;
            //dateTimePicker1.Visible = false;
            DesativarControlos();
            this.AcceptButton = this.btnPesquisa;

            btnAtualizar.Enabled = false;
        }

        private void DesativarControlos()
        {
            txtNome.ReadOnly = true;
            txtMorada.ReadOnly = true;
            mtxtContacto.ReadOnly = true;
            mtxtIBAN.ReadOnly = true;
            rbFeminino.Enabled = false;
            rbMasculino.Enabled = false;
            rbOutro.Enabled = false;
            mtxtDataNascimento.ReadOnly = true;
            dateTimePicker1.Visible = false;
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            string nome = "", morada = "", contacto = "", iban = "", data_nascimento = "";
            char genero = ' ';

            if (conn.PesquisaFormando(nudID.Value.ToString(), ref nome, ref morada,
                ref contacto, ref iban, ref genero, ref data_nascimento))
            {
                txtNome.Text = nome;
                txtMorada.Text = morada;
                mtxtContacto.Text = contacto;
                mtxtIBAN.Text = iban;
                if (genero == 'F')
                {
                    rbFeminino.Checked = true;
                }
                else if (genero == 'M')
                {
                    rbMasculino.Checked = true;
                }
                else if (genero == 'O')
                {
                    rbOutro.Checked = true;
                }
                mtxtDataNascimento.Text = data_nascimento;

                groupBox3.Enabled = false;
                btnAtualizar.Enabled = true;

                txtNome.ReadOnly = false;
                txtMorada.ReadOnly = false;
                mtxtContacto.ReadOnly = false;
                mtxtIBAN.ReadOnly = false;
                rbFeminino.Enabled = true;
                rbMasculino.Enabled = true;
                rbOutro.Enabled = true;
                mtxtDataNascimento.ReadOnly = false;
                

            }
            else
            {
                MessageBox.Show("Formando não encontrado!");
                Limpar();
            }
        }

        private void Limpar()
        {
            nudID.Value = 0;
            txtNome.Text = "";
            txtMorada.Clear();
            mtxtContacto.Clear();
            mtxtIBAN.Text = string.Empty;
            rbFeminino.Checked = false;
            rbMasculino.Checked = false;
            rbOutro.Checked = false;
            //dateTimePicker1.Value = DateTime.Now;
            mtxtDataNascimento.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = true;
            btnAtualizar.Enabled = false;
            nudID.Focus();

            Limpar();
            DesativarControlos();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (VerificarCampos())
            {
                //Vamos Atualizar
                if (conn.Update(nudID.Value.ToString(), txtNome.Text, txtMorada.Text, contactoAux, mtxtIBAN.Text, Genero(),
                    DateTime.Parse(mtxtDataNascimento.Text).ToString("yyyy-MM-dd")))
                {
                    MessageBox.Show("Atualizado com sucesso!");
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
    }
}
