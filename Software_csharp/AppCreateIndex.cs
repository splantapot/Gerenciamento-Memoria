using gerenciamento_memoria.classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gerenciamento_memoria {
    public partial class AppCreateIndex : Form {

        // Default constructor for creation nodes
        private const string NEW_REGISTER_NODE_TEXT = "Adicionar Registrador";
        private const string NEW_REGISTER_NODE_TAG = "NoVoReGiStRaDor";
        private const string NEW_REGISTER_NAME = "Registrador";

        private const string NEW_MODULE_NODE_TEXT = "Adicionar Módulo";
        private const string NEW_MODULE_NODE_TAG = "NoVoMoDuLo";
        private const string NEW_MODULE_NAME = "Modulo";

        private const string CUSTOM_ADDRESS = "Personalizado";

        private const bool ENABLE_EDITING = false;
        private object edit_object = null;
        public bool isSimpleCommand;

        // Control variables
        private readonly List<Microcontroller> microcontrollers = new List<Microcontroller>();
        public readonly List<Register> selected_registers = new List<Register>();

        public AppCreateIndex(bool only_manual = false) {
            InitializeComponent();
            isSimpleCommand = only_manual;

            if (isSimpleCommand) {
                panelMain.Visible = false;
                this.Text = "Adicionar N Bytes a partir de Endereço";
                this.Size = new Size(530, 200);
            } else {

                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "registers.json");

                if (File.Exists(jsonPath)) {
                    AppRegisters_FromJson(jsonPath);
                } else {
                    MessageBox.Show("O arquivo .json de importaçao não foi encontrado.\nVerifique se o arquivo 'registers.json' está no mesmo diretório deste '.exe'.\nOs dados pré-configurados serão carregados.");
                    AppRegisters_DevData();
                }

                EnableEditing();

                // Settings for the Registers treeview.
                treeviewRegisters.LabelEdit = false; // Disabled. Enabled only when the user presses the EDIT key.
                treeviewRegisters.NodeMouseDoubleClick += treeviewRegisters_NodeMouseDoubleClick;
                treeviewRegisters.BeforeLabelEdit += TreeviewRegisters_BeforeLabelEdit;
                treeviewRegisters.AfterLabelEdit += TreeviewRegisters_AfterLabelEdit;
                treeviewRegisters.KeyDown += TreeviewRegisters_KeyDown;

                // Settings for the Selected treeview.
                treeviewSelected.LabelEdit = false;
                treeviewSelected.NodeMouseDoubleClick += treeviewRegisters_NodeMouseDoubleClick;

                RenderTreeView();
            }
        }

        private void EnableEditing() {
            textboxProp1.Enabled = ENABLE_EDITING;
            textboxProp2.Enabled = ENABLE_EDITING;
            btnEdit.Visible = ENABLE_EDITING;
        }

        /* ====================================  */
        /* Development use only                  */
        /* ====================================  */
        private void AppRegisters_DevData() {
            List<Module> modules = new List<Module>();
            // Creates modules and his registers 
            Microcontroller msp430g2553 = new Microcontroller("MSP430G2553", modules: modules, architectureBits: 16);
            int bits = msp430g2553.ArchitectureBits;

            Module uart = new Module("Special Function", "sfr");
            Register IE1 = new Register("IE1", 0x00, bits);
            Register IFG1 = new Register("IFG1", 0x02, bits);
            uart.AddRegister(IE1);
            uart.AddRegister(IFG1);

            Module p12 = new Module("Ports 1 and 2", "p12");
            Register P1IN = new Register("P1IN", 0x01, bits);
            Register P1OUT = new Register("P1OUT", 0x12, bits);
            p12.AddRegister(P1IN);
            p12.AddRegister(P1OUT);

            Module wdt = new Module("Watchdog Timer", "wdt");
            Register WDTCTL = new Register("WDTCTL", 0x6900, bits);
            wdt.AddRegister(WDTCTL);

            modules.Add(uart);
            modules.Add(p12);
            modules.Add(wdt);

            microcontrollers.Add(msp430g2553);
        }

        /* ====================================  */
        /* Renderer for the tree                 */
        /* ====================================  */
        private void RenderTreeView(object itemEdited = null) {

            BoxHide();  // Hide the edition box by default

            // Renderer for Microcontrollers treeview. ------------------------
            treeviewRegisters.Nodes.Clear();

            // Creating the treeview
            foreach (Microcontroller microcontroller in microcontrollers) {
                TreeNode microNode = treeviewRegisters.Nodes.Add(microcontroller.Name);
                microNode.Tag = microcontroller;
                //int bits = microcontroller.ArchitectureBits;
                //string format = "X" + (bits / 4).ToString();
                foreach (Module module in microcontroller.Modules) {
                    TreeNode moduleNode = microNode.Nodes.Add(module.Name);
                    moduleNode.Tag = module;    // Save the Module as Tag object

                    foreach (Register register in module.Registers) {
                        int bits = register.Bits;
                        string format = "X" + (bits / 4).ToString();

                        TreeNode registerNode = moduleNode.Nodes.Add(
                            $"{register.Name} (0x{register.Address.ToString(format)})"
                        );

                        // Store the register object in the Tag property of the TreeNode
                        registerNode.Tag = register;

                        // Open tree if it a REGISTER has been edited
                        if (itemEdited is Register registerEdited && register == registerEdited) {
                            registerNode.EnsureVisible();
                            treeviewRegisters.SelectedNode = registerNode;
                        }
                    }

                    if (itemEdited is Module moduleEdited && module == moduleEdited) {
                        moduleNode.EnsureVisible();
                        treeviewRegisters.SelectedNode = moduleNode;
                    }

                    if (ENABLE_EDITING) {
                        TreeNode newRegisterNode = moduleNode.Nodes.Add(NEW_REGISTER_NODE_TEXT);
                        newRegisterNode.Tag = $"{module.Code}:{NEW_REGISTER_NODE_TAG}";
                    }
                }

                if (ENABLE_EDITING) {
                    TreeNode newModuleNode = microNode.Nodes.Add(NEW_MODULE_NODE_TEXT);
                    newModuleNode.Tag = $"{microcontroller.Name}:{NEW_MODULE_NODE_TAG}";
                }
            }

            // Renderer for Selected treeview. ------------------------
            treeviewSelected.Nodes.Clear();
            selected_registers.ForEach(register => {
                int bits = register.Bits;
                string format = "X" + (bits / 4).ToString();
                TreeNode registerNode = treeviewSelected.Nodes.Add(
                    $"{register.Name} (0x{register.Address.ToString(format)})"
                );
                registerNode.Tag = register;
            });
            // USED BEFORE THE REGISTERS LIST
            // Creating the treeview. Build for filtering only the selected registers. 
            //microcontrollers.ForEach(microcontroller => {
            //    bool microHasSelectedRegisters = microcontroller.Modules.Any(module => module.Registers.Any(register => register.Selected));
            //    if (microHasSelectedRegisters) {
            //        TreeNode microNode = treeviewSelected.Nodes.Add(microcontroller.Name);
            //        int bits = microcontroller.ArchitectureBits;
            //        string format = "X" + (bits / 4).ToString();

            //        microcontroller.Modules.ForEach(module => {
            //            bool moduleHasSelectedRegisters = module.Registers.Any(register => register.Selected);
            //            if (moduleHasSelectedRegisters) {
            //                TreeNode moduleNode = microNode.Nodes.Add(module.Name);
            //                module.Registers.ForEach(register => {
            //                    if (register.Selected) {
            //                        TreeNode registerNode = moduleNode.Nodes.Add(
            //                            $"{register.Name} (0x{register.Address.ToString(format)})"
            //                        );
            //                        registerNode.Tag = register;
            //                    }
            //                });
            //            }
            //        });
            //    }
            //});

            treeviewSelected.ExpandAll();
        }

        private void AddRegisterToModule(string moduleID) {
            Register newReg = new Register(NEW_REGISTER_NAME);
            Microcontroller micro = microcontrollers.FirstOrDefault(m => m.Modules.Any(mod => mod.Code == moduleID));
            if (micro != null) {
                Module module = micro.GetModuleByModuleID(moduleID);
                if (module != null) {
                    int qnt_registers = module.Registers.Count;
                    newReg.Name += (qnt_registers + 1).ToString();
                    newReg.Bits = micro.ArchitectureBits;
                    module.AddRegister(newReg);
                }
            }
            RenderTreeView(newReg);
        }

        private void AddModuleToMicrocontroller(string microName) {
            Microcontroller micro = microcontrollers.FirstOrDefault(m => m.Name == microName);
            if (micro != null) {
                int qnt_modules = micro.Modules.Count;
                Module newModule = new Module(NEW_MODULE_NAME + (qnt_modules + 1).ToString(), $"new_mod_{qnt_modules + 1}");
                micro.AddModule(newModule);
                RenderTreeView(newModule);
            }
        }
        
        private void SelectRegister(Register register) {
            if (selected_registers.Contains(register)) {
                selected_registers.Remove(register);
            } else {
                selected_registers.Add(register);
            }
            RenderTreeView(register);
        }

        /* ====================================  */
        /* Events                                */
        /* ====================================  */

        // When select a node
        private void treeviewRegisters_AfterSelect(object sender, TreeViewEventArgs e) {
            TreeNode selectedNode = e.Node;
            BoxEditable(selectedNode);
        }

        // Double click event
        private void treeviewRegisters_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
            TreeNode selectedNode = e.Node;

            bool isRegisterSelectedNode = e.Node != null && e.Node.Level==0 && e.Node.Tag is Register;

            if (IsRegisterNode(selectedNode) || isRegisterSelectedNode) {
                // Click in Register Nodes
                if (selectedNode.Tag is string tagFromNode && tagFromNode.Contains(NEW_REGISTER_NODE_TAG)) {
                    // Its a "New Register" node, so we create a new register and add it to the module
                    string moduleID = tagFromNode.Split(':')[0];
                    AddRegisterToModule(moduleID);

                } else if (selectedNode.Tag is Register register) {
                    // Toggle the selection state of the register when double-clicked
                    SelectRegister(register);
                }
            } else if (IsModuleNode(selectedNode)) {
                // Click in Module Nodes
                if (selectedNode.Tag is string tagFromNode && tagFromNode.Contains(NEW_MODULE_NODE_TAG)) {
                    // Its a "New Module" node, so we add it to microcontroller. For now, we will create a new module with a default name and ID.
                    string microName = tagFromNode.Split(':')[0];
                    AddModuleToMicrocontroller(microName);
                }
            }
        }

        // KeyDown event
        // Events related to edit, creation and deletion of registers in the treeview
        private void TreeviewRegisters_KeyDown(object sender, KeyEventArgs e) {
            TreeNode selectedNode = treeviewRegisters.SelectedNode;
            bool isRegister = IsRegisterNode(selectedNode);
            bool isModule = IsModuleNode(selectedNode);
            bool isEditable = IsEditableNode(selectedNode); // Check if the selected node
            string tagFromNode = selectedNode?.Tag as string;

            if (isRegister) {
                if (ENABLE_EDITING && e.KeyCode == Keys.E) {
                    // Edit register name and address
                    treeviewRegisters.LabelEdit = true;
                    selectedNode.BeginEdit();
                } else if (e.KeyCode == Keys.Enter) {
                    if (isEditable) {
                        // Toggle the selection state of the register when Enter is pressed
                        if (selectedNode.Tag is Register register) {
                            SelectRegister(register);
                        }
                    } else {
                        string moduleID = tagFromNode.Split(':')[0];
                        AddRegisterToModule(moduleID);
                    }
                }
            } else if (isModule) {
                if (ENABLE_EDITING && e.KeyCode == Keys.E && e.Modifiers == Keys.Shift) {
                    // Edit module name
                    treeviewRegisters.LabelEdit = true;
                    selectedNode.BeginEdit();
                } else if (!isEditable && e.KeyCode == Keys.Enter) {
                    string microName = tagFromNode.Split(':')[0];
                    AddModuleToMicrocontroller(microName);
                }
            }
        }

        private void textboxManual_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                btnAddAddress_Click(this, new EventArgs());
                e.SuppressKeyPress = true;
            }
        }

        // BeforeLabelEdit event
        // Triggers before the user starts editing
        private void TreeviewRegisters_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e) {
            TreeNode selectedNode = e.Node;
            if (!IsRegisterNode(selectedNode) && !IsModuleNode(selectedNode)) {
                e.CancelEdit = true;
                return;
            }
        }

        // AfterLabelEdit event
        // Triggers after the user finishes editing. Used to validation and update memory values.
        private void TreeviewRegisters_AfterLabelEdit(object sender, NodeLabelEditEventArgs e) {
            treeviewRegisters.LabelEdit = false;

            if (e.Label == null) {
                return;
            }

            TreeNode selectedNode = e.Node;

            // If the node is not a Register or Module, cancel the edit
            if (!IsEditableNode(e.Node)) {
                e.CancelEdit = true;
                return;
            }

            // Validation for Register nodes
            if (IsRegisterNode(selectedNode)) {
                if (!IsValidRegisterName(e.Label)) {
                    MessageBox.Show("Formato inválido! Use o padrão:\nNOME SEPARADOR ENDEREÇO\nExemplos:\nREGISTRADOR (0x1A)\nREGISTRADOR-1A\n*Caracteres especiais (acentuação) não são permitidos.",
                                "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.CancelEdit = true;
                    return;
                }

                Register regOriginal = (Register)e.Node.Tag;
                if (regOriginal != null) {
                    char[] separators = new char[] { ' ', '-', ',', ';', '|', '/' };
                    string[] values = e.Label.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    // Cleans the str to keep only the hexadecimal number, removing any unwanted characters
                    string addressStr = values[values.Length - 1]
                        .Replace("(", "").Replace(")", "")
                        .Replace("[", "").Replace("]", "")
                        .Replace("{", "").Replace("}", "")
                        .Replace("0x", "").Replace("0X", "");
                    string newName = string.Join(" ", values.Take(values.Length - 1));
                    // Try Parse str to int, considering it is a hexadecimal number
                    if (!int.TryParse(addressStr, System.Globalization.NumberStyles.HexNumber, null, out int newAddress)) {
                        MessageBox.Show("Endereço hexadecimal inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.CancelEdit = true;
                        return;
                    }
                    // Updates the original register object with the new values
                    regOriginal.Name = newName;
                    regOriginal.Address = newAddress;
                    // Cancels the edit to render the treeview with the updated values
                    e.CancelEdit = true;
                    BeginInvoke(new Action(() => RenderTreeView(regOriginal)));
                }
            } else if (IsModuleNode(selectedNode)) {
                if (!IsValidModuleName(e.Label)) {
                    MessageBox.Show("Formato inválido! Insira um nome não nulo.",
                                    "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.CancelEdit = true;
                    return;
                }

                Module moduleOriginal = (Module)e.Node.Tag;
                if (moduleOriginal != null) {
                    string newName = e.Label;
                    moduleOriginal.Name = newName;
                    // Cancels the edit to render the treeview with the updated values
                    e.CancelEdit = true;
                    BeginInvoke(new Action(() => RenderTreeView(moduleOriginal)));
                }
            }

        }

        private void btnAddAddress_Click(object sender, EventArgs e) {

            if (string.IsNullOrEmpty(textboxAddress.Text)) {
                MessageBox.Show("Insira um endereço.");
                return;
            }

            if (string.IsNullOrEmpty(textboxBytes.Text)) {
                MessageBox.Show("Insira a quantidade de bytes.");
                return;
            }

            string addressInput = textboxAddress.Text.Trim();
            string bytesInput = textboxBytes.Text.Trim();

            int numericAddress;
            int byteLength;
            int bitLength;

            try {
                if (addressInput.StartsWith("0x", StringComparison.OrdinalIgnoreCase)) {
                    numericAddress = Convert.ToInt32(addressInput.Substring(2), 16);
                } else if (System.Text.RegularExpressions.Regex.IsMatch(addressInput, @"^[0-9a-fA-F]+$")) {
                    numericAddress = Convert.ToInt32(addressInput, 16);
                } else {
                    numericAddress = Convert.ToInt32(addressInput, 10);
                }
            } catch (FormatException) {
                MessageBox.Show("Formato de endereço inválido. Verifique o valor digitado (Hex).", "Erro de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } catch (OverflowException) {
                MessageBox.Show("O valor do endereço é muito grande (causou overflow em 32 bits).", "Erro de Estouro (Overflow)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try {
                byteLength = Convert.ToInt32(bytesInput, 10);
                if (byteLength <= 0 || byteLength > 8) {
                    MessageBox.Show("Por favor, insira uma quantidade de bytes válida (1 a 8).", "Bytes Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                bitLength = byteLength * 8;
            } catch {
                MessageBox.Show("A quantidade de bytes deve ser um número decimal válido.", "Erro de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Register newReg = new Register(CUSTOM_ADDRESS, numericAddress, bitLength);
            selected_registers.Add(newReg);

            if (isSimpleCommand) {
                string mensagem = $"Confirmar alocação de {byteLength} bytes a partir do endereço (0x{numericAddress:X})?";
                DialogResult resposta = MessageBox.Show(mensagem, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resposta == DialogResult.Yes) {
                    DialogResult = DialogResult.OK;
                    Close();
                } else {
                    selected_registers.Clear();
                }
            } else {
                textboxAddress.Clear();
                textboxBytes.Clear();
                RenderTreeView();
            }
        }


        /* ====================================  */
        /* Edition control functions             */
        /* ====================================  */

        private void BoxHide() {
            panelEdition.Visible = false;
        }

        private void BoxEditable(TreeNode node) {
            bool isEditable = IsEditableNode(node);
            if (!isEditable) return;

            panelEdition.Visible = true;
            edit_object = node.Tag;

            if (IsRegisterNode(node) && node.Tag is Register editRegister) {
                labelPropType.Text = "Registrador";
                labelProp1.Text = "Nome:";
                textboxProp1.Text = editRegister.Name;
                labelProp1.Visible = textboxProp1.Visible = true;
                labelProp2.Text = "Endereço:";
                textboxProp2.Text = $"0x{editRegister.Address}";
                labelProp2.Visible = labelProp2.Visible = true;

            } else if (IsModuleNode(node) && node.Tag is Module module) {
                labelPropType.Text = "Módulo";
                labelProp1.Text = "Nome:";
                textboxProp1.Text = module.Name;
                labelProp1.Visible = textboxProp1.Visible = true;
                labelProp2.Text = "ID:";
                textboxProp2.Text = module.Code;
                labelProp2.Visible = textboxProp2.Visible = true;
            } else if (IsMicrocontrollerNode(node) && node.Tag is Microcontroller micro) {
                labelPropType.Text = "Microcontrolador";
                labelProp1.Text = "Nome:";
                textboxProp1.Text = micro.Name;
                labelProp1.Visible = textboxProp1.Visible = true;
                labelProp2.Visible = textboxProp2.Visible = false;
            }
        }

        /* ====================================  */
        /* Validation functions                  */
        /* ====================================  */
        private bool IsRegisterNode(TreeNode node) {
            return node!=null && node.Level == 2 && node.Nodes.Count == 0;
        }

        private bool IsModuleNode(TreeNode node) {
            return node!=null && node.Level == 1;
        }

        private bool IsMicrocontrollerNode(TreeNode node) {
            return node != null && node.Level == 0;
        }

        private bool IsEditableNode(TreeNode node) {
            return (node!=null) && (node.Tag is Register || node.Tag is Module || node.Tag is Microcontroller);
        }

        private bool IsValidRegisterName(string text) {
            if (string.IsNullOrWhiteSpace(text)) return false;

            // Regex explicada:
            // ^[a-zA-Z0-9_]+         -> Nome do registrador (letras, números e underlines)
            // [\s\-,;|\/]+           -> Separador (espaço, hífen, vírgula, ponto e vírgula, barra vertical, barra)
            // [(\[{]?                -> Abertura opcional de parênteses/colchetes/chaves
            // (?:0[xX])?[0-9A-Fa-f]+ -> Endereço hexadecimal (0x opcional + dígitos hex)
            // [)\]}]?$               -> Fechamento opcional e fim da string ($)
            string padrao = @"^[a-zA-Z0-9_]+[\s\-,;|\/]+[(\[{]?(?:0[xX])?[0-9A-Fa-f]+[)\]}]?$";

            return Regex.IsMatch(text.Trim(), padrao);
        }

        private bool IsValidModuleName(string text) {
            return !string.IsNullOrWhiteSpace(text);
        }

        /* ====================================  */
        /* Confirm event                         */
        /* ====================================  */
        private void btnConfirm_Click(object sender, EventArgs e) {
            if (selected_registers.Count <= 0) {
                MessageBox.Show("Nenhum registrador foi selecionado.\nA operação será cancelada");
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void AppRegisters_FromJson(string filePath) {
            try {
                string jsonString = File.ReadAllText(filePath);

                var options = new JsonSerializerOptions {
                    PropertyNameCaseInsensitive = true
                };

                JsonRoot data = JsonSerializer.Deserialize<JsonRoot>(jsonString, options);

                if (data?.Microcontrollers == null) return;

                foreach (var microDto in data.Microcontrollers) {
                    if (string.IsNullOrWhiteSpace(microDto.Name) || microDto.ArchitectureBits <= 0) {
                        Console.WriteLine("Aviso: Ignorando microcontrolador inválido no JSON.");
                        continue;
                    }

                    List<Module> modules = new List<Module>();
                    Microcontroller micro = new Microcontroller(
                        microDto.Name,
                        modules: modules,
                        architectureBits: microDto.ArchitectureBits
                    );

                    if (microDto.Modules == null) continue;

                    foreach (var modDto in microDto.Modules) {
                        if (string.IsNullOrWhiteSpace(modDto.Name) || string.IsNullOrWhiteSpace(modDto.Code)) {
                            Console.WriteLine($"Aviso: Ignorando módulo inválido no microcontrolador {micro.Name}.");
                            continue;
                        }

                        Module module = new Module(modDto.Name, modDto.Code);
                        if (modDto.Registers != null) {
                            foreach (var regDto in modDto.Registers) {
                                if (string.IsNullOrWhiteSpace(regDto.Name) || regDto.Address < 0) {
                                    Console.WriteLine($"Aviso: Ignorando registrador inválido no módulo {module.Name}.");
                                    continue;
                                }
                                int regBits = regDto.Bits > 0 ? regDto.Bits : micro.ArchitectureBits;
                                Register register = new Register(regDto.Name, regDto.Address, regBits);
                                module.AddRegister(register);
                            }
                        }

                        modules.Add(module);
                    }

                    microcontrollers.Add(micro);
                }
            } catch (FileNotFoundException) {
                Console.WriteLine($"Erro: O arquivo '{filePath}' não foi encontrado. Carregando dados padrão...");
                AppRegisters_DevData(); // Fallback de segurança
            } catch (JsonException ex) {
                Console.WriteLine($"Erro crítico de sintaxe no JSON: {ex.Message}. Carregando dados padrão...");
                AppRegisters_DevData(); // Fallback de segurança
            } catch (Exception ex) {
                // Captura qualquer outro erro inesperado (ex: falta de permissão de leitura do arquivo)
                Console.WriteLine($"Erro inesperado ao carregar dados: {ex.Message}");
            }
        }
    }
}