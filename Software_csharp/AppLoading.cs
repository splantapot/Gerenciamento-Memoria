using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace gerenciamento_memoria {
    public partial class AppLoading : Form {

        private const string DEFAULT_MESSAGE = "Alocando registradores no microcontrolador...Aguarde.";
        private const string DEFAULT_COUNTER_MESSAGE = "Operação:";
        private int counter  = 0;
        private int targetCounter = 0;

        public AppLoading(string messageText = DEFAULT_MESSAGE, int max_count = 0) {
            InitializeComponent();
            labelMsg.Text = messageText;
            targetCounter = max_count;
            if (targetCounter <= 0) {
                labelCounter.Visible = false;
            }
        }

        public void UpdateMessage(string text) {
            if (InvokeRequired) {
                Invoke(new Action(() => UpdateMessage(text)));
                return;
            }
            labelMsg.Text = text;
        }

        public void ShowCounter() {
            if (InvokeRequired) {
                Invoke(new Action(() => ShowCounter()));
                return;
            }

            labelCounter.Text = $"{DEFAULT_COUNTER_MESSAGE} [{counter}/{targetCounter}]";
        }

        public void IncrementCounter() {
            counter++;
            ShowCounter();
        }
    }
}
