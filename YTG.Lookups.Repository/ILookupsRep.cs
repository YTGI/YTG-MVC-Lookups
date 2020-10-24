// --------------------------------------------------------------------------------
/*  Copyright © 2020, Yasgar Technology Group, Inc.

    Purpose: Interface for Lookups Repository methods

    Description: 

*/
// --------------------------------------------------------------------------------

using System.Threading.Tasks;
using YTG.Lookups.Repository.Models;
using YTG.Models;

namespace YTG.Lookups.Repository
{
    public interface ILookupsRep
    {

        Task<PagedResult<LuCategories>> GetLuCategoriesByEFAsync(int Page,
                                                                    int PageSize,
                                                                    string SearchTerm,
                                                                    string SearchFilter,
                                                                    string SortColumn,
                                                                    string SortOrder,
                                                                    bool ActiveOnly);
        Task<PagedResult<LuItems>> GetLuItemsByEFAsync(long CatId, int Page,
                                                            int PageSize,
                                                            string SearchTerm,
                                                            string SearchFilter,
                                                            string SortColumn,
                                                            string SortOrder,
                                                            bool ActiveOnly);

        Task<LuCategories> GetLuCategoryIdAsync(long p_Id);
        Task<LuItems> GetLuItemByIdAsync(long p_Id);
        Task<LuCategories> SetLuCategoriesAsync(LuCategories p_Entity);
        Task<LuItems> SetLuItemsAsync(LuItems p_Entity);

    }
}