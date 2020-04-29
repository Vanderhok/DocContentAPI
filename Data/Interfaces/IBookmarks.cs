using DocContentAPI.Data.Models;
using DocContentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI.Data.Interfaces
{
    public interface IBookmarks
    {
        public Guid Add(AddBookmarkModel model);

        public bool Remove(RemoveBookmarkModel model);

        public RequestBookmarkModel Find(FindBookmarkModel model);

        public ResultBookmarkModel Get(GetBookmarksModel model);

        public Guid Replace(ReplaceBookmarkModel model);

        public bool Rename(RenameBookmarkModel model);
    }


    #region Example
    public class Ashot : IA12, IA23 { 
        public int A1 { get; set; }
        public int A2 { get; set; }
        public int A3 { get; set; }
    }

    interface IA12
    {
        public int A1 { get; set; }
        public int A2 { get; set; }
    }

    interface IA23
    {
        public int A3 { get; set; }
        public int A2 { get; set; }
    }
    #endregion

}
