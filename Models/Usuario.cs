using System;
using System.Collections.Generic;

namespace Comercializadora.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Codigo { get; set; }

    public string? Documento { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public bool Estado { get; set; }

    public int? IdTipoUsuario { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual TipoUsuario? IdTipoUsuarioNavigation { get; set; }
   
    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
}
