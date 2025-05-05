using System;
using System.Collections.Generic;

namespace AgriEnergyConnect.Data;

public partial class FarmingResource
{
    public int ResourceId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Type { get; set; }

    public int? UploadedBy { get; set; }

    public DateOnly? UploadDate { get; set; }

    public virtual User? UploadedByNavigation { get; set; }
}
