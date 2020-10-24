// --------------------------------------------------------------------------------
/*  Copyright © 2020, Yasgar Technology Group, Inc.

    Purpose: Mapping Utilities for converting DTO types

    Description: Used to convert values from service to Models etc.
                 Hand coded for better performance than popular tools

*/
// --------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using YTG.Models;
using YTG.MVC.Lookups.Models;

namespace YTG.MVC.Lookups.Helpers
{
    public static class MappingUtils
    {


        /// <summary>
        /// Map an LuCategory to LuCategoryModel
        /// </summary>
        /// <param name="p_Cat"></param>
        /// <param name="p_DeepCopy"></param>
        /// <returns></returns>
        public static LuCategoryModel LuCatToLuCatModel(LuCategory p_Cat, bool p_DeepCopy = false)
        {
            LuCategoryModel _lcm = new LuCategoryModel();
            try
            {
                _lcm.Description = p_Cat.Description;
                _lcm.Name = p_Cat.Name;
                _lcm.ShortName = p_Cat.ShortName;
                _lcm.Id = p_Cat.Id;
                _lcm.IsActive = p_Cat.IsActive;

                // Set this in case the user wants to add an Item, we need to know the parent Id
                _lcm.Items.RefId = p_Cat.Id;

                if (p_DeepCopy)
                {
                    foreach (LuItem _item in p_Cat.Items)
                    {
                        _lcm.Items.SortedResults.Add(LuItemToLuItemModel(_item));
                    }
                }

                return _lcm;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Map an LuItem to LuItemModel
        /// </summary>
        /// <param name="p_In"></param>
        /// <returns></returns>
        public static LuItemModel LuItemToLuItemModel(LuItem p_In)
        {
            LuItemModel _Out = new LuItemModel();
            try
            {
                _Out.CategoryID = p_In.CategoryID;
                _Out.DateAdded = p_In.DateAdded;
                _Out.DateMod = p_In.DateMod;
                _Out.EnumValue = p_In.EnumValue;
                _Out.Id = p_In.Id;
                _Out.IsActive = p_In.IsActive;
                _Out.LUBoolean = p_In.LUBoolean;
                _Out.LUCode = p_In.LUCode;
                _Out.LUDate1 = p_In.LUDate1;
                _Out.LUDate2 = p_In.LUDate2;
                _Out.LUItemDescription = p_In.LUItemDescription;
                _Out.LUQuantity = p_In.LUQuantity;
                _Out.LUValue = p_In.LUValue;
                _Out.LUValue2 = p_In.LUValue2;

                return _Out;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Map an LuItemModel to LuItem
        /// </summary>
        /// <param name="p_In"></param>
        /// <returns></returns>
        public static LuItem LuItemModelToLuItem(LuItemModel p_In)
        {
            LuItem _Out = new LuItem();
            try
            {
                _Out.CategoryID = p_In.CategoryID;
                _Out.DateAdded = p_In.DateAdded;
                _Out.DateMod = p_In.DateMod;
                _Out.EnumValue = p_In.EnumValue;
                _Out.Id = p_In.Id;
                _Out.IsActive = p_In.IsActive;
                _Out.LUBoolean = p_In.LUBoolean;
                _Out.LUCode = p_In.LUCode;
                _Out.LUDate1 = p_In.LUDate1;
                _Out.LUDate2 = p_In.LUDate2;
                _Out.LUItemDescription = p_In.LUItemDescription;
                _Out.LUQuantity = p_In.LUQuantity;
                _Out.LUValue = p_In.LUValue;
                _Out.LUValue2 = p_In.LUValue2;

                return _Out;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Map an LuCategoryModel to an LuCatgory
        /// </summary>
        /// <param name="p_Cat"></param>
        /// <param name="p_DeepCopy"></param>
        /// <returns></returns>
        public static LuCategory LuCatModelToLuCat(LuCategoryModel p_Cat, bool p_DeepCopy = false)
        {
            LuCategory _lc = new LuCategory();
            try
            {
                _lc.Description = p_Cat.Description;
                _lc.Name = p_Cat.Name;
                _lc.ShortName = p_Cat.ShortName;
                _lc.Id = p_Cat.Id;
                _lc.IsActive = p_Cat.IsActive;

                if (p_DeepCopy)
                {
                    foreach (LuItemModel _item in p_Cat.Items.SortedResults)
                    {
                        _lc.Items.Add(_item);
                    }
                }

                return _lc;

            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}