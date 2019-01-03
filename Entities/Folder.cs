using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Folder
    {
        [Required]
        public Guid Id { get; set; }

        [Required, MinLength(5), MaxLength(100)]
        public string Name { get; set; }

        [Required, MinLength(100), MaxLength(1000)]
        public string Description { get; set; }

        public Guid ParentFolderId { get; set; }

        public Folder ParentFolder { get; set; }

        public ICollection<Folder> ChildFolders { get; set; }

        public ICollection<Catalog> Catalogs { get; set; }
    }
}
