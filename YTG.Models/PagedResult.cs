// --------------------------------------------------------------------------------
/*  Copyright © 2020, Yasgar Technology Group, Inc.

    Purpose: Implementation of the IPagedResult interface

    Description: A DTO to carry responses from the Service Layer behind a web
                 service back to the UI with details needed for paging

*/
// --------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace YTG.Models
{

    /// <summary>
    /// Yasgar Technology Group, Inc.
    /// http://www.ytgi.com
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class PagedResult<TEntity> : IPagedResult<TEntity>
    {

        #region Constructors

        /// <summary>
        /// Primary constructor
        /// </summary>
        /// <param name="items"></param>
        /// <param name="totalCount"></param>
        public PagedResult(List<TEntity> items, int totalCount)
        {
            Items = items;
            TotalCount = totalCount;
        }

        #endregion // Constructors

        #region Fields

        private Lazy<List<TEntity>> m_items = new Lazy<List<TEntity>>(() => new List<TEntity>(), true);

        #endregion // Fields

        #region Properties

        /// <summary>
        /// IEnumerable list of items returned
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public List<TEntity> Items
        {
            get { return m_items.Value; }
            set
            {
                m_items = new Lazy<List<TEntity>>(() => value, true);
            }
    }

        /// <summary>
        /// Total count of records from query
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public int TotalCount { get; set; } = 0;

        #endregion // Properties

    }
}
