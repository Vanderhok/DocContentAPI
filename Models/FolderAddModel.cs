using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI.Models
{
    public class FolderAddModel
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public Guid ParentId { get; set; }
    }
}
