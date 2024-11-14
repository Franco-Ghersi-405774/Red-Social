using System;
using System.Collections.Generic;

namespace RedSocialAPP.Models;

public partial class TiposMensaje
{
    public int IdTipoMensaje { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Mensaje> Mensajes { get; set; } = new List<Mensaje>();
}
