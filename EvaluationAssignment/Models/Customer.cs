using System;
using System.Collections.Generic;

namespace EvaluationAssignment.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public decimal CustomerType { get; set; }

    public decimal Mobile { get; set; }
}
