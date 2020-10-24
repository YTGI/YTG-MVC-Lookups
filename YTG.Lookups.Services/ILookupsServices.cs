// --------------------------------------------------------------------------------
/*  Copyright © 2020, Yasgar Technology Group, Inc.

	Purpose: Interface for proxy service to Lookups Web Service

	Description: 

*/
// --------------------------------------------------------------------------------

using System.Threading.Tasks;

using YTG.Models;

namespace YTG.Lookups.Services
{ 
    public interface ILookupsServices
    {

        Task<LuCategory> GetLuCategoryByIdAsync(long Id);
        Task<LuItem> GetLuItemByIdAsync(long Id);
        Task<LuItem> SetLuItemAsync(LuItem luItem);
        Task<LuCategory> SetLuCategoryAsync(LuCategory luCategory);
        Task<PagedResult<LuCategory>> GetCategoriesPagedAsync(int p_Page, int p_PageSize, string p_SearchTerm, string p_SearchFilter, string p_SortColumn,
                                                                                bool p_SortDescending, bool p_ActiveOnly);
        Task<PagedResult<LuItem>> GetItemsPagedAsync(long p_CatId, int p_Page, int p_PageSize, string p_SearchTerm, string p_SearchFilter, string p_SortColumn,
                                                                                bool p_SortDescending, bool p_ActiveOnly);
    }
}