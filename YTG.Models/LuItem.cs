// --------------------------------------------------------------------------------
/*  Copyright © 2020, Yasgar Technology Group, Inc.

    Purpose: Lookup Item Implementation

    Description: Hold the properties of a lookup item

*/
// --------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace YTG.Models
{
    public class LuItem
    {

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public LuItem()
        { Id = -1; }

        #endregion // Constructors

        #region Fields
        #endregion // Fields

        #region Properties

        /// <summary>
        /// Gets or sets the PK Id for this Item
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the Category ID this LU Item is part of
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public virtual long CategoryID { get; set; }

        /// <summary>
        /// Gets or sets the Unique Look Up Code under this category ID
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public virtual string LUCode { get; set; }

        /// <summary>
        /// Gets or sets the Look Up Description
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public virtual string LUItemDescription { get; set; }

        /// <summary>
        /// Gets or sets the Enumeration Value for this Look Up Item. Used for ordering.
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public virtual int EnumValue { get; set; }

        /// <summary>
        /// Gets or sets the Value of this Look Up Item
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public virtual string LUValue { get; set; }

        /// <summary>
        /// Gets or sets the secondary Value for this Look Up Item
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public virtual string LUValue2 { get; set; }

        /// <summary>
        /// Gets or sets whether this Look Up Item is active
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public virtual bool IsActive { get; set; } = true;

        /// <summary>
        /// Gets or sets a Boolean value for this look up item
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public virtual bool LUBoolean { get; set; }

        /// <summary>
        /// Gets or sets the Look Up Item Quantity
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public virtual long LUQuantity { get; set; }

        /// <summary>
        /// Gets or sets the Look Up Date 
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public virtual DateTime LUDate1 { get; set; }

        /// <summary>
        /// Gets or sets the Look Up Date
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public virtual DateTime LUDate2 { get; set; }

        /// <summary>
        /// Gets or sets the name of the user that added this value
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public virtual string WhoAdded { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the user that last modified this value
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public virtual string WhoMod { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date this item was added to the data store
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public virtual DateTime DateAdded { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the date this item was last modified
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public virtual DateTime DateMod { get; set; } = DateTime.Now;

        #endregion // Properties


    }
}
