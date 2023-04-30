using System;
using System.Collections.Generic;

namespace Comercializadora.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
}
