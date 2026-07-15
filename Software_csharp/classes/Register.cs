using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gerenciamento_memoria.classes {
    public class Register {
        public string Name { get; set; }
        public int Address { get; set; }
        public int Bits { get; set; }

        public Register(string name = "", int address = 0, int bits = 8) {
            Name = name;
            Address = address;
            Bits = bits;
        }
    }
}
