namespace gerenciamento_memoria {
    partial class AppCreateIndex {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppCreateIndex));
            this.panelManualCMD = new System.Windows.Forms.Panel();
            this.textboxBytes = new System.Windows.Forms.TextBox();
            this.labelBytes = new System.Windows.Forms.Label();
            this.btnAddAddress = new System.Windows.Forms.Button();
            this.labelTitleAddress = new System.Windows.Forms.Label();
            this.textboxAddress = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.treeviewRegisters = new System.Windows.Forms.TreeView();
            this.treeviewSelected = new System.Windows.Forms.TreeView();
            this.labelTitleRegisters = new System.Windows.Forms.Label();
            this.labelTitleSelection = new System.Windows.Forms.Label();
            this.textboxProp1 = new System.Windows.Forms.TextBox();
            this.panelEdition = new System.Windows.Forms.Panel();
            this.labelPropType = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.textboxProp2 = new System.Windows.Forms.TextBox();
            this.labelProp2 = new System.Windows.Forms.Label();
            this.labelProp1 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelManualCMD.SuspendLayout();
            this.panelEdition.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelManualCMD
            // 
            this.panelManualCMD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelManualCMD.Controls.Add(this.textboxBytes);
            this.panelManualCMD.Controls.Add(this.labelBytes);
            this.panelManualCMD.Controls.Add(this.btnAddAddress);
            this.panelManualCMD.Controls.Add(this.labelTitleAddress);
            this.panelManualCMD.Controls.Add(this.textboxAddress);
            this.panelManualCMD.Controls.Add(this.labelAddress);
            this.panelManualCMD.Location = new System.Drawing.Point(12, 12);
            this.panelManualCMD.Name = "panelManualCMD";
            this.panelManualCMD.Size = new System.Drawing.Size(460, 64);
            this.panelManualCMD.TabIndex = 0;
            // 
            // textboxBytes
            // 
            this.textboxBytes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxBytes.Location = new System.Drawing.Point(297, 26);
            this.textboxBytes.Name = "textboxBytes";
            this.textboxBytes.Size = new System.Drawing.Size(88, 21);
            this.textboxBytes.TabIndex = 5;
            this.textboxBytes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textboxManual_KeyDown);
            // 
            // labelBytes
            // 
            this.labelBytes.AutoSize = true;
            this.labelBytes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBytes.Location = new System.Drawing.Point(232, 29);
            this.labelBytes.Name = "labelBytes";
            this.labelBytes.Size = new System.Drawing.Size(63, 15);
            this.labelBytes.TabIndex = 4;
            this.labelBytes.Text = "Qnt. bytes:";
            // 
            // btnAddAddress
            // 
            this.btnAddAddress.Location = new System.Drawing.Point(391, 24);
            this.btnAddAddress.Name = "btnAddAddress";
            this.btnAddAddress.Size = new System.Drawing.Size(69, 25);
            this.btnAddAddress.TabIndex = 3;
            this.btnAddAddress.Text = "Adicionar";
            this.btnAddAddress.UseVisualStyleBackColor = true;
            this.btnAddAddress.Click += new System.EventHandler(this.btnAddAddress_Click);
            // 
            // labelTitleAddress
            // 
            this.labelTitleAddress.AutoSize = true;
            this.labelTitleAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleAddress.Location = new System.Drawing.Point(3, 3);
            this.labelTitleAddress.Name = "labelTitleAddress";
            this.labelTitleAddress.Size = new System.Drawing.Size(121, 16);
            this.labelTitleAddress.TabIndex = 2;
            this.labelTitleAddress.Text = "Inserção manual";
            // 
            // textboxAddress
            // 
            this.textboxAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxAddress.Location = new System.Drawing.Point(69, 26);
            this.textboxAddress.Name = "textboxAddress";
            this.textboxAddress.Size = new System.Drawing.Size(156, 21);
            this.textboxAddress.TabIndex = 1;
            this.textboxAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textboxManual_KeyDown);
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddress.Location = new System.Drawing.Point(3, 29);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(63, 15);
            this.labelAddress.TabIndex = 0;
            this.labelAddress.Text = "Endereço:";
            // 
            // treeviewRegisters
            // 
            this.treeviewRegisters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.treeviewRegisters.Location = new System.Drawing.Point(3, 19);
            this.treeviewRegisters.Name = "treeviewRegisters";
            this.treeviewRegisters.Size = new System.Drawing.Size(225, 283);
            this.treeviewRegisters.TabIndex = 1;
            this.treeviewRegisters.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeviewRegisters_AfterSelect);
            // 
            // treeviewSelected
            // 
            this.treeviewSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.treeviewSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.treeviewSelected.Location = new System.Drawing.Point(232, 19);
            this.treeviewSelected.Name = "treeviewSelected";
            this.treeviewSelected.Size = new System.Drawing.Size(225, 283);
            this.treeviewSelected.TabIndex = 2;
            // 
            // labelTitleRegisters
            // 
            this.labelTitleRegisters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitleRegisters.AutoSize = true;
            this.labelTitleRegisters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleRegisters.Location = new System.Drawing.Point(20, 1);
            this.labelTitleRegisters.Name = "labelTitleRegisters";
            this.labelTitleRegisters.Size = new System.Drawing.Size(186, 15);
            this.labelTitleRegisters.TabIndex = 4;
            this.labelTitleRegisters.Text = "Registradores pré-definidos";
            // 
            // labelTitleSelection
            // 
            this.labelTitleSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitleSelection.AutoSize = true;
            this.labelTitleSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleSelection.Location = new System.Drawing.Point(273, 1);
            this.labelTitleSelection.Name = "labelTitleSelection";
            this.labelTitleSelection.Size = new System.Drawing.Size(146, 15);
            this.labelTitleSelection.TabIndex = 5;
            this.labelTitleSelection.Text = "Valores Selecionados";
            // 
            // textboxProp1
            // 
            this.textboxProp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxProp1.Location = new System.Drawing.Point(66, 24);
            this.textboxProp1.Name = "textboxProp1";
            this.textboxProp1.Size = new System.Drawing.Size(159, 21);
            this.textboxProp1.TabIndex = 4;
            // 
            // panelEdition
            // 
            this.panelEdition.Controls.Add(this.labelPropType);
            this.panelEdition.Controls.Add(this.btnEdit);
            this.panelEdition.Controls.Add(this.textboxProp2);
            this.panelEdition.Controls.Add(this.labelProp2);
            this.panelEdition.Controls.Add(this.labelProp1);
            this.panelEdition.Controls.Add(this.textboxProp1);
            this.panelEdition.Location = new System.Drawing.Point(3, 304);
            this.panelEdition.Name = "panelEdition";
            this.panelEdition.Size = new System.Drawing.Size(225, 97);
            this.panelEdition.TabIndex = 6;
            this.panelEdition.Visible = false;
            // 
            // labelPropType
            // 
            this.labelPropType.AutoSize = true;
            this.labelPropType.Location = new System.Drawing.Point(63, 8);
            this.labelPropType.Name = "labelPropType";
            this.labelPropType.Size = new System.Drawing.Size(28, 13);
            this.labelPropType.TabIndex = 8;
            this.labelPropType.Text = "Tipo";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(66, 72);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(159, 25);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Salvar Edição";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // textboxProp2
            // 
            this.textboxProp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxProp2.Location = new System.Drawing.Point(66, 49);
            this.textboxProp2.Name = "textboxProp2";
            this.textboxProp2.Size = new System.Drawing.Size(159, 21);
            this.textboxProp2.TabIndex = 7;
            // 
            // labelProp2
            // 
            this.labelProp2.AutoSize = true;
            this.labelProp2.Location = new System.Drawing.Point(3, 53);
            this.labelProp2.Name = "labelProp2";
            this.labelProp2.Size = new System.Drawing.Size(61, 13);
            this.labelProp2.TabIndex = 6;
            this.labelProp2.Text = "LabelProp2";
            // 
            // labelProp1
            // 
            this.labelProp1.AutoSize = true;
            this.labelProp1.Location = new System.Drawing.Point(3, 28);
            this.labelProp1.Name = "labelProp1";
            this.labelProp1.Size = new System.Drawing.Size(61, 13);
            this.labelProp1.TabIndex = 5;
            this.labelProp1.Text = "LabelProp1";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(232, 304);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(225, 25);
            this.btnConfirm.TabIndex = 9;
            this.btnConfirm.Text = "Confirmar seleção";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(232, 330);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(225, 25);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.labelTitleSelection);
            this.panelMain.Controls.Add(this.panelEdition);
            this.panelMain.Controls.Add(this.labelTitleRegisters);
            this.panelMain.Controls.Add(this.btnCancel);
            this.panelMain.Controls.Add(this.treeviewRegisters);
            this.panelMain.Controls.Add(this.btnConfirm);
            this.panelMain.Controls.Add(this.treeviewSelected);
            this.panelMain.Location = new System.Drawing.Point(12, 82);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(460, 405);
            this.panelMain.TabIndex = 11;
            // 
            // AppCreateIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 491);
            this.Controls.Add(this.panelManualCMD);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppCreateIndex";
            this.Text = "Adicionar Endereços";
            this.panelManualCMD.ResumeLayout(false);
            this.panelManualCMD.PerformLayout();
            this.panelEdition.ResumeLayout(false);
            this.panelEdition.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelManualCMD;
        private System.Windows.Forms.TreeView treeviewRegisters;
        private System.Windows.Forms.TreeView treeviewSelected;
        private System.Windows.Forms.TextBox textboxAddress;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelTitleAddress;
        private System.Windows.Forms.Button btnAddAddress;
        private System.Windows.Forms.Label labelTitleRegisters;
        private System.Windows.Forms.Label labelTitleSelection;
        private System.Windows.Forms.TextBox textboxProp1;
        private System.Windows.Forms.Panel panelEdition;
        private System.Windows.Forms.Label labelProp1;
        private System.Windows.Forms.TextBox textboxProp2;
        private System.Windows.Forms.Label labelProp2;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label labelPropType;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox textboxBytes;
        private System.Windows.Forms.Label labelBytes;
        private System.Windows.Forms.Panel panelMain;
    }
}