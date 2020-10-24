// --------------------------------------------------------------------------------
/*  Copyright © 2020, Yasgar Technology Group, Inc.

    Purpose: Mapping utilities to convert repository (database) object to business
             DTO models

    Description: 

*/
// --------------------------------------------------------------------------------

using System;
using System.Linq;

using YTG.Models;
using YTG.Models.Code;

namespace YTG.Lookups.Services
{
    public static class MappingUtils
    {

        /// <summary>
        /// Convert an repository LuCategories to an LuCategory
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="p_In"></param>
        /// <param name="p_DeepCopy"></param>
        /// <param name="p_MaxItems"></param>
        /// <returns></returns>
        public static LuCategory RCatToSCat(Repository.Models.LuCategories p_In, bool p_DeepCopy = false)
        {

            LuCategory _out = new LuCategory();

            if (p_In != null)
            {
                _out.Id = p_In.Id;
                _out.ShortName = p_In.ShortName;
                _out.Description = p_In.Description;
                _out.Name = p_In.Name;
                _out.IsActive = p_In.IsActive ?? true;

                _out.DateAdded = p_In.DateAdded;
                _out.DateMod = p_In.DateMod;
                _out.WhoAdded = p_In.WhoAdd;
                _out.WhoMod = p_In.WhoMod;

                if (p_DeepCopy) // Copy the child items
                {
                    if (p_In.LuItems != null)
                    {
                        foreach (var item in p_In.LuItems.OrderBy(i => i.EnumValue).ThenBy(l => l.LuValue))
                        {
                            _out.Items.Add(RItemToSItem(item));
                        }
                    }
                }
            }

            return _out;

        }

        /// <summary>
        /// Convert an LuCategory to a repository LuCategory
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="p_In"></param>
        /// <returns></returns>
        public static Repository.Models.LuCategories SCatToRCat(LuCategory p_In)
        {

            Repository.Models.LuCategories _out = new Repository.Models.LuCategories();

            if (p_In != null)
            {
                if (p_In.Id > 0) { _out.Id = p_In.Id; }
             
                _out.ShortName = p_In.ShortName;
                _out.Description = p_In.Description;
                _out.Name = p_In.Name;
                _out.IsActive = p_In.IsActive;
                _out.WhoAdd = p_In.WhoAdded;
                _out.WhoMod = p_In.WhoMod;
                _out.DateAdded = p_In.DateAdded;
                _out.DateMod = p_In.DateMod;

                foreach (var item in p_In.Items)
                {
                    _out.LuItems.Add(SItemToRItem(item));
                }
            }

            return _out;

        }

        /// <summary>
        /// Convert an LuItem to a repository LuItems
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="p_In"></param>
        /// <returns></returns>
        public static Repository.Models.LuItems SItemToRItem(LuItem p_In)
        {

            Repository.Models.LuItems _out = new Repository.Models.LuItems();

            if (p_In != null)
            {

                if (p_In.Id > 0) { _out.Id = p_In.Id; }

                _out.LuCatId = p_In.CategoryID;
                _out.DateAdded = (p_In.DateAdded == null ? DateTime.MinValue : p_In.DateAdded);
                _out.DateMod = (p_In.DateMod == null ? DateTime.MinValue : p_In.DateMod);
                _out.EnumValue = p_In.EnumValue;
                _out.IsActive = p_In.IsActive;
                _out.LuBoolean = p_In.LUBoolean;
                _out.LuCode = p_In.LUCode;
                _out.LuDate1 = (p_In.LUDate1 == null ? DateTime.MinValue : p_In.LUDate1);
                _out.LuDate2 = (p_In.LUDate2 == null ? DateTime.MinValue : p_In.LUDate2);
                _out.LuItemDesc = p_In.LUItemDescription;
                _out.LuQuantity = p_In.LUQuantity;
                _out.LuValue = p_In.LUValue;
                _out.LuValue2 = p_In.LUValue2;
                _out.WhoAdd = p_In.WhoAdded;
                _out.WhoMod = p_In.WhoMod;
            }

            return _out;

        }

        /// <summary>
        /// Convert a repository LuItems to an LuItem
        /// Yasgar Technology Group, Inc. - www.ytgi.com
        /// </summary>
        /// <param name="p_In"></param>
        /// <returns></returns>
        public static LuItem RItemToSItem(Repository.Models.LuItems p_In)
        {

            LuItem _out = new LuItem();

            if (p_In != null)
            {
                _out.CategoryID = p_In.LuCatId;
                _out.DateAdded = p_In.DateAdded;
                _out.DateMod = p_In.DateMod;
                _out.EnumValue = p_In.EnumValue;
                _out.Id = p_In.Id;
                _out.IsActive = p_In.IsActive ?? true;
                _out.LUBoolean = p_In.LuBoolean ?? false;
                _out.LUCode = p_In.LuCode;
                _out.LUDate1 = (p_In.LuDate1 ?? DateTime.MinValue);
                _out.LUDate2 = (p_In.LuDate2 ?? DateTime.MinValue);
                _out.LUItemDescription = p_In.LuItemDesc;
                _out.LUQuantity = p_In.LuQuantity;
                _out.LUValue = p_In.LuValue;
                _out.LUValue2 = p_In.LuValue2;
                _out.WhoAdded = p_In.WhoAdd;
                _out.WhoMod = p_In.WhoMod;

            }

            return _out;

        }

    }
}