using System;
using System.Collections.Generic;

namespace AgriEnergyConnect.Data;

public partial class Review
{
    public int ReviewId { get; set; }

    public int? UserId { get; set; }

    public int? ItemId { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public DateOnly? ReviewDate { get; set; }

    public virtual MarketplaceItem? Item { get; set; }

    public virtual User? User { get; set; }
}
