using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gerenciamento_memoria {
    public partial class FormAguarde : Form {
        public FormAguarde() {
            InitializeComponent();
        }

        public void AtualizarTexto(string texto) {
            if (this.InvokeRequired) {
                this.Invoke(new Action(() => AtualizarTexto(texto)));
                return;
            }
            label1.Text = texto; // Substitua pelo nome do seu Label
        }
    }
}
