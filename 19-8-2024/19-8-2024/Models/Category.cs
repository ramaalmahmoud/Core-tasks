using System;
using System.Collections.Generic;

namespace _19_8_2024.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
