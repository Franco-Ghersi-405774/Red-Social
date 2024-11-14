using System;
using System.Collections.Generic;

namespace RedSocialAPP.Models;

public partial class Like
{
    public int IdLike { get; set; }

    public int IdUsuario { get; set; }

    public int IdObjeto { get; set; }

    public string? TipoObjeto { get; set; }

    public DateTime? FechaLike { get; set; }

    public virtual Publicacione IdObjeto1 { get; set; } = null!;

    public virtual Comentario IdObjetoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
