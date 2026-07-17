using gerenciamento_memoria.classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace gerenciamento_memoria {
    public partial class App : Form {

        public Communication com;               // Object that handles a communication
        private string selected_port = null;    // Default port, data_list and 

        enum GRID_EXIB {
            HEX, HEX0, BIN
        }
        private GRID_EXIB grid_mode = GRID_EXIB.HEX;

        private string str_buffer = "";
        private string str_ready = "";

        int qntRaws = 0;
        private int[] raw_buffer;
        private int[] raw_ready;
        private int raw_counter = 0;
        private int dump_counter = 0;
        private STATE reading_state = STATE.DONE;
        private bool isSynch = false;

        public void InitRawBuffer(int size) {
            qntRaws = size;
            raw_buffer = new int[qntRaws];
            raw_ready = new int[qntRaws];
        }

        public App() {
            InitializeComponent();      // APP Init
            InitRawBuffer(qntRaws);
            com = new Communication();  // Instance Communication Obj
            RenderPortBox();            // Init setting
            RenderRadioButton();
            DoConnection();
            //if () MessageBox.Show("Conectado automaticamente!");
        }

        /* ====================================  */
        /* Connection Functions                  */
        /* ====================================  */

        // Open a connection
        private void DoConnection(string port = "") {
            reading_state = STATE.DONE;
            if (CheckConnectionStatus()) {
                MessageBox.Show("Já conectado!");
                return;
            }
            if (!string.IsNullOrEmpty(port)) {
                selected_port = port;
            }
            if (com.Open(selected_port)) {
                Console.WriteLine($"Porta [{selected_port}] aberta.");
                // Prevents error on setting callback to break and read
                com.RmvReadCallback(ReadData);
                com.SetReadCallback(ReadData);
            } else {
                Console.WriteLine($"Porta [{selected_port}] não aberta (falha).");
                MessageBox.Show("Não foi possível encontrar a porta.");
            }
            CheckConnectionStatus();    // Updates the status of the buttons
        }

        // Close the connection
        private void DoDesconnection() {
            reading_state = STATE.DONE;
            bool status = CheckConnectionStatus();
            if (status) {
                if (com.Close(selected_port)) {
                    Console.WriteLine($"Porta [{selected_port}] encerrada.");
                    selected_port = null;
                } else {
                    Console.WriteLine($"Porta [{selected_port}] não encerrada (falha).");
                }
            }
            CheckConnectionStatus();    // Updates the status of the buttons
        }

        // Connect button
        private void btnConnected_Click(object sender, EventArgs e) {
            string PORT = comboxPorts.SelectedItem?.ToString() ?? "";
            DoConnection(PORT);
        }

        // Disconnect button
        private void btnDesconnect_Click(object sender, EventArgs e) {
            DoDesconnection();
        }

        private void btnRefreshPorts_Click(object sender, EventArgs e) {
            if (CheckConnectionStatus()) {
                MessageBox.Show("Desconecte antes de atualizar a lista de portas.");
                return;
            }
            RenderPortBox();
        }

        private bool CheckConnectionStatus() {
            bool status = com.IsConnected();
            btnConnected.Enabled = !status;
            btnDesconnect.Enabled = status;
            return status;
        }

        /* ====================================  */
        /* Get Serial Data Functions             */
        /* ====================================  */

        // Handles the Port Sended Data
        public void ReadData(object sender, SerialDataReceivedEventArgs e) {
            SerialPort sp = (SerialPort)sender;
            while (sp.BytesToRead > 0) {
                byte v = (byte)sp.ReadByte();
                ProcessByte(v);
            }
        }

        public void ProcessByte(byte v) {
            switch (reading_state) {
                case STATE.DONE:
                    if (v == Communication.dummyByte) {
                        // Receive 'U'
                        reading_state = STATE.WAITING_ID;
                    } else {
                        // Start the buffer for UserMsg (Header Failure)
                        str_buffer = ((char)v).ToString();
                        reading_state = STATE.USER_STRING;
                    }
                    break;

                case STATE.WAITING_ID:
                    if (v == (byte)STATE.STRING) {
                        // Header to System String
                        str_buffer = "";
                        reading_state = STATE.STRING;
                    } else if (v == (byte)STATE.RAW) {
                        // Header to Raw Data
                        raw_counter = 0;
                        reading_state = STATE.RAW;
                    } else if (v == Communication.dummyByte) {//filtrando o valor 255 que é transmitido automaticamente ao resetar
                        //continua no estado STATE.WAITING_ID;///<<<<<<<< 
                    } else {
                        // Wasn't a valid header, start the buffer for UserMsg (Header Failure)
                        // Recoveries the first dummy byte and add the current byte to the buffer
                        str_buffer = ((char)Communication.dummyByte).ToString() + (char)v;
                        reading_state = STATE.USER_STRING;
                    }
                    break;

                case STATE.STRING:
                case STATE.USER_STRING:
                    if (v == '\n') {
                        // Calls the Buffer Render
                        str_buffer += (char)v;
                        RenderStrBuffer(reading_state == STATE.USER_STRING);
                        reading_state = STATE.DONE;
                    } else {
                        str_buffer += (char)v;
                    }
                    break;

                case STATE.RAW:
                    if (raw_counter < raw_buffer.Length) {
                        raw_buffer[raw_counter++] = v;
                    }
                    if (raw_counter >= qntRaws) {
                        RenderRawBuffer();
                        reading_state = STATE.DONE;
                    }
                    break;

                default:
                    reading_state = STATE.DONE;
                    break;
            }
        }

        /* ====================================  */
        /* Write Serial Data Functions           */
        /* ====================================  */

        // Send Data to Device
        private void WriteText(object sender, EventArgs e) {
            try {
                string value = textboxRX.Text;
                textboxRX.Clear();
                if (!string.IsNullOrEmpty(value)) com.WriteStr(value);
                AddComandToLog($"Cmd: '{value}'");
            } catch {
                MessageBox.Show("Verifique a conexão da porta.");
            }
        }

        public void WriteCmdToMicro(byte cmd, byte num_args, params byte[] args) {
            try {
                com.WriteCmd(cmd, num_args, args);
            } catch {
                MessageBox.Show("Verifique a conexão da porta.");
            }
        }

        /* ====================================  */
        /* Renderers controllers                 */
        /* ====================================  */

        // Render the String Buffer in respective TextBox
        private void RenderStrBuffer(bool isUserStr = false) {
            if (this.InvokeRequired) {
                this.Invoke(new Action(() => RenderStrBuffer(isUserStr)));
                return;
            }
            str_ready = str_buffer;

            var match = System.Text.RegularExpressions.Regex.Match(str_ready, @"ao(\d{3})\n");
            if (match.Success) {
                int newSize = Convert.ToInt32(match.Groups[1].Value, 10);
                Console.WriteLine(newSize);
                InitRawBuffer(newSize);
                isSynch = false;    // Ok, done synch
            } else if (isSynch) {
                Console.WriteLine($"[Tentativa Synch Falhou] Recebido: {str_ready.Replace("\n", "\\n")}");
            }

            // Show alert for dump in user box
            bool hasDumpInStr = VerifyTrashInStr(str_ready);
            if (!labelAlert.Visible) {
                if (hasDumpInStr) dump_counter++;
                labelAlert.Visible = dump_counter >= 10;
            }

            if (isUserStr) {
                //Console.WriteLine($"[USER] {str_ready}");//Console.WriteLine($"[USER] {str_ready}");
                //if (!str_ready.Contains("\u00FF"))//<<<<<<<<<<<filtra o valor de caracter 255, gerado ao resetar. Resolvi, mas Se AINDA PERSISTIR DESCOMENTE ESTA LINHA
                textBoxTX.AppendText(str_ready.Replace("\n", "\r\n"));
            } else {
                //Console.WriteLine($"[TEXT] {str_ready}");
                textboxConsole.SelectionColor = Color.Black;
                if (str_ready.Contains("ERRO"))//<<<<<<<<<<
                    textboxConsole.SelectionColor = Color.Red;
                else if (str_ready.Contains("Running"))//<<<<<<<<<<
                    textboxConsole.SelectionColor = Color.Blue;
                else if (str_ready.Contains("Resetado")) {
                    textboxConsole.SelectionColor = Color.Green;//Console.Beep();
                }
                textboxConsole.AppendText(str_ready);
                textboxConsole.ScrollToCaret();
            }
        }

        // Organizes the Raw Buffer and calls the render of the Data Grid
        private void RenderRawBuffer() {
            raw_ready = (int[])raw_buffer.Clone();
            //Console.WriteLine($"{raw_ready}");
            RenderUpdatedTable();
        }

        // Render Raw Buffer in Data Grid
        private void RenderUpdatedTable() {
            if (this.InvokeRequired) {
                this.Invoke(new Action(() => RenderRawBuffer()));
                return;
            }

            UpdateColumnName();

            for (int row = 0; row < dataGrid.RowCount; row++) {
                // ix rhex rdec whex wdec
                int ix = _getRowIndex(row);
                try {

                    string new_formatted_value;
                    switch (grid_mode) {
                        case GRID_EXIB.BIN:
                            new_formatted_value = Convert.ToString(raw_ready[ix], 2).PadLeft(8, '0').Insert(4, " ");
                            break;

                        default:
                        case GRID_EXIB.HEX:
                            new_formatted_value = raw_ready[ix].ToString("X");
                            break;
                        case GRID_EXIB.HEX0:
                            new_formatted_value = raw_ready[ix].ToString("X").PadLeft(2, '0');
                            break;
                    }

                    dataGrid.Rows[row].Cells[2].Value = new_formatted_value;            //Hex or Bin
                    dataGrid.Rows[row].Cells[3].Value = raw_ready[ix];                  //Dec
                } catch {
                    dataGrid.Rows[row].Cells[2].Value = "?";    //Hex
                    dataGrid.Rows[row].Cells[3].Value = "?";    //Dec
                }
            }
        }

        /* ====================================  */
        /* Log for Commands                      */
        /* ====================================  */

        private void AddComandToLog(string log) {
            textboxCMDLog.AppendText($"{log}\r\n");
        }

        /* ====================================  */
        /* Datagrid buttons                      */
        /* ====================================  */

        private void btnAddRow_Click(object sender, EventArgs e) {
            dataGrid.Rows.Add("x", "?", "?");
        }

        private void btnAddNRows_Click(object sender, EventArgs e) {
            int lastIndex = 0;
            foreach (DataGridViewRow row in dataGrid.Rows) {
                string value = row.Cells[0].Value.ToString();
                if (string.IsNullOrEmpty(value) || !int.TryParse(value, out int index)) continue;
                if (index > lastIndex) lastIndex = index;
            }
            if (lastIndex > 0) lastIndex++;
            for (int i = 0; i < 5; i++) {
                dataGrid.Rows.Add((i + lastIndex).ToString(), "?", "?");
            }
        }

        // Clear rows button
        private void btnRmvRow_Click(object sender, EventArgs e) {
            if (dataGrid.SelectedRows.Count > 0) {
                // Clear all rows, starting by the last
                // This way, the rows will be removed without index error
                for (int i = dataGrid.SelectedRows.Count - 1; i >= 0; i--) {
                    dataGrid.Rows.RemoveAt(dataGrid.SelectedRows[i].Index);
                }
            } else {
                MessageBox.Show("Selecione pelo menos uma linha para remover.");
            }
        }

        // When the user start to edit a cell
        private void dataGrid_CellClick_ClearPaint(object sender, DataGridViewCellEventArgs e) {
            _clearDatagridPaint();
        }

        private void dataGrid_CellBeginEdit_ClearPaint(object sender, DataGridViewCellCancelEventArgs e) {
            _clearDatagridPaint();
        }

        // When the user finish edit a cell
        private void dataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            // Clear Colors
            _clearDatagridPaint();
            if (e.ColumnIndex <= 0) return; //blocks for error in edit ix
            int row = e.RowIndex;

            int valueResult = _getRowValue(row);
            if (valueResult == -2) return;

            byte index = (byte)_getRowIndex(row);
            byte value = (byte)valueResult;

            if (value >= 0 && index >= 0 && index < qntRaws) {
                // COMMAND 251: Write value in index from array
                WriteCmdToMicro(251, 2, index, value);
                _clearRowWrite(row);
            } else {
                // Paint the line
                foreach (DataGridViewCell cell in dataGrid.Rows[row].Cells) {
                    cell.Style.BackColor = Color.LightPink;
                }

                // Play sound
                System.Media.SystemSounds.Hand.Play();
            }
        }

        /* ====================================  */
        /* Defaults Commands (Work as special)   */
        /* ====================================  */
        private void btnResetPuc_Click(object sender, EventArgs e) {
            WriteCmdToMicro(245, 0);
            AddComandToLog($"RESET PUC");
        }
        private void btnPause_Click(object sender, EventArgs e) {
            WriteCmdToMicro(246, 0);
            AddComandToLog($"PAUSE");
        }

        private void btnRun_Click(object sender, EventArgs e) {
            WriteCmdToMicro(247, 0);
            AddComandToLog($"RUN");
        }

        /* ====================================  */
        /* Special Commands                      */
        /* ====================================  */
        
        // P3OUT is 19 in hex, 
        //Console.WriteLine($"> Address: {address}, Value: {v}");
        private void btnBITSET_Click(object sender, EventArgs e) {
            // bitset: 0000 0000 0000 0100 (address 0x02), 
            // CMD=190, ix (low), ix(high), value
            var (address, value) = _getSpecialCommandData();
            if (address < 0) return;
            WriteCmdToMicro(190, 3, (byte)(address % 256), (byte)(address >> 8), value);
            AddComandToLog($"BITSET: Add [hex]: {address.ToString("X")} | Bit: {Math.Log(value, 2)}");
        }

        private void btnBITCLR_Click(object sender, EventArgs e) {
            // bitset: 0000 0000 0000 0100 (address 0x02), 
            // CMD=191, ix (low), ix(high), value
            var (address, value) = _getSpecialCommandData();
            if (address < 0) return;
            WriteCmdToMicro(191, 3, (byte)(address % 256), (byte)(address >> 8), value);
            AddComandToLog($"BITCLR: Add [hex]: {address.ToString("X")} | Bit: {Math.Log(value, 2)}");
        }

        private void btnBITINV_Click(object sender, EventArgs e) {
            // bitset: 0000 0000 0000 0100 (address 0x02), 
            // CMD=192, ix (low), ix(high), value
            var (address, value) = _getSpecialCommandData();
            if (address < 0) return;
            WriteCmdToMicro(192, 3, (byte)(address % 256), (byte)(address >> 8), value);
            AddComandToLog($"BITINV: Add [hex]: {address.ToString("X")} | Bit: {Math.Log(value, 2)}");
        }

        /* ====================================  */
        /* Cleaning Buttons                      */
        /* ====================================  */
        private void btnClearUserMsg_Click(object sender, EventArgs e) {
            if (this.InvokeRequired) {
                this.Invoke(new Action(() => RenderRawBuffer()));
                return;
            }
            textBoxTX.Clear();
        }

        private void btnClearMsg_Click(object sender, EventArgs e) {
            if (this.InvokeRequired) {
                this.Invoke(new Action(() => RenderRawBuffer()));
                return;
            }
            textboxConsole.Clear();
        }

        private void btnClearCMD_Click(object sender, EventArgs e) {
            if (this.InvokeRequired) {
                this.Invoke(new Action(() => RenderRawBuffer()));
                return;
            }
            textboxCMDLog.Clear();
        }

        /* ====================================  */
        /* Render the PortCombobox               */
        /* ====================================  */
        private void RenderPortBox() {
            if (this.InvokeRequired) {
                this.Invoke(new Action(() => RenderPortBox()));
                return;
            }

            string[] ports = com.GetPortList();

            comboxPorts.Items.Clear();

            foreach (string port in ports) {
                if (!comboxPorts.Items.Contains(port)) comboxPorts.Items.Add(port);
            }

            // If found only one port, select it.
            if (selected_port == null && ports.Length == 1) {
                comboxPorts.SelectedIndex = 0;
                selected_port = comboxPorts.SelectedItem as string;
            } else if (!CheckConnectionStatus()) {
                comboxPorts.Text = "";
                comboxPorts.SelectedIndex = -1;
                selected_port = null;
            }
        }

        // Update the PortBox every time that a device is detected.
        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);
            // Connected an USB
            if (m.Msg == 0x0219) {
                RenderPortBox();
                if (!com.IsConnected()) {
                    DoDesconnection();
                }
            }
        }

        private void comboxPorts_SelectedIndexChanged(object sender, EventArgs e) {
            DoDesconnection();
        }

        /* ====================================  */
        /* Render he Radio Butons                */
        /* ====================================  */
        private void RenderRadioButton() {
            if (this.InvokeRequired) {
                this.Invoke(new Action(() => RenderRadioButton()));
                return;
            }
            radbtnHex.Checked = true;
        }

        private void UpdateColumnName() {
            if (this.InvokeRequired) {
                this.Invoke(new Action(() => UpdateColumnName()));
                return;
            }
            switch (grid_mode) {
                case GRID_EXIB.BIN:
                    colReadHex.HeaderText = "Bin";
                    break;
                case GRID_EXIB.HEX:
                    colReadHex.HeaderText = "Hex";
                    break;
                case GRID_EXIB.HEX0:
                    colReadHex.HeaderText = "Hex";
                    break;
            }
        }

        /* ====================================  */
        /* Utils                                 */
        /* ====================================  */

        // Get the index of the row, that is in the first cell of the row, -1 if error
        private int _getRowIndex(int row) {
            try {
                // Cell0 = ix
                return int.Parse(dataGrid.Rows[row].Cells[0].Value.ToString().Trim());
            } catch {
                return -1;
            }
        }

        private int _getRowValue(int row) {

            string textHex = dataGrid.Rows[row].Cells[4].Value?.ToString()?.Trim() ?? "";
            string textDec = dataGrid.Rows[row].Cells[5].Value?.ToString()?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(textHex) && string.IsNullOrWhiteSpace(textDec)) {
                return -2;
            }
            if (!string.IsNullOrWhiteSpace(textHex)) {
                try {
                    if (textHex.Contains('x')) textHex = textHex.Split('x')[1]; // Aceita "0x"
                    return int.Parse(textHex, System.Globalization.NumberStyles.HexNumber);
                } catch { }
            }
            if (!string.IsNullOrWhiteSpace(textDec)) {
                try {
                    return int.Parse(textDec);
                } catch { }
            }
            return -1;
        }

        private int _getHex(string text) {
            // Tries to return hex
            try {
                // Cell3 = whex
                text = text.Trim();
                if (text.Contains('x')) text = text.Split('x')[1]; //Accept "0x" notation
                //Console.WriteLine($">{text}");
                return int.Parse(text, System.Globalization.NumberStyles.HexNumber);
            } catch { return -1; }
        }

        private int _getDec(string text) {
            // Tries to return dec
            try {
                // Cell4 = wdec
                return int.Parse(text.Trim());
            } catch { return -1; }
        }

        private bool _clearRowWrite(int row) {
            try {
                dataGrid.Rows[row].Cells[3].Value = "";
                dataGrid.Rows[row].Cells[4].Value = "";
                return true;
            } catch {
                return false;
            }
        }

        private void _clearDatagridPaint() {
            foreach (DataGridViewRow row in dataGrid.Rows) {
                foreach (DataGridViewCell cell in row.Cells) {
                    cell.Style.BackColor = Color.Empty;
                }
            }
        }

        private (int address, byte value) _getSpecialCommandData() {
            int address = _getHex(textboxCMDAddress.Text);
            int bit = _getDec(textboxCMDBit.Text);
            if (bit < 0 || bit > 7 || address < 0 || address > 0xFFFF) {
                // Play sound
                System.Media.SystemSounds.Hand.Play();
                MessageBox.Show("Insira um endereço (em hexadecimal) e um bit válidos (bit: 0-7, address: 0-65535).");
                return (-1, 0);
            }
            double value = Math.Pow(2, bit);
            byte v = (byte)(value % 256);
            return (address, v);
        }

        // Shortcuts from keyboard
        private void _cmdBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                WriteText(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        /* ====================================  */
        /* Write Code to MSP                     */
        /* ====================================  */
        private void btnWriteMSP_Click(object sender, EventArgs e) {
            // 1. Caminhos dos arquivos (mantidos do seu original)
            string pathfile = @"C:\Users\jvcr\workspace\ufpi\Eng.Eletrica - ArqSisComp\hardware\Transmissor_USCIA_TX(v3)\Debug\Transmissor_USCIA_TX.txt";
            string execmd = @"C:\BSLDEMO-2.01c.exe";

            // 2. Defina a porta COM que você deseja usar (ex: COM3)
            string comPort = selected_port;

            // 3. Monta a string de argumentos exatamente no formato comentado:
            // Formatado como: "C:\BSLDEMO-2.01c.exe -cCOM3 -m1 -ij -s2 +epr "C:\Caminho\Para\O\Arquivo.txt"
            //string arguments = $"\"$bsl\" \"-c{comPort}\" -m1 -ij -s2 +epr \"{pathfile}\"";
            string arguments = $"-c{comPort} -m1 -ij -s2 +epr {pathfile}";

            try {
                DoDesconnection();
                // 4. Configura a inicialização do processo
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = execmd;       // O executável
                startInfo.Arguments = arguments;   // Os argumentos/parâmetros

                // Opcional: Oculta a janela preta do CMD se preferir, ou deixe false para ver o BSL rodando
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = false;

                Console.WriteLine($"Executando:");
                Console.WriteLine($"{execmd} {arguments}");

                // 5. Executa o processo
                using (Process process = Process.Start(startInfo)) {
                    // Opcional: Faz o seu programa C# esperar o BSL terminar antes de continuar
                    process.WaitForExit();

                    MessageBox.Show("Processo de gravação finalizado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception ex) {
                MessageBox.Show($"Erro ao executar o BSLDEMO: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                DoConnection(comPort); // Reconnect after writing to MSP
            }
        }

        private void radbtnHex_CheckedChanged(object sender, EventArgs e) {
            grid_mode = GRID_EXIB.HEX;
            UpdateColumnName();
        }

        private void radbtnHex0_CheckedChanged(object sender, EventArgs e) {
            grid_mode = GRID_EXIB.HEX0;
            UpdateColumnName();
        }

        private void radbtnBin_CheckedChanged(object sender, EventArgs e) {
            grid_mode = GRID_EXIB.BIN;
            UpdateColumnName();
        }

        private void Run193(Register register) {
            if (register != null) {
                int qnt_bits = register.Bits;
                int qnt_bytes = qnt_bits / 8;
                int address = register.Address;
                WriteCmdToMicro(193, 3, (byte)(address % 256), (byte)(address >> 8), (byte)qnt_bytes);
            }
        }

        private void btnAddIdx_Click(object sender, EventArgs e) {
            using (AppCreateIndex registersDialog = new AppCreateIndex()) {
                if (registersDialog.ShowDialog() == DialogResult.OK) {
                    registersDialog.selected_registers.ForEach(register => {
                        Run193(register);
                    });
                }
            }
        }

        private void btnAddEnd_Click(object sender, EventArgs e) {
            using (AppCreateIndex registersDialog = new AppCreateIndex(true)) {
                if (registersDialog.ShowDialog() == DialogResult.OK) {
                    Register register = registersDialog.selected_registers[0];
                    Run193(register);
                }
            }
        }

        /* ====================================  */
        /* Verificação se texto está poluído     */
        /* ====================================  */
        public bool VerifyTrashInStr(string text, double maxDumpPercent = 0.40) {
            if (string.IsNullOrEmpty(text)) return false;
            int validChar = 0;
            int dumpChar = 0;
            foreach (char c in text) {
                if (c > 127 || (c < 32 && c != '\n' && c != '\r')) {
                    dumpChar++;
                } else if (!char.IsWhiteSpace(c)) {
                    validChar++;
                }
            }
            if (validChar + dumpChar == 0) return false;
            double propDump = (double)dumpChar / (validChar + dumpChar);
            return propDump > maxDumpPercent;
        }

        private async void btnSynch_Click(object sender, EventArgs e) {
            if (isSynch) return;

            labelAlert.Visible = false;
            dump_counter = 0;
            AddComandToLog("SYNCH");

            isSynch = true;

            btnSynch.Text = "Sincronizando...";
            btnSynch.BackColor = Color.FromArgb(200, 255, 200);
            btnSynch.ForeColor = Color.DarkGreen;
            btnSynch.Cursor = Cursors.WaitCursor;

            while (isSynch) {
                WriteCmdToMicro(195, 0);
                await Task.Delay(750);
            }

            btnSynch.Text = "SINCRONIZAR";
            btnSynch.BackColor = SystemColors.Control;
            btnSynch.ForeColor = SystemColors.ControlText;
            btnSynch.Cursor = Cursors.Default;
        }

        /* ====================================  */
        /* Resize actions                        */
        /* ====================================  */

        private void App_Resize(object sender, EventArgs e) {
            Console.WriteLine(this.Width);
            if (dataGrid.Columns.Count > 0) {
                if (this.Width < 800) {
                    colName.Visible = false;
                } else {
                    colName.Visible = true;
                }
                // Altere o índice [0] para o número da coluna que deseja modificar
                // Usamos a largura do Form (this.Width), mas você também pode usar a do Grid (dataGridView1.Width)
                //if (this.Width < 600) {
                //    dataGridView1.Columns[0].HeaderText = "Qtd"; // Nome curto para telas pequenas
                //} else if (this.Width >= 600 && this.Width < 1000) {
                //    dataGridView1.Columns[0].HeaderText = "Quantidade"; // Nome médio
                //} else {
                //    dataGridView1.Columns[0].HeaderText = "Quantidade de Registros"; // Nome completo para Fullscreen
                //}
            }
        }
    }
}
