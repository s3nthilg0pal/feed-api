using System;
using System.Collections.Generic;

namespace Infrastructure;

public partial class Tag
{
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string? Name { get; set; }
}
