using System;
using System.Collections.Generic;

namespace Comercializadora.Models;

public partial class Movimiento
{
    public int Id { get; set; }

    public int? IdTercero { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdProducto { get; set; }

    public bool Estado { get; set; }

    public int? IdTipoMovimiento { get; set; }

    public int? Valor { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual Tercero? IdTerceroNavigation { get; set; }

    public virtual TipoMovimiento? IdTipoMovimientoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
