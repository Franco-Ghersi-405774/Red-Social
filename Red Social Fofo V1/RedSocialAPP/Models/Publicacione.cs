using System;
using System.Collections.Generic;

namespace RedSocialAPP.Models;

public partial class Publicacione
{
    public int IdPublicacion { get; set; }

    public int IdUsuario { get; set; }

    public string? Contenido { get; set; }

    public DateTime? FechaPublicacion { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
}
