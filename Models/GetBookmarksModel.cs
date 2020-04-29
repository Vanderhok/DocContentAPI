using DocContentAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI.Models
{
    public class GetBookmarksModel
    {
        public Guid UserId { get; set; }
        public int FromPos { get; set; }
        public int Count { get; set; }
        public Guid FolderId { get; set; }
        public int DocId { get; set; }
        public int Pos { get; set; }
        public DocsSort Sort { get; set; }
    }
}
