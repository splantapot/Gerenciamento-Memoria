using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gerenciamento_memoria.classes {
    public class Module {
        public string Name { get; set; }
        public string Code { get; set; }
        public List<Register> Registers { get; set; }
        public Module(string name, string code) {
            Name = name;
            Code = code;
            Registers = new List<Register>();
        }

        public void AddRegister(Register register) {
            Registers.Add(register);
        }

        public void RemoveRegister(Register register) {
            Registers.Remove(register);
        }

        public void RemoveRegisterByName(string name) {
            var register = GetRegisterByName(name);
            if (register != null) {
                Registers.Remove(register);
            }
        }

        public void ClearRegisters() {
            Registers.Clear();
        }

        public Register GetRegisterByName(string name) {
            return Registers.FirstOrDefault(r => r.Name == name);
        }

        public Register GetRegisterByAddress(int address) {
            return Registers.FirstOrDefault(r => r.Address == address);
        }

        public List<Register> GetAllRegisters() {
            return Registers;
        }
    }
}
