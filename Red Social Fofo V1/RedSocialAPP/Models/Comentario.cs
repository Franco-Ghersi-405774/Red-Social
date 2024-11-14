﻿using System;
using System.Collections.Generic;

namespace RedSocialAPP.Models;

public partial class Comentario
{
    public int IdComentario { get; set; }

    public int IdPublicacion { get; set; }

    public int IdUsuario { get; set; }

    public string Contenido { get; set; } = null!;

    public DateTime? FechaComentario { get; set; }

    public virtual Publicacione IdPublicacionNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
}
