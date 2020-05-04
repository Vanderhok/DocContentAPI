using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI.Models
{
    public class BookmarksPutInFolderModel
    {
        public Guid UserId { get; set; }
        public Guid BookmarkId { get; set; }
        public Guid FromFolderId { get; set; }
        public Guid DestFolderId { get; set; }
        public int DocId { get; set; }
    }
}
