using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RedSocialAPP.Models;

public partial class RedSocialFofoContext : DbContext
{
    public RedSocialFofoContext()
    {
    }

    public RedSocialFofoContext(DbContextOptions<RedSocialFofoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Amistade> Amistades { get; set; }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<Mensaje> Mensajes { get; set; }

    public virtual DbSet<Notificacione> Notificaciones { get; set; }

    public virtual DbSet<Publicacione> Publicaciones { get; set; }

    public virtual DbSet<TiposMensaje> TiposMensajes { get; set; }

    public virtual DbSet<TiposNotificacione> TiposNotificaciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-7TG7NN6\\SQLEXPRESS;Initial Catalog=RedSocialFofo;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Amistade>(entity =>
        {
            entity.HasKey(e => e.IdAmistad).HasName("PK__Amistade__EF48114F6AE0AB43");

            entity.Property(e => e.IdAmistad).HasColumnName("id_amistad");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasColumnName("estado");
            entity.Property(e => e.FechaSolicitud)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_solicitud");
            entity.Property(e => e.IdUsuario1).HasColumnName("id_usuario1");
            entity.Property(e => e.IdUsuario2).HasColumnName("id_usuario2");

            entity.HasOne(d => d.IdUsuario1Navigation).WithMany(p => p.AmistadeIdUsuario1Navigations)
                .HasForeignKey(d => d.IdUsuario1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Amistades_Usuario1");

            entity.HasOne(d => d.IdUsuario2Navigation).WithMany(p => p.AmistadeIdUsuario2Navigations)
                .HasForeignKey(d => d.IdUsuario2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Amistades_Usuario2");
        });

        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.IdComentario).HasName("PK__Comentar__1BA6C6F4CE3B53F7");

            entity.Property(e => e.IdComentario).HasColumnName("id_comentario");
            entity.Property(e => e.Contenido)
                .HasMaxLength(500)
                .HasColumnName("contenido");
            entity.Property(e => e.FechaComentario)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_comentario");
            entity.Property(e => e.IdPublicacion).HasColumnName("id_publicacion");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdPublicacionNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdPublicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentarios_Publicaciones");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentarios_Usuarios");
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => e.IdLike).HasName("PK__Likes__998412E8132DA4CA");

            entity.Property(e => e.IdLike).HasColumnName("id_like");
            entity.Property(e => e.FechaLike)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_like");
            entity.Property(e => e.IdObjeto).HasColumnName("id_objeto");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.TipoObjeto)
                .HasMaxLength(50)
                .HasColumnName("tipo_objeto");

            entity.HasOne(d => d.IdObjetoNavigation).WithMany(p => p.Likes)
                .HasForeignKey(d => d.IdObjeto)
                .HasConstraintName("FK_Likes_Comentarios");

            entity.HasOne(d => d.IdObjeto1).WithMany(p => p.Likes)
                .HasForeignKey(d => d.IdObjeto)
                .HasConstraintName("FK_Likes_Publicaciones");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Likes)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Likes_Usuarios");
        });

        modelBuilder.Entity<Mensaje>(entity =>
        {
            entity.HasKey(e => e.IdMensaje).HasName("PK__Mensajes__5B37C7F6FCE60025");

            entity.Property(e => e.IdMensaje).HasColumnName("id_mensaje");
            entity.Property(e => e.Contenido).HasColumnName("contenido");
            entity.Property(e => e.FechaEnvio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_envio");
            entity.Property(e => e.IdEmisor).HasColumnName("id_emisor");
            entity.Property(e => e.IdReceptor).HasColumnName("id_receptor");
            entity.Property(e => e.IdTipoMensaje).HasColumnName("id_tipo_mensaje");
            entity.Property(e => e.ImagenUrl)
                .HasMaxLength(255)
                .HasColumnName("imagen_url");

            entity.HasOne(d => d.IdEmisorNavigation).WithMany(p => p.MensajeIdEmisorNavigations)
                .HasForeignKey(d => d.IdEmisor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mensajes_Emisor");

            entity.HasOne(d => d.IdReceptorNavigation).WithMany(p => p.MensajeIdReceptorNavigations)
                .HasForeignKey(d => d.IdReceptor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mensajes_Receptor");

            entity.HasOne(d => d.IdTipoMensajeNavigation).WithMany(p => p.Mensajes)
                .HasForeignKey(d => d.IdTipoMensaje)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mensajes_TipoMensaje");
        });

        modelBuilder.Entity<Notificacione>(entity =>
        {
            entity.HasKey(e => e.IdNotificacion).HasName("PK__Notifica__8270F9A5C5E484D8");

            entity.Property(e => e.IdNotificacion).HasColumnName("id_notificacion");
            entity.Property(e => e.FechaNotificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_notificacion");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Leido)
                .HasDefaultValue(false)
                .HasColumnName("leido");
            entity.Property(e => e.TipoNotificacion).HasColumnName("tipo_notificacion");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notificaciones_Usuarios");

            entity.HasOne(d => d.TipoNotificacionNavigation).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.TipoNotificacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notificaciones_Tipos");
        });

        modelBuilder.Entity<Publicacione>(entity =>
        {
            entity.HasKey(e => e.IdPublicacion).HasName("PK__Publicac__7C3851735967361F");

            entity.Property(e => e.IdPublicacion).HasColumnName("id_publicacion");
            entity.Property(e => e.Contenido).HasColumnName("contenido");
            entity.Property(e => e.FechaPublicacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_publicacion");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Publicaciones)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Publicaciones_Usuarios");
        });

        modelBuilder.Entity<TiposMensaje>(entity =>
        {
            entity.HasKey(e => e.IdTipoMensaje).HasName("PK__Tipos_Me__71D178DA4A91C923");

            entity.ToTable("Tipos_Mensaje");

            entity.HasIndex(e => e.Descripcion, "UQ__Tipos_Me__298336B6FD5393FF").IsUnique();

            entity.Property(e => e.IdTipoMensaje).HasColumnName("id_tipo_mensaje");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<TiposNotificacione>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("PK__Tipos_No__CF901089BDEB1BEE");

            entity.ToTable("Tipos_Notificaciones");

            entity.Property(e => e.IdTipo).HasColumnName("id_tipo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__4E3E04AD153FB840");

            entity.HasIndex(e => e.Email, "UQ__Usuarios__AB6E6164C6BF5A5B").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Biografia)
                .HasMaxLength(500)
                .HasColumnName("biografia");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .HasColumnName("contraseña");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.FotoPerfil)
                .HasMaxLength(255)
                .HasColumnName("foto_perfil");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
