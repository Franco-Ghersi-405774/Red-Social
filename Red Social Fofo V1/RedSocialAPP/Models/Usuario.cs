using System;
using System.Collections.Generic;

namespace RedSocialAPP.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    public string? Biografia { get; set; }

    public string? FotoPerfil { get; set; }

    public virtual ICollection<Amistade> AmistadeIdUsuario1Navigations { get; set; } = new List<Amistade>();

    public virtual ICollection<Amistade> AmistadeIdUsuario2Navigations { get; set; } = new List<Amistade>();

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual ICollection<Mensaje> MensajeIdEmisorNavigations { get; set; } = new List<Mensaje>();

    public virtual ICollection<Mensaje> MensajeIdReceptorNavigations { get; set; } = new List<Mensaje>();

    public virtual ICollection<Notificacione> Notificaciones { get; set; } = new List<Notificacione>();

    public virtual ICollection<Publicacione> Publicaciones { get; set; } = new List<Publicacione>();
}
