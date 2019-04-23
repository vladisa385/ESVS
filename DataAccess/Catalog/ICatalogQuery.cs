﻿using System;
using System.Threading.Tasks;
using ViewModel.Catalogs;

namespace DataAccess.Catalog
{
    public interface ICatalogQuery
    {
        Task<CatalogResponse> RunAsync(Guid catalogId);
    }
}
