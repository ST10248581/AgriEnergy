using System;
using System.Collections.Generic;

namespace AgriEnergyConnect.Data;

public partial class MarketplaceItem
{
    public int ItemId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Type { get; set; }

    public int? ProviderId { get; set; }

    public decimal? Price { get; set; }

    public virtual User? Provider { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
