// --------------------------------------------------------------------------------
/*  Copyright © 2020, Yasgar Technology Group, Inc.

    Purpose: Interface for Search Model

    Description: This is an interface for the SearchModel<TEntity>, it is needed
                 because it is the only way to use a generic type as a Model in 
                 a view that I've found.

*/
// --------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace YTG.MVC.Lookups.Models
{
    public interface ISearchModel
    {
        bool ActiveOnly { get; set; }
        int CurrentPage { get; set; }
        int EndPage { get; set; }
        int PageSize { get; set; }
        int RecordCount { get; set; }
        long RefId { get; set; }
        Guid RefUniqueId { get; set; }
        string SearchFilter { get; set; }
        string SearchTerm { get; set; }
        string SortColumn { get; set; }
        string PrevSortColumn { get; set; }
        bool SortDescending { get; set; }
        int StartPage { get; set; }
        int TotalItems { get; set; }
        int TotalPages { get; set; }

        // For Partial Views
        string controllerName { get; set; }
        string actionName { get; set; }


    }
}