using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI.Data.Models
{
    public class FolderModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public List<FolderModel> SubFolders { get; set; }
        public virtual FolderModel ParentFolder { get; set; }

    }
}
