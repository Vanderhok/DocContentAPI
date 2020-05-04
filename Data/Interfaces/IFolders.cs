using DocContentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI.Data.Interfaces
{
    public interface IFolders
    {
        public Guid Add(FolderAddModel model);

        public bool Remove(FolderRemoveModel model);

        public bool Rename(FolderRenameModel model);

        public FolderContentsModel GetFolderContents(Guid userId, Guid folderId, int docId, int pos);

        public bool PutFolderInFolder(FolderPutModel model);

        public bool PutBookmarksInFolder(BookmarksPutInFolderModel model);
    }
}
