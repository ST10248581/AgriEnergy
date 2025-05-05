using System;
using System.Collections.Generic;

namespace AgriEnergyConnect.Data;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? RoleId { get; set; }

    public virtual ICollection<FarmingResource> FarmingResources { get; set; } = new List<FarmingResource>();

    public virtual ICollection<MarketplaceItem> MarketplaceItems { get; set; } = new List<MarketplaceItem>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual UserRole? Role { get; set; }
}
