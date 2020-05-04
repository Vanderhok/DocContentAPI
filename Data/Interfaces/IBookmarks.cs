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
        public Guid Add(BookmarkAddModel model);

        public bool Remove(BookmarkRemoveModel model);

        public BookmarkRequestModel Find(BookmarkFindModel model);

        public BookmarkResultModel Get(BookmarkGetModel model);

        public Guid Replace(BookmarkReplaceModel model);

        public bool Rename(BookmarkRenameModel model);
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
