namespace gerenciamento_memoria {
    partial class App {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.btnAddRow = new System.Windows.Forms.Button();
            this.panelDatagrid = new System.Windows.Forms.Panel();
            this.splitTop = new System.Windows.Forms.SplitContainer();
            this.labelExibitionType = new System.Windows.Forms.Label();
            this.radbtnBin = new System.Windows.Forms.RadioButton();
            this.radbtnHex = new System.Windows.Forms.RadioButton();
            this.btnWriteMSP = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.colIndexes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReadHex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReadDec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWriteHex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWriteDec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClearTX = new System.Windows.Forms.Button();
            this.labelTX = new System.Windows.Forms.Label();
            this.textBoxTX = new System.Windows.Forms.TextBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnAdd4Rows = new System.Windows.Forms.Button();
            this.btnDesconnect = new System.Windows.Forms.Button();
            this.btnConnected = new System.Windows.Forms.Button();
            this.comboxPorts = new System.Windows.Forms.ComboBox();
            this.btnRmvRow = new System.Windows.Forms.Button();
            this.panelMsg = new System.Windows.Forms.Panel();
            this.splitMsg = new System.Windows.Forms.SplitContainer();
            this.textboxConsole = new System.Windows.Forms.RichTextBox();
            this.btnClearConsole = new System.Windows.Forms.Button();
            this.labelConsole = new System.Windows.Forms.Label();
            this.tabctrlCMD = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnResetPuc = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnBITSET = new System.Windows.Forms.Button();
            this.textboxCMDAddress = new System.Windows.Forms.TextBox();
            this.btnBITINV = new System.Windows.Forms.Button();
            this.labelSetAddress = new System.Windows.Forms.Label();
            this.labelSetBit = new System.Windows.Forms.Label();
            this.textboxCMDBit = new System.Windows.Forms.TextBox();
            this.btnBITCLR = new System.Windows.Forms.Button();
            this.btnClearCMD = new System.Windows.Forms.Button();
            this.textboxCMDLog = new System.Windows.Forms.TextBox();
            this.labelCMDReg = new System.Windows.Forms.Label();
            this.labelSpCMD = new System.Windows.Forms.Label();
            this.btnSendRX = new System.Windows.Forms.Button();
            this.textboxRX = new System.Windows.Forms.TextBox();
            this.labelRX = new System.Windows.Forms.Label();
            this.comboxMicro = new System.Windows.Forms.ComboBox();
            this.panelConsole = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelDatagrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitTop)).BeginInit();
            this.splitTop.Panel1.SuspendLayout();
            this.splitTop.Panel2.SuspendLayout();
            this.splitTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.panelMsg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMsg)).BeginInit();
            this.splitMsg.Panel1.SuspendLayout();
            this.splitMsg.Panel2.SuspendLayout();
            this.splitMsg.SuspendLayout();
            this.tabctrlCMD.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panelConsole.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(83, 5);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(105, 30);
            this.btnAddRow.TabIndex = 1;
            this.btnAddRow.Text = "Adicionar Linha";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // panelDatagrid
            // 
            this.panelDatagrid.Controls.Add(this.splitTop);
            this.panelDatagrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDatagrid.Location = new System.Drawing.Point(0, 0);
            this.panelDatagrid.Name = "panelDatagrid";
            this.panelDatagrid.Size = new System.Drawing.Size(684, 207);
            this.panelDatagrid.TabIndex = 7;
            // 
            // splitTop
            // 
            this.splitTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitTop.Location = new System.Drawing.Point(0, 0);
            this.splitTop.Name = "splitTop";
            // 
            // splitTop.Panel1
            // 
            this.splitTop.Panel1.Controls.Add(this.button1);
            this.splitTop.Panel1.Controls.Add(this.comboxMicro);
            this.splitTop.Panel1.Controls.Add(this.dataGrid);
            // 
            // splitTop.Panel2
            // 
            this.splitTop.Panel2.Controls.Add(this.btnClearTX);
            this.splitTop.Panel2.Controls.Add(this.labelTX);
            this.splitTop.Panel2.Controls.Add(this.textBoxTX);
            this.splitTop.Size = new System.Drawing.Size(684, 207);
            this.splitTop.SplitterDistance = 342;
            this.splitTop.SplitterWidth = 6;
            this.splitTop.TabIndex = 1;
            // 
            // labelExibitionType
            // 
            this.labelExibitionType.AutoSize = true;
            this.labelExibitionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelExibitionType.Location = new System.Drawing.Point(3, 4);
            this.labelExibitionType.Name = "labelExibitionType";
            this.labelExibitionType.Size = new System.Drawing.Size(62, 15);
            this.labelExibitionType.TabIndex = 16;
            this.labelExibitionType.Text = "Exibir em:";
            // 
            // radbtnBin
            // 
            this.radbtnBin.AutoSize = true;
            this.radbtnBin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.radbtnBin.Location = new System.Drawing.Point(6, 42);
            this.radbtnBin.Name = "radbtnBin";
            this.radbtnBin.Size = new System.Drawing.Size(40, 17);
            this.radbtnBin.TabIndex = 11;
            this.radbtnBin.TabStop = true;
            this.radbtnBin.Text = "Bin";
            this.radbtnBin.UseVisualStyleBackColor = true;
            this.radbtnBin.CheckedChanged += new System.EventHandler(this.radbtnBin_CheckedChanged);
            // 
            // radbtnHex
            // 
            this.radbtnHex.AutoSize = true;
            this.radbtnHex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.radbtnHex.Location = new System.Drawing.Point(6, 22);
            this.radbtnHex.Name = "radbtnHex";
            this.radbtnHex.Size = new System.Drawing.Size(44, 17);
            this.radbtnHex.TabIndex = 10;
            this.radbtnHex.TabStop = true;
            this.radbtnHex.Text = "Hex";
            this.radbtnHex.UseVisualStyleBackColor = true;
            this.radbtnHex.CheckedChanged += new System.EventHandler(this.radbtnHex_CheckedChanged);
            // 
            // btnWriteMSP
            // 
            this.btnWriteMSP.Location = new System.Drawing.Point(504, 37);
            this.btnWriteMSP.Name = "btnWriteMSP";
            this.btnWriteMSP.Size = new System.Drawing.Size(165, 27);
            this.btnWriteMSP.TabIndex = 10;
            this.btnWriteMSP.Text = "Gravar MSP";
            this.btnWriteMSP.UseVisualStyleBackColor = true;
            this.btnWriteMSP.Visible = false;
            this.btnWriteMSP.Click += new System.EventHandler(this.btnWriteMSP_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeColumns = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIndexes,
            this.colReadHex,
            this.colReadDec,
            this.colWriteHex,
            this.colWriteDec});
            this.dataGrid.GridColor = System.Drawing.SystemColors.Control;
            this.dataGrid.Location = new System.Drawing.Point(8, 32);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersWidth = 30;
            this.dataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGrid.Size = new System.Drawing.Size(331, 172);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGrid_CellBeginEdit_ClearPaint);
            this.dataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellClick_ClearPaint);
            this.dataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellEndEdit);
            // 
            // colIndexes
            // 
            this.colIndexes.HeaderText = "Índices";
            this.colIndexes.Name = "colIndexes";
            this.colIndexes.Width = 55;
            // 
            // colReadHex
            // 
            this.colReadHex.HeaderText = "Hex";
            this.colReadHex.MinimumWidth = 70;
            this.colReadHex.Name = "colReadHex";
            this.colReadHex.ReadOnly = true;
            this.colReadHex.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colReadHex.ToolTipText = "Ler Hexadecimal";
            this.colReadHex.Width = 70;
            // 
            // colReadDec
            // 
            this.colReadDec.HeaderText = "Dec";
            this.colReadDec.Name = "colReadDec";
            this.colReadDec.ReadOnly = true;
            this.colReadDec.ToolTipText = "Ver Decimal";
            this.colReadDec.Width = 55;
            // 
            // colWriteHex
            // 
            this.colWriteHex.HeaderText = "Hex";
            this.colWriteHex.Name = "colWriteHex";
            this.colWriteHex.ToolTipText = "Escrever Hexadecimal";
            this.colWriteHex.Width = 55;
            // 
            // colWriteDec
            // 
            this.colWriteDec.HeaderText = "Dec";
            this.colWriteDec.Name = "colWriteDec";
            this.colWriteDec.ToolTipText = "Escrever Decimal";
            this.colWriteDec.Width = 55;
            // 
            // btnClearTX
            // 
            this.btnClearTX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearTX.Location = new System.Drawing.Point(241, 6);
            this.btnClearTX.Name = "btnClearTX";
            this.btnClearTX.Size = new System.Drawing.Size(80, 24);
            this.btnClearTX.TabIndex = 15;
            this.btnClearTX.Text = "Limpar";
            this.btnClearTX.UseVisualStyleBackColor = true;
            this.btnClearTX.Click += new System.EventHandler(this.btnClearUserMsg_Click);
            // 
            // labelTX
            // 
            this.labelTX.AutoSize = true;
            this.labelTX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTX.Location = new System.Drawing.Point(8, 11);
            this.labelTX.Name = "labelTX";
            this.labelTX.Size = new System.Drawing.Size(24, 16);
            this.labelTX.TabIndex = 14;
            this.labelTX.Text = "TX";
            // 
            // textBoxTX
            // 
            this.textBoxTX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxTX.Location = new System.Drawing.Point(8, 35);
            this.textBoxTX.Multiline = true;
            this.textBoxTX.Name = "textBoxTX";
            this.textBoxTX.ReadOnly = true;
            this.textBoxTX.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxTX.Size = new System.Drawing.Size(313, 169);
            this.textBoxTX.TabIndex = 1;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.panel1);
            this.panelButtons.Controls.Add(this.btnAdd4Rows);
            this.panelButtons.Controls.Add(this.btnDesconnect);
            this.panelButtons.Controls.Add(this.btnConnected);
            this.panelButtons.Controls.Add(this.btnWriteMSP);
            this.panelButtons.Controls.Add(this.comboxPorts);
            this.panelButtons.Controls.Add(this.btnAddRow);
            this.panelButtons.Controls.Add(this.btnRmvRow);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(0, 207);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(684, 70);
            this.panelButtons.TabIndex = 8;
            // 
            // btnAdd4Rows
            // 
            this.btnAdd4Rows.Location = new System.Drawing.Point(194, 5);
            this.btnAdd4Rows.Name = "btnAdd4Rows";
            this.btnAdd4Rows.Size = new System.Drawing.Size(30, 62);
            this.btnAdd4Rows.TabIndex = 9;
            this.btnAdd4Rows.Text = "x4";
            this.btnAdd4Rows.UseVisualStyleBackColor = true;
            this.btnAdd4Rows.Click += new System.EventHandler(this.btnAdd4Rows_Click);
            // 
            // btnDesconnect
            // 
            this.btnDesconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesconnect.Location = new System.Drawing.Point(589, 4);
            this.btnDesconnect.Name = "btnDesconnect";
            this.btnDesconnect.Size = new System.Drawing.Size(80, 30);
            this.btnDesconnect.TabIndex = 7;
            this.btnDesconnect.Text = "Desconectar";
            this.btnDesconnect.UseVisualStyleBackColor = true;
            this.btnDesconnect.Click += new System.EventHandler(this.btnDesconnect_Click);
            // 
            // btnConnected
            // 
            this.btnConnected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnected.Location = new System.Drawing.Point(504, 4);
            this.btnConnected.Name = "btnConnected";
            this.btnConnected.Size = new System.Drawing.Size(80, 30);
            this.btnConnected.TabIndex = 6;
            this.btnConnected.Text = "Conectar";
            this.btnConnected.UseVisualStyleBackColor = true;
            this.btnConnected.Click += new System.EventHandler(this.btnConnected_Click);
            // 
            // comboxPorts
            // 
            this.comboxPorts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboxPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboxPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboxPorts.FormattingEnabled = true;
            this.comboxPorts.Location = new System.Drawing.Point(388, 5);
            this.comboxPorts.Name = "comboxPorts";
            this.comboxPorts.Size = new System.Drawing.Size(110, 28);
            this.comboxPorts.TabIndex = 5;
            this.comboxPorts.SelectedIndexChanged += new System.EventHandler(this.comboxPorts_SelectedIndexChanged);
            // 
            // btnRmvRow
            // 
            this.btnRmvRow.Location = new System.Drawing.Point(83, 37);
            this.btnRmvRow.Name = "btnRmvRow";
            this.btnRmvRow.Size = new System.Drawing.Size(105, 30);
            this.btnRmvRow.TabIndex = 4;
            this.btnRmvRow.Text = "Remover Linha(s)";
            this.btnRmvRow.UseVisualStyleBackColor = true;
            this.btnRmvRow.Click += new System.EventHandler(this.btnRmvRow_Click);
            // 
            // panelMsg
            // 
            this.panelMsg.Controls.Add(this.splitMsg);
            this.panelMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMsg.Location = new System.Drawing.Point(0, 277);
            this.panelMsg.Name = "panelMsg";
            this.panelMsg.Size = new System.Drawing.Size(684, 284);
            this.panelMsg.TabIndex = 9;
            // 
            // splitMsg
            // 
            this.splitMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMsg.IsSplitterFixed = true;
            this.splitMsg.Location = new System.Drawing.Point(0, 0);
            this.splitMsg.Name = "splitMsg";
            // 
            // splitMsg.Panel1
            // 
            this.splitMsg.Panel1.Controls.Add(this.panelConsole);
            this.splitMsg.Panel1.Controls.Add(this.btnClearConsole);
            this.splitMsg.Panel1.Controls.Add(this.labelConsole);
            this.splitMsg.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splitMsg.Panel2
            // 
            this.splitMsg.Panel2.Controls.Add(this.tabctrlCMD);
            this.splitMsg.Panel2.Controls.Add(this.btnClearCMD);
            this.splitMsg.Panel2.Controls.Add(this.textboxCMDLog);
            this.splitMsg.Panel2.Controls.Add(this.labelCMDReg);
            this.splitMsg.Panel2.Controls.Add(this.labelSpCMD);
            this.splitMsg.Panel2.Controls.Add(this.btnSendRX);
            this.splitMsg.Panel2.Controls.Add(this.textboxRX);
            this.splitMsg.Panel2.Controls.Add(this.labelRX);
            this.splitMsg.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitMsg.Size = new System.Drawing.Size(684, 284);
            this.splitMsg.SplitterDistance = 342;
            this.splitMsg.SplitterWidth = 6;
            this.splitMsg.TabIndex = 0;
            // 
            // textboxConsole
            // 
            this.textboxConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textboxConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textboxConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textboxConsole.Location = new System.Drawing.Point(0, 0);
            this.textboxConsole.Name = "textboxConsole";
            this.textboxConsole.ReadOnly = true;
            this.textboxConsole.Size = new System.Drawing.Size(329, 234);
            this.textboxConsole.TabIndex = 15;
            this.textboxConsole.Text = "";
            // 
            // btnClearConsole
            // 
            this.btnClearConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearConsole.Location = new System.Drawing.Point(272, 7);
            this.btnClearConsole.Name = "btnClearConsole";
            this.btnClearConsole.Size = new System.Drawing.Size(67, 24);
            this.btnClearConsole.TabIndex = 14;
            this.btnClearConsole.Text = "Limpar";
            this.btnClearConsole.UseVisualStyleBackColor = true;
            this.btnClearConsole.Click += new System.EventHandler(this.btnClearMsg_Click);
            // 
            // labelConsole
            // 
            this.labelConsole.AutoSize = true;
            this.labelConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConsole.Location = new System.Drawing.Point(6, 11);
            this.labelConsole.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.labelConsole.Name = "labelConsole";
            this.labelConsole.Size = new System.Drawing.Size(57, 16);
            this.labelConsole.TabIndex = 0;
            this.labelConsole.Text = "Console";
            // 
            // tabctrlCMD
            // 
            this.tabctrlCMD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabctrlCMD.Controls.Add(this.tabPage1);
            this.tabctrlCMD.Controls.Add(this.tabPage2);
            this.tabctrlCMD.Location = new System.Drawing.Point(7, 84);
            this.tabctrlCMD.Name = "tabctrlCMD";
            this.tabctrlCMD.SelectedIndex = 0;
            this.tabctrlCMD.Size = new System.Drawing.Size(314, 110);
            this.tabctrlCMD.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnResetPuc);
            this.tabPage1.Controls.Add(this.btnPause);
            this.tabPage1.Controls.Add(this.btnRun);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(306, 84);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnResetPuc
            // 
            this.btnResetPuc.Location = new System.Drawing.Point(138, 6);
            this.btnResetPuc.Name = "btnResetPuc";
            this.btnResetPuc.Size = new System.Drawing.Size(82, 31);
            this.btnResetPuc.TabIndex = 23;
            this.btnResetPuc.Text = "RESET PUC";
            this.btnResetPuc.UseVisualStyleBackColor = true;
            this.btnResetPuc.Click += new System.EventHandler(this.btnResetPuc_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(72, 6);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(60, 31);
            this.btnPause.TabIndex = 22;
            this.btnPause.Text = "PAUSE";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(6, 6);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(60, 31);
            this.btnRun.TabIndex = 21;
            this.btnRun.Text = "RUN";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnBITSET);
            this.tabPage2.Controls.Add(this.textboxCMDAddress);
            this.tabPage2.Controls.Add(this.btnBITINV);
            this.tabPage2.Controls.Add(this.labelSetAddress);
            this.tabPage2.Controls.Add(this.labelSetBit);
            this.tabPage2.Controls.Add(this.textboxCMDBit);
            this.tabPage2.Controls.Add(this.btnBITCLR);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(306, 84);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnBITSET
            // 
            this.btnBITSET.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBITSET.Location = new System.Drawing.Point(118, 15);
            this.btnBITSET.Name = "btnBITSET";
            this.btnBITSET.Size = new System.Drawing.Size(60, 52);
            this.btnBITSET.TabIndex = 20;
            this.btnBITSET.Text = "BITSET";
            this.btnBITSET.UseVisualStyleBackColor = true;
            this.btnBITSET.Click += new System.EventHandler(this.btnBITSET_Click);
            // 
            // textboxCMDAddress
            // 
            this.textboxCMDAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxCMDAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textboxCMDAddress.Location = new System.Drawing.Point(39, 15);
            this.textboxCMDAddress.Name = "textboxCMDAddress";
            this.textboxCMDAddress.Size = new System.Drawing.Size(73, 23);
            this.textboxCMDAddress.TabIndex = 15;
            // 
            // btnBITINV
            // 
            this.btnBITINV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBITINV.Location = new System.Drawing.Point(243, 15);
            this.btnBITINV.Name = "btnBITINV";
            this.btnBITINV.Size = new System.Drawing.Size(60, 52);
            this.btnBITINV.TabIndex = 21;
            this.btnBITINV.Text = "BITINV";
            this.btnBITINV.UseVisualStyleBackColor = true;
            this.btnBITINV.Click += new System.EventHandler(this.btnBITINV_Click);
            // 
            // labelSetAddress
            // 
            this.labelSetAddress.AutoSize = true;
            this.labelSetAddress.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSetAddress.Location = new System.Drawing.Point(4, 19);
            this.labelSetAddress.Name = "labelSetAddress";
            this.labelSetAddress.Size = new System.Drawing.Size(33, 16);
            this.labelSetAddress.TabIndex = 16;
            this.labelSetAddress.Text = "End :";
            // 
            // labelSetBit
            // 
            this.labelSetBit.AutoSize = true;
            this.labelSetBit.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSetBit.Location = new System.Drawing.Point(4, 47);
            this.labelSetBit.Name = "labelSetBit";
            this.labelSetBit.Size = new System.Drawing.Size(29, 16);
            this.labelSetBit.TabIndex = 17;
            this.labelSetBit.Text = "Bit :";
            // 
            // textboxCMDBit
            // 
            this.textboxCMDBit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxCMDBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textboxCMDBit.Location = new System.Drawing.Point(39, 44);
            this.textboxCMDBit.Name = "textboxCMDBit";
            this.textboxCMDBit.Size = new System.Drawing.Size(73, 23);
            this.textboxCMDBit.TabIndex = 18;
            // 
            // btnBITCLR
            // 
            this.btnBITCLR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBITCLR.Location = new System.Drawing.Point(180, 15);
            this.btnBITCLR.Name = "btnBITCLR";
            this.btnBITCLR.Size = new System.Drawing.Size(60, 52);
            this.btnBITCLR.TabIndex = 19;
            this.btnBITCLR.Text = "BITCLR";
            this.btnBITCLR.UseVisualStyleBackColor = true;
            this.btnBITCLR.Click += new System.EventHandler(this.btnBITCLR_Click);
            // 
            // btnClearCMD
            // 
            this.btnClearCMD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearCMD.Location = new System.Drawing.Point(241, 196);
            this.btnClearCMD.Name = "btnClearCMD";
            this.btnClearCMD.Size = new System.Drawing.Size(80, 24);
            this.btnClearCMD.TabIndex = 16;
            this.btnClearCMD.Text = "Limpar";
            this.btnClearCMD.UseVisualStyleBackColor = true;
            this.btnClearCMD.Click += new System.EventHandler(this.btnClearCMD_Click);
            // 
            // textboxCMDLog
            // 
            this.textboxCMDLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxCMDLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxCMDLog.Location = new System.Drawing.Point(7, 223);
            this.textboxCMDLog.Multiline = true;
            this.textboxCMDLog.Name = "textboxCMDLog";
            this.textboxCMDLog.ReadOnly = true;
            this.textboxCMDLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textboxCMDLog.Size = new System.Drawing.Size(314, 49);
            this.textboxCMDLog.TabIndex = 1;
            // 
            // labelCMDReg
            // 
            this.labelCMDReg.AutoSize = true;
            this.labelCMDReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCMDReg.Location = new System.Drawing.Point(8, 200);
            this.labelCMDReg.Name = "labelCMDReg";
            this.labelCMDReg.Size = new System.Drawing.Size(146, 16);
            this.labelCMDReg.TabIndex = 13;
            this.labelCMDReg.Text = "Registro de Comandos";
            // 
            // labelSpCMD
            // 
            this.labelSpCMD.AutoSize = true;
            this.labelSpCMD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpCMD.Location = new System.Drawing.Point(8, 65);
            this.labelSpCMD.Name = "labelSpCMD";
            this.labelSpCMD.Size = new System.Drawing.Size(136, 16);
            this.labelSpCMD.TabIndex = 6;
            this.labelSpCMD.Text = "Comandos Especiais";
            // 
            // btnSendRX
            // 
            this.btnSendRX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendRX.Location = new System.Drawing.Point(241, 35);
            this.btnSendRX.Name = "btnSendRX";
            this.btnSendRX.Size = new System.Drawing.Size(80, 24);
            this.btnSendRX.TabIndex = 5;
            this.btnSendRX.Text = "Enviar";
            this.btnSendRX.UseVisualStyleBackColor = true;
            this.btnSendRX.Click += new System.EventHandler(this.WriteText);
            // 
            // textboxRX
            // 
            this.textboxRX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxRX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textboxRX.Location = new System.Drawing.Point(7, 36);
            this.textboxRX.Name = "textboxRX";
            this.textboxRX.Size = new System.Drawing.Size(228, 23);
            this.textboxRX.TabIndex = 1;
            this.textboxRX.KeyDown += new System.Windows.Forms.KeyEventHandler(this._cmdBox_KeyDown);
            // 
            // labelRX
            // 
            this.labelRX.AutoSize = true;
            this.labelRX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRX.Location = new System.Drawing.Point(8, 15);
            this.labelRX.Name = "labelRX";
            this.labelRX.Size = new System.Drawing.Size(25, 16);
            this.labelRX.TabIndex = 0;
            this.labelRX.Text = "RX";
            // 
            // comboxMicro
            // 
            this.comboxMicro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboxMicro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboxMicro.FormattingEnabled = true;
            this.comboxMicro.Location = new System.Drawing.Point(8, 3);
            this.comboxMicro.Name = "comboxMicro";
            this.comboxMicro.Size = new System.Drawing.Size(156, 24);
            this.comboxMicro.TabIndex = 17;
            // 
            // panelConsole
            // 
            this.panelConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelConsole.Controls.Add(this.textboxConsole);
            this.panelConsole.Location = new System.Drawing.Point(8, 36);
            this.panelConsole.Name = "panelConsole";
            this.panelConsole.Size = new System.Drawing.Size(331, 236);
            this.panelConsole.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button1.Location = new System.Drawing.Point(170, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 25);
            this.button1.TabIndex = 18;
            this.button1.Text = "Gerenciar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelExibitionType);
            this.panel1.Controls.Add(this.radbtnHex);
            this.panel1.Controls.Add(this.radbtnBin);
            this.panel1.Location = new System.Drawing.Point(8, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(69, 62);
            this.panel1.TabIndex = 17;
            // 
            // App
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.panelMsg);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelDatagrid);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "App";
            this.Text = "Gerenciamento de Memória do MSP430";
            this.panelDatagrid.ResumeLayout(false);
            this.splitTop.Panel1.ResumeLayout(false);
            this.splitTop.Panel2.ResumeLayout(false);
            this.splitTop.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitTop)).EndInit();
            this.splitTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.panelMsg.ResumeLayout(false);
            this.splitMsg.Panel1.ResumeLayout(false);
            this.splitMsg.Panel1.PerformLayout();
            this.splitMsg.Panel2.ResumeLayout(false);
            this.splitMsg.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMsg)).EndInit();
            this.splitMsg.ResumeLayout(false);
            this.tabctrlCMD.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panelConsole.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Panel panelDatagrid;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndexes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReadDec;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWriteHex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWriteDec;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Panel panelMsg;
        private System.Windows.Forms.SplitContainer splitMsg;
        private System.Windows.Forms.Label labelConsole;
        private System.Windows.Forms.Label labelRX;
        private System.Windows.Forms.Button btnRmvRow;
        private System.Windows.Forms.TextBox textboxRX;
        private System.Windows.Forms.Button btnSendRX;
        private System.Windows.Forms.ComboBox comboxPorts;
        private System.Windows.Forms.Label labelSpCMD;
        private System.Windows.Forms.TextBox textboxCMDLog;
        private System.Windows.Forms.Label labelCMDReg;
        private System.Windows.Forms.Button btnConnected;
        private System.Windows.Forms.Button btnDesconnect;
        private System.Windows.Forms.SplitContainer splitTop;
        private System.Windows.Forms.Label labelTX;
        private System.Windows.Forms.TextBox textBoxTX;
        private System.Windows.Forms.Button btnAdd4Rows;
        private System.Windows.Forms.Button btnClearTX;
        private System.Windows.Forms.Button btnClearConsole;
        private System.Windows.Forms.Button btnClearCMD;
        private System.Windows.Forms.RichTextBox textboxConsole;
        private System.Windows.Forms.Button btnWriteMSP;
        private System.Windows.Forms.RadioButton radbtnHex;
        private System.Windows.Forms.RadioButton radbtnBin;
        private System.Windows.Forms.Label labelExibitionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReadHex;
        private System.Windows.Forms.TabControl tabctrlCMD;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnBITSET;
        private System.Windows.Forms.TextBox textboxCMDAddress;
        private System.Windows.Forms.Button btnBITINV;
        private System.Windows.Forms.Label labelSetAddress;
        private System.Windows.Forms.Label labelSetBit;
        private System.Windows.Forms.TextBox textboxCMDBit;
        private System.Windows.Forms.Button btnBITCLR;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnResetPuc;
        private System.Windows.Forms.ComboBox comboxMicro;
        private System.Windows.Forms.Panel panelConsole;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
    }
}

