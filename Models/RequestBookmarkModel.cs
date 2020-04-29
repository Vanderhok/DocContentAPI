using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI.Models
{
    public class RequestBookmarkModel
    {
        public Guid Id { get; set; }
        public Guid FolderId { get; set; }
        public int DocId { get; set; }
        public DateTime DateAdd { get; set; }
        public string Name { get; set; }
        public int View { get; set; }
        public int Page { get; set; }
        public int ScrollPos { get; set; }
    }
}
