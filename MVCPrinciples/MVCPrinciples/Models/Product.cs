using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCPrinciples.Models;

public partial class Product
{
    public int ProductId { get; set; }

    [Required]
    public string ProductName { get; set; } = null!;

    [Required]
    public int? SupplierId { get; set; }

    [Required]
    public int? CategoryId { get; set; }

    [Required]
    [MaxLength(100)]
    public string? QuantityPerUnit { get; set; }

    [DataType(DataType.Currency)]
    public decimal? UnitPrice { get; set; }

    public short? UnitsInStock { get; set; }

    public short? UnitsOnOrder { get; set; }

    public short? ReorderLevel { get; set; }

    public bool Discontinued { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Supplier? Supplier { get; set; }
}
