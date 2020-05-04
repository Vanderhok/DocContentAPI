using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI.Models
{
    public class BookmarkAddModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateAdd { get; set; } = DateTime.Now;
        public int DocId { get; set; }
        public string TopicName { get; set; }
        public int View { get; set; }
        public int Page { get; set; }
        public int ScrollPos { get; set; }
        public Guid FolderId { get; set; }
    }
}
