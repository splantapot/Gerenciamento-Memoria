using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gerenciamento_memoria.classes {
    public class Microcontroller {
        public string Name { get; set; }
        public int ArchitectureBits { get; set; }
        public List<Module> Modules { get; set; }

        public Microcontroller(string name, int architectureBits = 16, List<Module> modules = null) {
            Name = name;
            ArchitectureBits = architectureBits;
            Modules = modules ?? new List<Module>();
        }

        public void AddModule(Module module) {
            Modules.Add(module);
        }

        public void RemoveModule(Module module) {
            Modules.Remove(module);
        }

        public void RemoveModuleByModuleID(string moduleID) {
            var module = GetModuleByModuleID(moduleID);
            if (module != null) {
                Modules.Remove(module);
            }
        }

        public void ClearModules() {
            Modules.Clear();
        }

        public Module GetModuleByModuleID(string moduleID) {
            return Modules.FirstOrDefault(m => m.ModuleID == moduleID);
        }
    }
}
