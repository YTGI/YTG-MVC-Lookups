// --------------------------------------------------------------------------------
/*  Copyright © 2020, Yasgar Technology Group, Inc.

    Purpose: Implementation of the ILookupsRep Lookups Repository methods

    Description: 

*/
// --------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Threading.Tasks;

using YTG.Lookups.Repository.Context;
using YTG.Lookups.Repository.Models;
using YTG.Models;

namespace YTG.Lookups.Repository
{
    public class LookupsRep : ILookupsRep
    {


        #region Constructors

        /// <summary>
        /// Default constructor with DI context
        /// </summary>
        /// <param name="context"></param>
        public LookupsRep(LookupsDBContext context)
        {
            LuContext = context;
        }

        #endregion // Constructors

        #region Properties

        /// <summary>
        /// Gets the LookupsDBContext for this repository
        /// </summary>
        private LookupsDBContext LuContext { get; }

        #endregion // Properties

        #region Methods

        /// <summary>
        /// Get a paged list of LuItems by CatId
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="CatId"></param>
        /// <param name="Page"></param>
        /// <param name="PageSize"></param>
        /// <param name="SearchTerm"></param>
        /// <param name="SearchFilter"></param>
        /// <param name="SortColumn"></param>
        /// <param name="SortOrder"></param>
        /// <param name="ActiveOnly"></param>
        /// <returns></returns>
        public async Task<PagedResult<LuItems>> GetLuItemsByEFAsync(long CatId, int Page,
                                                                            int PageSize,
                                                                            string SearchTerm,
                                                                            string SearchFilter,
                                                                            string SortColumn,
                                                                            string SortOrder,
                                                                            bool ActiveOnly)
        {
            try
            {
                int _skipRows = (Page - 1) * PageSize; // if this is not the first call, need move forward
                int _totalCount = 0; // placeholder for the total amount of records

                IQueryable<LuItems> _entityrows = (from item in LuContext.LuItems
                                                   where item.LuCatId == CatId
                                                   select item).AsNoTracking();

                if (ActiveOnly)
                {
                    // Showing how to use ActiveOnly without a boolean flag as an example
                    _entityrows = _entityrows.Where(er => er.IsActive == true);
                }

                if (!string.IsNullOrWhiteSpace(SearchFilter))
                {
                    // This can be customized for each implementation
                    _entityrows = _entityrows.Where(f => f.LuCode == SearchFilter);
                }

                if (!string.IsNullOrWhiteSpace(SearchTerm))
                {
                    // This can be customized for each implementation
                    _entityrows = _entityrows.Where(f => f.LuItemDesc.Contains(SearchTerm.Trim()));
                }

                // Getting count will execute a SELECT COUNT(*)
                // Like to do this before adding sort criteria
                _totalCount = _entityrows.Count();

                if (!string.IsNullOrWhiteSpace(SortColumn))
                {
                    bool IsSortDESC = false;
                    if (SortOrder.ToLower() == "desc") { IsSortDESC = true; }

                    _entityrows = _entityrows.OrderBy<Models.LuItems>(SortColumn, IsSortDESC);
                }

                _entityrows = _entityrows.Skip(_skipRows).Take(PageSize);

                return new PagedResult<Models.LuItems>(await _entityrows.ToListAsync(), _totalCount);



            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Simple Paged results from multiple tables in EF Query
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="Page"></param>
        /// <param name="PageSize"></param>
        /// <param name="SearchTerm"></param>
        /// <param name="SearchFilter"></param>
        /// <param name="SortColumn"></param>
        /// <param name="SortOrder"></param>
        /// <param name="ActiveOnly"></param>
        /// <returns></returns>
        public async Task<PagedResult<LuCategories>> GetLuCategoriesByEFAsync(int Page,
                                                                                int PageSize,
                                                                                string SearchTerm,
                                                                                string SearchFilter,
                                                                                string SortColumn,
                                                                                string SortOrder,
                                                                                bool ActiveOnly)
        {
            try
            {
                int _skipRows = (Page - 1) * PageSize; // if this is not the first call, need move forward
                int _totalCount = 0; // placeholder for the total amount of records

                // Using var because this is returning an anonymous type
                var _entityrows = (from item in LuContext.LuCategories.Include(a => a.LuItems)
                                   select item);

                if (ActiveOnly)
                {
                    // Showing how to use ActiveOnly without a boolean flag as an example
                    _entityrows = _entityrows.Where(er => er.IsActive == true);
                }

                if (!string.IsNullOrWhiteSpace(SearchFilter))
                {
                    // This can be customized for each implementation
                    _entityrows = _entityrows.Where(f => f.ShortName == SearchFilter);
                }

                if (!string.IsNullOrWhiteSpace(SearchTerm))
                {
                    // This can be customized for each implementation
                    _entityrows = _entityrows.Where(f => f.Name.Contains(SearchTerm.Trim()));
                }

                // Getting count will execute a SELECT COUNT(*)
                // Like to do this before adding sort criteria
                _totalCount = _entityrows.Count();


                if (!string.IsNullOrWhiteSpace(SortColumn))
                {
                    bool IsSortDESC = false;
                    if (SortOrder.ToLower() == "desc") { IsSortDESC = true; }

                    _entityrows = _entityrows.OrderBy(SortColumn, IsSortDESC);
                }

                _entityrows = _entityrows.Skip(_skipRows).Take(PageSize);

                return new PagedResult<Models.LuCategories>(await _entityrows.ToListAsync(), _totalCount);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get a single LuItem by ID
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="p_Id"></param>
        /// <returns></returns>
        public async Task<LuItems> GetLuItemByIdAsync(long p_Id)
        {
            return await (from li in LuContext.LuItems
                          where li.Id == p_Id
                          select li).AsNoTracking().FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get a single LuCategory by ID
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="p_Id"></param>
        /// <returns></returns>
        public async Task<LuCategories> GetLuCategoryIdAsync(long p_Id)
        {
            return await (from lc in LuContext.LuCategories
                          where lc.Id == p_Id
                          select lc).AsNoTracking().FirstOrDefaultAsync();
        }


        /// <summary>
        /// Save a LuCategories to the data store
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="p_Entity"></param>
        /// <returns></returns>
        public async Task<LuCategories> SetLuCategoriesAsync(LuCategories p_Entity)
        {
            if (p_Entity.Id > 0)
            {
                LuContext.Entry(p_Entity).State = EntityState.Modified;
            }
            else
            {
                LuContext.Entry(p_Entity).State = EntityState.Added;
            }

            await LuContext.SaveChangesAsync();

            return p_Entity;
        }

        /// <summary>
        /// Save a LuItems to the data store
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="p_Entity"></param>
        /// <returns></returns>
        public async Task<LuItems> SetLuItemsAsync(LuItems p_Entity)
        {
            if (p_Entity.Id > 0)
            {
                LuContext.Entry(p_Entity).State = EntityState.Modified;
            }
            else
            {
                LuContext.Entry(p_Entity).State = EntityState.Added;

            }

            await LuContext.SaveChangesAsync();

            return p_Entity;
        }

        #endregion // Methods

    }
}
