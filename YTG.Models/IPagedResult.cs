// --------------------------------------------------------------------------------
// Copyright © 2016, Yasgar Technology Group
//
// Purpose: Interface for paging results
//
// --------------------------------------------------------------------------------

using System.Collections.Generic;

namespace YTG.Models
{
    public interface IPagedResult<TEntity>
    {

        List<TEntity> Items { get; }
        int TotalCount { get; }

    }
}
