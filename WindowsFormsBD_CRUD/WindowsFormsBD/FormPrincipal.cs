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
    public partial class FormPrincipal : Form
    {
        FormInserirFormandos formInserirFormandos = new FormInserirFormandos();
        FormApagarFormandos formApagarFormandos = new FormApagarFormandos();
        FormAtualizarFormandos formAtualizarFormandos = new FormAtualizarFormandos();
        FormListarFormandos formListarFormandos = new FormListarFormandos();
        FormInserirNacionalidade formInserirNacionalidade = new FormInserirNacionalidade();
        FormAtualizarNacionalidade formAtualizarNacionalidade = new FormAtualizarNacionalidade();
        FormApagarNacionalidades formApagarNacionalidades = new FormApagarNacionalidades();
        FormListarNacionalidade formListarNacionalidade = new FormListarNacionalidade();
        
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void inserirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formInserirFormandos.IsDisposed)
            {
                formInserirFormandos = new FormInserirFormandos();
            }
            formInserirFormandos.MdiParent = this;
            formInserirFormandos.StartPosition = FormStartPosition.Manual;
            formInserirFormandos.Location = new Point((this.ClientSize.Width - formInserirFormandos.Width) / 2, 
                (this.ClientSize.Height - formInserirFormandos.Height) / 3);
            formInserirFormandos.Show();
            formInserirFormandos.Activate();

        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formApagarFormandos.IsDisposed)
            {
                formApagarFormandos = new FormApagarFormandos();
            }
            formApagarFormandos.MdiParent = this;
            formApagarFormandos.StartPosition = FormStartPosition.Manual;
            formApagarFormandos.Location = new Point((this.ClientSize.Width - formApagarFormandos.Width) / 2,
                (this.ClientSize.Height - formApagarFormandos.Height) / 3);
            formApagarFormandos.Show();
            formApagarFormandos.Activate();

        }

        private void atualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formAtualizarFormandos.IsDisposed)
            {
                formAtualizarFormandos = new FormAtualizarFormandos();
            }
            formAtualizarFormandos.MdiParent = this;
            formAtualizarFormandos.StartPosition = FormStartPosition.Manual;
            formAtualizarFormandos.Location = new Point((this.ClientSize.Width - formAtualizarFormandos.Width) / 2,
                (this.ClientSize.Height - formAtualizarFormandos.Height) / 3);
            formAtualizarFormandos.Show();
            formAtualizarFormandos.Activate();

        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formListarFormandos.IsDisposed)
            {
                formListarFormandos = new FormListarFormandos();
            }
            formListarFormandos.MdiParent = this;
            formListarFormandos.StartPosition = FormStartPosition.Manual;
            formListarFormandos.Location = new Point((this.ClientSize.Width - formListarFormandos.Width) / 2,
                (this.ClientSize.Height - formListarFormandos.Height) / 3);
            formListarFormandos.Show();
            formListarFormandos.Activate();

        }

        
        
        //Nacionalidade
        

        private void inserirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (formInserirNacionalidade.IsDisposed)
            {
                formInserirNacionalidade = new FormInserirNacionalidade();
            }
            formInserirNacionalidade.MdiParent = this;
            formInserirNacionalidade.StartPosition = FormStartPosition.Manual;
            formInserirNacionalidade.Location = new Point((this.ClientSize.Width - formInserirNacionalidade.Width) / 2,
                (this.ClientSize.Height - formInserirNacionalidade.Height) / 3);
            formInserirNacionalidade.Show();
            formInserirNacionalidade.Activate();
        }

        private void atualizarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (formAtualizarNacionalidade.IsDisposed)
            {
                formAtualizarNacionalidade = new FormAtualizarNacionalidade();
            }
            formAtualizarNacionalidade.MdiParent = this;
            formAtualizarNacionalidade.StartPosition = FormStartPosition.Manual;
            formAtualizarNacionalidade.Location = new Point((this.ClientSize.Width - formAtualizarNacionalidade.Width) / 2,
                (this.ClientSize.Height - formAtualizarNacionalidade.Height) / 3);
            formAtualizarNacionalidade.Show();
            formAtualizarNacionalidade.Activate();
        }

        

        private void apagarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (formApagarNacionalidades.IsDisposed)
            {
                formApagarNacionalidades = new FormApagarNacionalidades();
            }
            formApagarNacionalidades.MdiParent = this;
            formApagarNacionalidades.StartPosition = FormStartPosition.Manual;
            formApagarNacionalidades.Location = new Point((this.ClientSize.Width - formApagarNacionalidades.Width) / 2,
                (this.ClientSize.Height - formInserirNacionalidade.Height) / 3);
            formApagarNacionalidades.Show();
            formApagarNacionalidades.Activate();

        }
        

        private void listarToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            if (formListarNacionalidade.IsDisposed)
            {
                formListarNacionalidade = new FormListarNacionalidade();
            }
            formListarNacionalidade.MdiParent = this;
            formListarNacionalidade.StartPosition = FormStartPosition.Manual;
            formListarNacionalidade.Location = new Point((this.ClientSize.Width - formListarNacionalidade.Width) / 2,
                (this.ClientSize.Height - formListarNacionalidade.Height) / 3);
            formListarNacionalidade.Show();
            formListarNacionalidade.Activate();

        }
    }
}
