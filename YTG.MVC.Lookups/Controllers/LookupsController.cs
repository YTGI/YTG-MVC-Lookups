// --------------------------------------------------------------------------------
/*  Copyright © 2020, Yasgar Technology Group, Inc.

    Purpose: Contoller Methods for Lookups Views

    Description: 

*/
// --------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;

using System;
using System.Linq;
using System.Threading.Tasks;

using YTG.MVC.Lookups.Models;

using YTG.Models;
using YTG.Lookups.Services;

namespace YTG.MVC.Lookups.Controllers
{

    /// <summary>
    /// Yasgar Technology Group, Inc.
    /// http://www.ytgi.com
    /// </summary>
    public class LookupsController : Controller
    {

        /// <summary>
        /// Default constructor with Dependency Injection
        /// </summary>
        /// <param name="lookupsSvcs"></param>
        public LookupsController(ILookupsServices lookupsSvcs)
        {
            this.LookupsSvc = lookupsSvcs;
        }

        /// <summary>
        /// Read only property to hold injected instance
        /// </summary>
        public ILookupsServices LookupsSvc { get; }


        /// <summary>
        /// Index of categories paged
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchTerm"></param>
        /// <param name="sortFilter"></param>
        /// <param name="sortColumn"></param>
        /// <param name="sortDescending"></param>
        /// <param name="ActiveOnly"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 25, string searchTerm = "",
                                    string sortFilter = "", string sortColumn = "ShortName",
                                    bool sortDescending = false, bool ActiveOnly = true)
        {
            try
            {
                var _smlus = await GetCategoriesPagedAsync(page, pageSize, searchTerm, sortFilter,
                                                            sortColumn, sortDescending, ActiveOnly);

                return View(_smlus);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Called from the _CatDisplay partial view
        /// </summary>
        /// <param name="searchModelIn"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CatDisplay([FromBody] SearchModel<LuCategory> searchModelIn)
        {
            try
            {
                if (searchModelIn.SortColumn == searchModelIn.PrevSortColumn)
                {
                    // This click is on the same column, so we'll switch the order
                    searchModelIn.SortDescending = searchModelIn.SortDescending == false ? true : false;
                }

                var _smlus = await GetCategoriesPagedAsync(searchModelIn.CurrentPage, searchModelIn.PageSize, searchModelIn.SearchTerm,
                                                                                           searchModelIn.SearchFilter, searchModelIn.SortColumn,
                                                                                           searchModelIn.SortDescending, searchModelIn.ActiveOnly);

                return PartialView("_CatsDisplay", _smlus);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lookup item display controller with paging
        /// </summary>
        /// <param name="searchModelIn"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> ItemDisplay([FromBody] SearchModel<LuItem> searchModelIn)
        {
            try
            {
                if (searchModelIn.SortColumn == searchModelIn.PrevSortColumn)
                {
                    // This click is on the same column, so we'll switch the order
                    searchModelIn.SortDescending = searchModelIn.SortDescending == false ? true : false;
                }

                var _items = await GetItemsPagedAsync(searchModelIn.RefId, searchModelIn.CurrentPage, searchModelIn.PageSize,
                                                        searchModelIn.SearchTerm, searchModelIn.SearchFilter, searchModelIn.SortColumn,
                                                        searchModelIn.SortDescending, searchModelIn.ActiveOnly);

                return PartialView("_ItemsDisplay", _items);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Edit Category, with display of items
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Edit(long id, int pageSize = 25)
        {
            LuCategoryModel model = new LuCategoryModel();
            try
            {
                if (id >= 0)
                {
                    // Get the base LuCategory
                    LuCategory _return = await LookupsSvc.GetLuCategoryByIdAsync(id);

                    model = Helpers.MappingUtils.LuCatToLuCatModel(_return, false);

                    // Get a paged result of some items because we want a paged list of child items as well
                    model.Items = await GetItemsPagedAsync(id, 1, pageSize);
                }

                return View(model);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Post back of individual category
        /// </summary>
        /// <param name="catModel"></param>
        /// <param name="submitButton"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Edit(LuCategoryModel catModel, string submitButton)
        {
            long _intId = catModel.Id;
            LuCategory _luCat = Helpers.MappingUtils.LuCatModelToLuCat(catModel, false);

            try
            {
                // If you "name" your buttons as "submitButton" then you can grab the text
                // of the button here to make decisions on which button was clicked
                switch (submitButton)
                {
                    case "Save Category":
                        break;
                    case "Save As New*":
                        _luCat.Id = -1;
                        break;
                    case "Reset Screen":
                        return RedirectToAction("Edit", new { id = _luCat.Id });
                    case "Add New Item":
                        return RedirectToAction("EditItem", new { id = 0, catId = _luCat.Id });
                    default:
                        break;
                }

                _luCat = await LookupsSvc.SetLuCategoryAsync(_luCat);

                if (_intId < 0)
                {
                    return View(Helpers.MappingUtils.LuCatToLuCatModel(_luCat));
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }

        /// <summary>
        /// Edit individual item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> EditItem(long id, long catId = 0)
        {
            LuItem _lim = new LuItem();
            try
            {
                if (id >= 0)
                {
                    _lim = Helpers.MappingUtils.LuItemToLuItemModel(await LookupsSvc.GetLuItemByIdAsync(id));
                }
                else
                {
                    _lim.CategoryID = catId;
                }

                // Make sure and pass back the View Model
                return View("EditItem", Helpers.MappingUtils.LuItemToLuItemModel(_lim));

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Post back of individual item
        /// </summary>
        /// <param name="itemModel"></param>
        /// <param name="submitButton"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> EditItem(LuItemModel itemModel, string submitButton)
        {

            LuItem _luItem = Helpers.MappingUtils.LuItemModelToLuItem(itemModel);

            try
            {
                switch (submitButton)
                {
                    case "Save":
                        break;
                    case "Save As New":
                        _luItem.Id = -1;
                        break;
                    case "Reset Screen":
                        return RedirectToAction("EditItem", new { id = _luItem.Id });
                    default:
                        break;
                }

                _luItem = await LookupsSvc.SetLuItemAsync(_luItem);

                return RedirectToAction("Edit", new { id = _luItem.CategoryID });

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }

        /// <summary>
        /// Category search with paged results
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchTerm"></param>
        /// <param name="sortFilter"></param>
        /// <param name="sortColumn"></param>
        /// <param name="sortDescending"></param>
        /// <param name="ActiveOnly"></param>
        /// <returns></returns>
        public async Task<SearchModel<LuCategory>> GetCategoriesPagedAsync(int page = 1, int pageSize = 25, string searchTerm = "",
                                                            string searchFilter = "", string sortColumn = "ShortName",
                                                            bool sortDescending = false, bool ActiveOnly = true)
        {
            SearchModel<LuCategory> _smlus = new SearchModel<LuCategory>();
            try
            {

                PagedResult<LuCategory> _cats = await LookupsSvc.GetCategoriesPagedAsync(page, pageSize, searchTerm, searchFilter, sortColumn,
                                                                                               sortDescending, ActiveOnly);
                _smlus.TotalItems = _cats.TotalCount;
                _smlus.CurrentPage = page;
                _smlus.PageSize = pageSize;
                _smlus.RecordCount = _cats.Items.Count();
                _smlus.SortColumn = sortColumn;
                _smlus.SearchTerm = searchTerm;
                _smlus.SortDescending = sortDescending;
                _smlus.ActiveOnly = ActiveOnly;
                _smlus.SortedResults = _cats.Items.ToList();

                _smlus.actionName = "CatDisplay";
                _smlus.controllerName = "Lookups";

                return _smlus;

            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Get PageResult of LuItem
        /// </summary>
        /// <param name="catId"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchTerm"></param>
        /// <param name="searchFilter"></param>
        /// <param name="sortColumn"></param>
        /// <param name="sortDescending"></param>
        /// <param name="ActiveOnly"></param>
        /// <returns></returns>
        public async Task<SearchModel<LuItemModel>> GetItemsPagedAsync(long catId, int page = 1, int pageSize = 25, string searchTerm = "",
                                                                            string searchFilter = "", string sortColumn = "LuCode",
                                                                            bool sortDescending = false, bool ActiveOnly = true)
        {
            SearchModel<LuItemModel> _smlus = new SearchModel<LuItemModel>();
            try
            {

                PagedResult<LuItem> _result = await LookupsSvc.GetItemsPagedAsync(catId, page, pageSize, searchTerm, searchFilter, sortColumn, sortDescending, ActiveOnly);

                _smlus.TotalItems = _result.TotalCount;
                _smlus.CurrentPage = page;
                _smlus.PageSize = pageSize;
                _smlus.RecordCount = _result.Items.Count();
                _smlus.SortColumn = sortColumn;
                _smlus.SearchTerm = searchTerm;
                _smlus.SortDescending = sortDescending;
                _smlus.ActiveOnly = ActiveOnly;
                _smlus.RefId = catId;

                _smlus.controllerName = "Lookups";
                _smlus.actionName = "ItemDisplay";

                foreach (LuItem _item in _result.Items)
                {
                    _smlus.SortedResults.Add(Helpers.MappingUtils.LuItemToLuItemModel(_item));
                }

                return _smlus;

            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
