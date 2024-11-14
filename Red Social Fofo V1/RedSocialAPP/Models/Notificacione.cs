using System;
using System.Collections.Generic;

namespace RedSocialAPP.Models;

public partial class Notificacione
{
    public int IdNotificacion { get; set; }

    public int IdUsuario { get; set; }

    public int TipoNotificacion { get; set; }

    public bool? Leido { get; set; }

    public DateTime? FechaNotificacion { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual TiposNotificacione TipoNotificacionNavigation { get; set; } = null!;
}
