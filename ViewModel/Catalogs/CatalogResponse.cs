﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModel.Catalogs
{
    public class CatalogResponse
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid? ParentId { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Type { get; set; }

        public int CatalogsCount { get; set; }
    }
}
