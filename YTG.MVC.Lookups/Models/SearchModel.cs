// --------------------------------------------------------------------------------
/*  Copyright © 2020, Yasgar Technology Group, Inc.
    Any unauthorized review, use, disclosure or distribution is prohibited.

    Purpose: Paged Results and Search Model Implementation

    Description: 

*/
// --------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace YTG.MVC.Lookups.Models
{

    /// <summary>
    /// View Model for Searching and holding results
    /// </summary>
    public class SearchModel<TEntity> : ISearchModel
    {

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public SearchModel() { }


        public SearchModel(int totalItems, int? page, int pageSize = 10)
        {
            TotalItems = totalItems;
            CurrentPage = page ?? 1;
            PageSize = pageSize;
        }

        #endregion // Constructors

        #region Fields

        private int m_TotalItems = 0;
        private int m_CurrentPage = 1;
        private int m_PageSize = 0;
        private Lazy<List<TEntity>> m_SortedResults = new Lazy<List<TEntity>>(() => new List<TEntity>(), true);

        #endregion // Fields

        #region Properties

        /// <summary>
        /// Gets or set the total number of items to be paged
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public int TotalItems
        {
            get
            { return m_TotalItems; }
            set
            {
                m_TotalItems = value;
                if (m_PageSize > 0)
                { TotalPages = (m_TotalItems + (m_PageSize - 1)) / m_PageSize; }
            }
        }

        /// <summary>
        /// Gets or sets the current page being displayed
        /// Automatically populates the values of other properties
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public int CurrentPage
        {
            get
            { return m_CurrentPage; }
            set
            {
                m_CurrentPage = value < 1 ? 1 : value;
                StartPage = m_CurrentPage - 5;
                EndPage = m_CurrentPage + 4;

                if (StartPage <= 0)
                {
                    EndPage -= (StartPage - 1);
                    StartPage = 1;
                }

                if (EndPage > TotalPages)
                {
                    EndPage = TotalPages;
                    if (EndPage > 10)
                    {
                        StartPage = EndPage - 9;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the page size currently set
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public int PageSize
        {
            get
            { return m_PageSize; }
            set
            {
                m_PageSize = value;
                if (m_TotalItems > 0)
                { TotalPages = (m_TotalItems + (m_PageSize - 1)) / m_PageSize; }
                // To get EndPage set correctly if this property is set last
                CurrentPage = m_CurrentPage;
            }
        }

        /// <summary>
        /// Gets or set the total number of pages based on the TotalItems and PageSize
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public int TotalPages { get; set; } = 0;

        /// <summary>
        /// Gets or sets the start page for the pager display
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public int StartPage { get; set; } = 0;

        /// <summary>
        /// Gets or sets the end page for the pager display
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public int EndPage { get; set; } = 0;

        /// <summary>
        /// Gets or sets the search filter for the paged items
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public string SearchFilter { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the search term for the paged items
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public string SearchTerm { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the sort expression for the paged items
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public string SortColumn { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the previous sort expression for the paged items when posting back to controller
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public string PrevSortColumn { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the count of records in the current page
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public int RecordCount { get; set; } = 0;

        /// <summary>
        /// Gets or sets the sort order, default is asc
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public bool SortDescending { get; set; } = false;

        /// <summary>
        /// Gets or sets whether the paged items only contain active records
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        [Display(Name = "Active Only")]
        public bool ActiveOnly { get; set; } = true;

        /// <summary>
        /// Gets or sets the Reference Id, to be used for a parent object
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public long RefId { get; set; } = 0;

        /// <summary>
        /// Gets or sets the Reference Unique Id, to be used for a parent object
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public Guid RefUniqueId { get; set; } = Guid.Empty;

        /// <summary>
        /// Gets or sets the List of pre-sorted results
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public List<TEntity> SortedResults
        {
            get { return m_SortedResults.Value; }
            set
            {
                m_SortedResults = new Lazy<List<TEntity>>(() => value, true);
            }
        }


        /// <summary>
        /// Gets or sets the controller name for this Model
        /// Needed for Pagination partial views
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public string controllerName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the action name for this model
        /// Needed for Pagination partial views
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        public string actionName { get; set; } = string.Empty;

        #endregion // Properties

        #region Methods
        #endregion // Methods

        #region Events
        #endregion // Events

    }

}