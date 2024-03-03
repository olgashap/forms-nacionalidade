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
    public partial class FormInserirNacionalidade : Form

    {
        DBConnect conn = new DBConnect();
        public FormInserirNacionalidade()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            
                //Vamos gravar
                if (conn.InsertNacionalidade(txtALF2.Text, txtNacionalidade.Text))
                {
                    MessageBox.Show("Gravado com sucesso!");
                    Limpar();
                    txtALF2.Focus();
                }
                else
                {
                    MessageBox.Show("Erro na gravação do registo!");
                } 
        }

        private void Limpar()
        {
           
            txtALF2.Text = "";
            txtNacionalidade.Clear();
           
        }

       

            private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

          
       
    }
}
