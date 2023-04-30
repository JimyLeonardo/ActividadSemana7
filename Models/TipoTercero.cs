using System;
using System.Collections.Generic;

namespace Comercializadora.Models;

public partial class TipoTercero
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual ICollection<Tercero> Terceros { get; set; } = new List<Tercero>();
}
