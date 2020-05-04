using DocContentAPI.Data.Models;
using DocContentAPI.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI.Models
{
    public class FolderContentsModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<FolderContentsModel> Folders { get; set; } = new List<FolderContentsModel>();
        public List<List<BookmarkModel>> Topics { get; set; } = new List<List<BookmarkModel>>();
    }
}
