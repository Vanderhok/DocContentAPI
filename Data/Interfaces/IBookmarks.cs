using DocContentAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI.Data.Interfaces
{
    public interface IBookmarks
    {
        public Guid Add(Bookmark bookmark);

        public bool Remove(Bookmark bookmark);

        public BookmarkRequest Find(Guid userId, int docId, int view, int page, int scrollpos, Guid folderId);

        public BookmarksResult Get(Guid userId, int fromPos, int count, Guid folderId, int topicId, int pos, DocsSort sort = DocsSort.ByName);

        public Guid Replace(Guid userId, int docId, string title, int view, int page, int scrollpos, Guid folder_id);
    }
}
