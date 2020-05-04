using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI.Models
{
    public class BookmarkRemoveModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int DocId { get; set; }
        public Guid FolderId { get; set; }
    }
}
