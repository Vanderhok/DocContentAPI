using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI.Models
{
    public class BookmarkReplaceModel
    {
        public Guid UserId { get; set; }
        public int DocId { get; set; }
        public string TopicName { get; set; }
        public int View { get; set; }
        public int Page { get; set; }
        public int ScrollPos { get; set; }
        public Guid FolderId { get; set; }
    }
}
