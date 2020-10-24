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
    public class TestModel
    {

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public TestModel() { }

        #endregion // Constructors

        #region Fields

        private int m_TotalItems = 0;
        private int m_CurrentPage = 1;
        private int m_PageSize = 0;

        #endregion // Fields

        #region Properties

        /// <summary>
        /// Gets or set the total number of items to be paged
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
                // To get EndPage set correctly
                CurrentPage = m_CurrentPage;
            }
        }

        /// <summary>
        /// Gets or set the total number of pages based on the TotalItems and PageSize
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Gets or sets the start page for the pager display
        /// </summary>
        public int StartPage { get; set; }

        /// <summary>
        /// Gets or sets the end page for the pager display
        /// </summary>
        public int EndPage { get; set; }

        /// <summary>
        /// Gets or sets the search filter for the paged items
        /// </summary>
        public string SearchFilter { get; set; }

        /// <summary>
        /// Gets or sets the search term for the paged items
        /// </summary>
        public string SearchTerm { get; set; }

        /// <summary>
        /// Gets or sets the sort expression for the paged items
        /// </summary>
        public string SortColumn { get; set; }

        /// <summary>
        /// Gets or sets the previous sort expression for the paged items when posting back to controller
        /// </summary>
        public string PrevSortColumn { get; set; }

        /// <summary>
        /// Gets or sets the count of records in the current page
        /// </summary>
        public int RecordCount { get; set; }

        /// <summary>
        /// Gets or sets the sort order, default is asc
        /// </summary>
        public bool SortDescending { get; set; }

        /// <summary>
        /// Gets or sets whether the paged items only contain active records
        /// </summary>
        [Display(Name = "Active Only")]
        public bool ActiveOnly { get; set; }

        /// <summary>
        /// Gets or sets the Reference Id, to be used for a parent object
        /// </summary>
        public long RefId { get; set; }

        /// <summary>
        /// Gets or sets the Reference Unique Id, to be used for a parent object
        /// </summary>
        public Guid RefUniqueId { get; set; }


        /// <summary>
        /// Gets or sets the controller name for this Model
        /// Needed for Pagination partial views
        /// </summary>
        public string controllerName { get; set; }

        /// <summary>
        /// Gets or sets the action name for this model
        /// Needed for Pagination partial views
        /// </summary>
        public string actionName { get; set; }

        #endregion // Properties

        #region Methods
        #endregion // Methods

        #region Events
        #endregion // Events

    }

}