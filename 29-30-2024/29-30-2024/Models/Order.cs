using System;
using System.Collections.Generic;

namespace _29_30_2024.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? OrderDate { get; set; }

    public virtual User? User { get; set; }
}
