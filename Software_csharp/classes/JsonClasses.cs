using System.Collections.Generic;

public class JsonRoot {
    public string Version { get; set; }
    public string Description { get; set; }
    public List<MicrocontrollerDto> Microcontrollers { get; set; }
}

// DTOs (Data Transfer Objects) temporários para mapear o JSON perfeitamente
public class MicrocontrollerDto {
    public string Name { get; set; }
    public int ArchitectureBits { get; set; }
    public List<ModuleDto> Modules { get; set; }
}

public class ModuleDto {
    public string Name { get; set; }
    public string Code { get; set; } // Equivalente ao "sfr", "p12", etc.
    public List<RegisterDto> Registers { get; set; }
}

public class RegisterDto {
    public string Name { get; set; }
    public int Address { get; set; }
    public int Bits { get; set; }
}