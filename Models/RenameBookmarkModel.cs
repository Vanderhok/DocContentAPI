using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI.Models
{
    public class RenameBookmarkModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}
