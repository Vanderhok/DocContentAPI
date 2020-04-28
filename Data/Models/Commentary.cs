using DocContentAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI.Models
{
    public class Commentary
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int DocId { get; set; }
        public DateTime DateAdd { get; set; }
        public string Text { get; set; }
        public string TopicName { get; set; }
        public int Pos { get; set; }
        public int Cid { get; set; } = 0;
        public int Changed { get; set; } = 0;
        public int Notificated { get; set; } = 0;
        public bool Noactive { get; set; } = false;
        public bool Preactive { get; set; } = false;
        public List<Commentary> Answers { get; set; }
        public virtual Commentary ParentCommentary { get; set; }
    }

    public class RequestComment
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public List<RequestComment> Child { get; set; }
    }
}
