using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI.Data.Models
{
    public class Bookmark
    {
        public Guid Id { get; set; }
        public Guid FolderId { get; set; }
        public Guid UserId { get; set; }
        public int DocId { get; set; }
        public DateTime DateAdd { get; set; }
        public string Name { get; set; }
        public string TopicName { get; set; }
        public int View { get; set; }
        public int Page { get; set; }
        public int ScrollPos { get; set; }
        public int Cid { get; set; } = 0;
        public int Changed { get; set; } = 0;
        public int Notificated { get; set; } = 0;
        public bool Noactive { get; set; } = false;
        public bool Preactive { get; set; } = false;
    }

    public class BookmarkRequest
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

    public class BookmarksResult
    {
        public int Total { get; set; }
        public int FirstPos { get; set; }
        public int LastPos { get; set; }
        public List<List<Bookmark>> Topics { get; set; }
    }

    public enum DocsSort
    {
        ByName,
        ByAddDate
    }
}
