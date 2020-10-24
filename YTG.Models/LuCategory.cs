// --------------------------------------------------------------------------------
/*  Copyright © 2020, Yasgar Technology Group, Inc.

    Purpose: Implementation of the LuCategory object

    Description: Category properties and methods used for Lookups

*/
// --------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace YTG.Models
{

    /// <summary>
    /// Main Lookup Category
    /// </summary>
    public class LuCategory
    {

        #region Constructors

        /// <summary>
        /// Default constructor
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public LuCategory()
        { Id = -1; }

        #endregion // Constructors

        #region Fields

        private Lazy<List<LuItem>> m_LUItems = new Lazy<List<LuItem>>(() => new List<LuItem>(), true);

        #endregion // Fields

        #region Properties

        /// <summary>
        /// Gets or sets the PK Id for this Item
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the Unique Short Name of this Category
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public virtual string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the Name of this Category
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// The description of this category presented to users
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or sets whether this category is active
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public virtual bool IsActive { get; set; } = true;

        /// <summary>
        /// Gets or sets the list of LuItems associated with this Category
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public virtual List<LuItem> Items
        {
            get { return m_LUItems.Value; }
            set
            {
                m_LUItems = new Lazy<List<LuItem>>(() => value, true);
            }
        }

        /// <summary>
        /// Gets or sets the name of the user that added this value
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public string WhoAdded { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the user that last modified this value
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public string WhoMod { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date this item was added to the data store
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public DateTime DateAdded { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the date this item was last modified
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public DateTime DateMod { get; set; } = DateTime.Now;

        #endregion Properties

    }
}
