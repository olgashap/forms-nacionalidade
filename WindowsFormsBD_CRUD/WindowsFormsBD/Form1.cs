using System;
using System.Windows.Forms;

namespace WindowsFormsBD
{
    public partial class Form1 : Form
    {
        DBConnect ligacao = new DBConnect();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            label1.Text = "Ligação: " + ligacao.StatusConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //DBConnect ligacao = new DBConnect();
            MessageBox.Show("Nº Total de formandos: " + ligacao.Count());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ligacao.Insert();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ligacao.Delete())
            {
                MessageBox.Show("Foi eliminado com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro na elimanção!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ligacao.Delete(textBox1.Text))
            {
                MessageBox.Show("Foi eliminado com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro na elimanção!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (ligacao.Update())
            {
                MessageBox.Show("Foi atualizado com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro na atualização!");
            }
        }
    }
}
