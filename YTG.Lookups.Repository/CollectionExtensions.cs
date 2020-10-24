// --------------------------------------------------------------------------------
/*  Copyright © 2020, Yasgar Technology Group, Inc.
    Any unauthorized review, use, disclosure or distribution is prohibited.

    Purpose: Collection Extension Method needed for this project 

    Description: This is an extension method from our internal shared
                    library that is used in this project repository

*/
// --------------------------------------------------------------------------------


using System;
using System.Linq;
using System.Linq.Expressions;

namespace YTG.Lookups.Repository
{
    public static class CollectionExtensions
    {


        /// <summary>
        /// Implementation of OrderBy Extension Method for IQueryable Collections
        /// </summary>
        /// <typeparam name="TEntity">Generic Type Object</typeparam>
        /// <param name="p_Source">The collection to order</param>
        /// <param name="p_OrderByProperty">The property to order by</param>
        /// <param name="p_Descending">True to sort Descending</param>
        /// <returns></returns>
        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> p_Source, string p_OrderByProperty, bool p_Descending)
        {
            try
            {
                string command = p_Descending ? "OrderByDescending" : "OrderBy";
                var type = typeof(TEntity);
                var property = type.GetProperty(p_OrderByProperty);
                var parameter = Expression.Parameter(type, "p");
                var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                var orderByExpression = Expression.Lambda(propertyAccess, parameter);
                var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
                                              p_Source.Expression, Expression.Quote(orderByExpression));
                return p_Source.Provider.CreateQuery<TEntity>(resultExpression);
            }
            catch (ArgumentNullException)
            {
                throw new Exception("The OrderByProperty value of: '" + p_OrderByProperty + "', was empty or is not a proper column name!");
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
