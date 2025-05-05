using System;
using System.Collections.Generic;

namespace AgriEnergyConnect.Data;

public partial class UserRole
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public bool? CanAddProducts { get; set; }

    public bool? CanAddFarmerProfiles { get; set; }

    public bool? CanViewAndFilterProducts { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
