// --------------------------------------------------------------------------------
/*  Copyright © 2020, Yasgar Technology Group, Inc.
	Any unauthorized review, use, disclosure or distribution is prohibited.

	Purpose: Provide proxy service to Lookups Web Service, implementing ILookupsService

	Description: This would normally be where the UI component calls a web service
                 to retrieve the data, however, this demo app uses the Repository
                 class directly.

*/
// --------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using YTG.Lookups.Repository;
using YTG.Models;
using YTG.Lookups.Repository.Models;

namespace YTG.Lookups.Services
{
    public class LookupsServices : IDisposable, ILookupsServices
    {


        #region Constructors

        /// <summary>
        /// Default constructor ILookupsRep
        /// </summary>
        /// <param name="lookupsRep"></param>
        public LookupsServices(ILookupsRep lookupsRep)
        {
            this.LookupsRep = lookupsRep;
        }

        #endregion // Constructors

        #region Fields

        // Flag: Has Dispose already been called?
        bool disposed = false;

        #endregion // Fields

        #region Properties

        /// <summary>
        /// Gets the reference to the LookupsRep DI object
        /// </summary>
        public ILookupsRep LookupsRep { get; set; }

        #endregion // Properties

        #region Methods

        /// <summary>
        /// Get LuCategory by Id
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<LuCategory> GetLuCategoryByIdAsync(long Id)
        {
            try
            {
                if (Id > 0)
                {
                    LuCategories _result = await LookupsRep.GetLuCategoryIdAsync(Id);

                    LuCategory _item = MappingUtils.RCatToSCat(_result, false);

                    return _item;
                }
                else
                {
                    throw new Exception("Id is required!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get LuItem by Id
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<LuItem> GetLuItemByIdAsync(long Id)
        {
            try
            {
                if (Id > 0)
                {
                    LuItems _result = await LookupsRep.GetLuItemByIdAsync(Id);

                    LuItem _item = MappingUtils.RItemToSItem(_result);

                    return _item;
                }
                else
                {
                    throw new Exception("Id is required!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Set a LuItem to the service
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="luItem"></param>
        /// <returns></returns>
        public async Task<LuItem> SetLuItemAsync(LuItem luItem)
        {
            try
            {
                if (luItem != null)
                {
                    LuItems _toSave = MappingUtils.SItemToRItem(luItem);

                    LuItems _result = await LookupsRep.SetLuItemsAsync(_toSave);

                    LuItem _item = MappingUtils.RItemToSItem(_result);

                    return _item;
                }
                else
                {
                    throw new Exception("LuItem was null!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Set a LuCategory to the service
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="luCategory"></param>
        /// <returns></returns>
        public async Task<LuCategory> SetLuCategoryAsync(LuCategory luCategory)
        {
            try
            {
                if (luCategory != null)
                {
                    LuCategories _toSave = MappingUtils.SCatToRCat(luCategory);

                    LuCategories _result = await LookupsRep.SetLuCategoriesAsync(_toSave);

                    LuCategory _item = MappingUtils.RCatToSCat(_result);

                    return _item;
                }
                else
                {
                    throw new Exception("LuCategory was null!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get PagedResult of LuCategory
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="p_Page"></param>
        /// <param name="p_PageSize"></param>
        /// <param name="p_SearchTerm"></param>
        /// <param name="p_SearchFilter"></param>
        /// <param name="p_SortColumn"></param>
        /// <param name="p_SortDescending"></param>
        /// <param name="p_ActiveOnly"></param>
        /// <returns></returns>
        public async Task<PagedResult<LuCategory>> GetCategoriesPagedAsync(int p_Page, int p_PageSize, string p_SearchTerm, string p_SearchFilter, string p_SortColumn,
                                                                        bool p_SortDescending, bool p_ActiveOnly)
        {
            List<LuCategory> _items = new List<LuCategory>();
            try
            {
                string _sortOrder = p_SortDescending ? "desc" : "asc";

                PagedResult<LuCategories> _result = await this.LookupsRep.GetLuCategoriesByEFAsync(p_Page, p_PageSize, p_SearchTerm, p_SearchFilter, p_SortColumn, _sortOrder, p_ActiveOnly);

                foreach (LuCategories _item in _result.Items)
                {
                    _items.Add(MappingUtils.RCatToSCat(_item, true));
                }

                PagedResult<LuCategory> _return = new PagedResult<LuCategory>(_items, _result.TotalCount);

                return _return;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get PagedResult of LuItem
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="p_Page"></param>
        /// <param name="p_PageSize"></param>
        /// <param name="p_SearchTerm"></param>
        /// <param name="p_SearchFilter"></param>
        /// <param name="p_SortColumn"></param>
        /// <param name="p_SortDescending"></param>
        /// <param name="p_ActiveOnly"></param>
        /// <returns></returns>
        public async Task<PagedResult<LuItem>> GetItemsPagedAsync(long p_CatId, int p_Page, int p_PageSize, string p_SearchTerm, string p_SearchFilter, string p_SortColumn,
                                                                        bool p_SortDescending, bool p_ActiveOnly)
        {
            List<LuItem> _items = new List<LuItem>();
            try
            {
                int _skip = (p_PageSize * (p_Page - 1));
                string _sortOrder = p_SortDescending ? "desc" : "asc";

                PagedResult<LuItems> _result = await this.LookupsRep.GetLuItemsByEFAsync(p_CatId, p_Page, p_PageSize, p_SearchTerm, p_SearchFilter, 
                                                                                                                p_SortColumn, _sortOrder, p_ActiveOnly);

                foreach (LuItems _item in _result.Items)
                {
                    _items.Add(MappingUtils.RItemToSItem(_item));
                }

                PagedResult<LuItem> _return = new PagedResult<LuItem>(_items, _result.TotalCount);

                return _return;

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion // Methods

        #region IDisoposable

        /// <summary>
        /// Implementation of the IDisposable interface
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Protected implementation of Dispose pattern.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Get rid of resources here

            }

            disposed = true;
        }

        #endregion // IDisposable


    }
}
