using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI.Data.Models
{
    public enum DocsSort
    {
        ByName,
        ByAddDate
    }

    public class BookmarkModel
    {
        public Guid Id { get; set; }
        //[ForeignKey("Folder")]
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

}
