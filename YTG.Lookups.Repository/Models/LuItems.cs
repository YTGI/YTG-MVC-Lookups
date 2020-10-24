// --------------------------------------------------------------------------------
/*  Copyright © 2020, Yasgar Technology Group, Inc.

    Purpose: DataContext models

    Description: This class is to mimic the LuItems object that would be created
                    as a class from a Scaffold-DbContext

    Any place where there is non-boilerplate code that is of interest, I have added
    comments.

*/
// --------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace YTG.Lookups.Repository.Models
{
    public partial class LuItems
    {
        public LuItems() { }

        public long Id { get; set; }
        public long LuCatId { get; set; }
        public string LuCode { get; set; }
        public string LuItemDesc { get; set; }
        public int EnumValue { get; set; }
        public string LuValue { get; set; }
        public string LuValue2 { get; set; }
        public bool? IsActive { get; set; }
        public bool? LuBoolean { get; set; }
        public long LuQuantity { get; set; }
        public DateTime? LuDate1 { get; set; }
        public DateTime? LuDate2 { get; set; }
        public string WhoMod { get; set; }
        public string WhoAdd { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateMod { get; set; }

        public virtual LuCategories LuCat { get; set; }
    }
}
