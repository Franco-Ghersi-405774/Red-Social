using System;
using System.Collections.Generic;

namespace RedSocialAPP.Models;

public partial class Amistade
{
    public int IdAmistad { get; set; }

    public int IdUsuario1 { get; set; }

    public int IdUsuario2 { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaSolicitud { get; set; }

    public virtual Usuario IdUsuario1Navigation { get; set; } = null!;

    public virtual Usuario IdUsuario2Navigation { get; set; } = null!;
}
