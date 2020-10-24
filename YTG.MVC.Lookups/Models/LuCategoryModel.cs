// --------------------------------------------------------------------------------
/*  Copyright © 2020, Yasgar Technology Group, Inc.
    Any unauthorized review, use, disclosure or distribution is prohibited.

    Purpose: View model for the LuCategory

    Description: 

*/
// --------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;

using YTG.Models;
using YTG.Models.Code;

namespace YTG.MVC.Lookups.Models
{

    /// <summary>
    /// LuCategory View Model 
    /// </summary>
    public class LuCategoryModel : LuCategory
    {

        /// <summary>
        /// Gets the backing property as a Lazy instantiation for LuItemModel collection
        /// </summary>
        private Lazy<SearchModel<LuItemModel>> m_luItems = new Lazy<SearchModel<LuItemModel>>(() => new SearchModel<LuItemModel>(), true);


        [Required]
        [Display(Name = "Category Short Name: ")]
        [StringLength(50, ErrorMessage = "Category Short Name Minimum Length is 5 Characters, 50 Maximum", MinimumLength = 5)]
        public override string ShortName
        {
            get { return base.ShortName; }
            set { base.ShortName = value; }
        }

        [Required]
        [Display(Name = "Category Name: ")]
        [StringLength(100, ErrorMessage = "Category Name Minimum Length is 5 Characters, 100 Maximum", MinimumLength = 5)]
        public override string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        [Required]
        [Display(Name = "Category Description: ")]
        [StringLength(255, ErrorMessage = "Category Description Minimum Length is 5 Characters, 255 Maximum", MinimumLength = 5)]
        public override string Description
        {
            get { return base.Description; }
            set { base.Description = value; }
        }

        [Display(Name = "Category is Active")]
        public override bool IsActive
        {
            get { return base.IsActive; }
            set { base.IsActive = value; }
        }

        public new SearchModel<LuItemModel> Items
        {
            get { return m_luItems.Value; }
            set { m_luItems = new Lazy<SearchModel<LuItemModel>>(() => value, true); }
        }

    }

    /// <summary>
    /// LuItem View Model
    /// </summary>
    public class LuItemModel : LuItem
    {

        [Required]
        [Display(Name = "Lookup Item Code: ")]
        [StringLength(50, ErrorMessage = "Lookup Item Code is Required! Maximum Length is 100 Characters", MinimumLength = 5)]
        public override string LUCode
        {
            get { return base.LUCode; }
            set { base.LUCode = value; }
        }

        [Display(Name = "Item Description: ")]
        [StringLength(256, ErrorMessage = "Item Description Minimum Length is 5 Characters, 256 Maximum", MinimumLength = 5)]
        public override string LUItemDescription
        {
            get { return base.LUItemDescription; }
            set { base.LUItemDescription = value; }
        }

        [Display(Name = "Enum Value: ")]
        public override int EnumValue
        {
            get { return base.EnumValue; }
            set { base.EnumValue = value; }
        }

        [Display(Name = "Lookup Item Value: ")]
        [StringLength(1024, ErrorMessage = "Lookup Value Maximum Length is 1024 Characters")]
        public override string LUValue
        {
            get { return base.LUValue; }
            set { base.LUValue = value; }
        }

        [Display(Name = "Lookup Item Value 2: ")]
        [StringLength(1024, ErrorMessage = "Lookup Value 2 Maximum Length is 1024 Characters")]
        public override string LUValue2
        {
            get { return base.LUValue2; }
            set { base.LUValue2 = value; }
        }

        [Display(Name = "Active: ")]
        public override bool IsActive
        {
            get { return base.IsActive; }
            set { base.IsActive = value; }
        }

        [Display(Name = "Boolean: ")]
        public override bool LUBoolean
        {
            get { return base.LUBoolean; }
            set { base.LUBoolean = value; }
        }

        [Display(Name = "Quantity: ")]
        public override long LUQuantity
        {
            get { return base.LUQuantity; }
            set { base.LUQuantity = value; }
        }

        [Display(Name = "Date 1: ")]
        public override DateTime LUDate1
        {
            get { return base.LUDate1; }
            set { base.LUDate1 = value; }
        }

        /// <summary>
        /// Date 1 Display
        /// Use to get rid of 01/01/0001 displays
        /// </summary>
        [Display(Name = "Date 1: ")]
        public string LUDate1Display
        {
            get
            {
                return LUDate1.ToShortDateTimeDisplay();
            }
            set
            {
                LUDate1 = value.ToDateFromString();
            }
        }


        [Display(Name = "Date 2: ")]
        public override DateTime LUDate2
        {
            get { return base.LUDate2; }
            set { base.LUDate2 = value; }
        }

        /// <summary>
        /// Date 2 Display
        /// Use to get rid of 01/01/0001 displays
        /// </summary>
        [Display(Name = "Date 2: ")]
        public string LUDate2Display
        {
            get
            {
                return LUDate2.ToShortDateTimeDisplay();
            }
            set
            {
                LUDate2 = value.ToDateFromString();
            }
        }


        [Display(Name = "Date Added: ")]
        public override DateTime DateAdded
        {
            get { return base.DateAdded; }
            set { base.DateAdded = value; }
        }

        [Display(Name = "Date Mod: ")]
        public override DateTime DateMod
        {
            get { return base.DateMod; }
            set { base.DateMod = value; }
        }

    }


}