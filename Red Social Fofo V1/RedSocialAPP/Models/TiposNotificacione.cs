using System;
using System.Collections.Generic;

namespace RedSocialAPP.Models;

public partial class TiposNotificacione
{
    public int IdTipo { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Notificacione> Notificaciones { get; set; } = new List<Notificacione>();
}
