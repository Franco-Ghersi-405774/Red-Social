using System;
using System.Collections.Generic;

namespace RedSocialAPP.Models;

public partial class Mensaje
{
    public int IdMensaje { get; set; }

    public int IdEmisor { get; set; }

    public int IdReceptor { get; set; }

    public string? Contenido { get; set; }

    public string? ImagenUrl { get; set; }

    public int IdTipoMensaje { get; set; }

    public DateTime? FechaEnvio { get; set; }

    public virtual Usuario IdEmisorNavigation { get; set; } = null!;

    public virtual Usuario IdReceptorNavigation { get; set; } = null!;

    public virtual TiposMensaje IdTipoMensajeNavigation { get; set; } = null!;
}
