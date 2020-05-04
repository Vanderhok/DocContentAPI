using DocContentAPI.Data.Interfaces;
using DocContentAPI.Data.Models;
using DocContentAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI.Data.Repository
{
    public class Folders : IFolders
    {
        private readonly LawyerContext context;
        private readonly Bookmarks bookmarks;

        public Folders(LawyerContext context)
        {
            this.context = context;
            bookmarks = new Bookmarks(context);
        }

        public Guid Add(FolderAddModel model)
        {
            FolderModel newFolder = new FolderModel
            {
                UserId = model.UserId,
                Name = model.Name
            };

            if (model.ParentId != Guid.Empty)
            {
                newFolder.ParentFolder = context.Folders.Where(x => x.Id == model.ParentId).FirstOrDefault();
            }

            context.Folders.Add(newFolder);
            context.SaveChanges();

            return newFolder.Id;
        }

        public bool Remove(FolderRemoveModel model)
        {
            var result = context.Folders.Where(x => x.Id == model.Id && x.UserId == model.UserId).FirstOrDefault();

            if (result != null)
            {
                context.Folders.Remove(result);
                context.SaveChanges();

                return true;
            }
            else
                return false;
        }

        public bool Rename(FolderRenameModel model)
        {
            var folder = context.Folders.Where(x => x.Id == model.Id && x.UserId == model.UserId).FirstOrDefault();

            if (folder != null)
            {
                folder.Name = model.Name;

                context.Folders.Update(folder);
                context.SaveChanges();

                return true;
            }
            else
                return false;
        }

        public FolderContentsModel GetFolderContents(Guid userId, Guid folderId, int docId, int pos)
        {
            FolderContentsModel folderContents = new FolderContentsModel { };

            BookmarkGetModel bookmarksGetModel = new BookmarkGetModel
            {
                UserId = userId, //S* userId должен быть обязательным
                FolderId = folderId,
                DocId = docId,
                Pos = pos,
                FromPos = 0,
                Count = 1000,
                Sort = DocsSort.ByAddDate
            };

            BookmarkResultModel receivedBookmarks = bookmarks.Get(bookmarksGetModel);

            foreach (List<BookmarkModel> topics in receivedBookmarks.Topics)
            {
                foreach (BookmarkModel subTopics in topics)
                {
                    var result = context.Folders.Where(x => x.Id == subTopics.FolderId).FirstOrDefault();

                    //folderContents.Folders.Add(GetFolderChilds(new FolderContentsModel { Id = result.Id, Name = result.Name }));
                };
            };

            return folderContents;
        }

        //private FolderContentsModel GetFolderChilds(FolderContentsModel model)
        //{
        //    return new FolderContentsModel
        //    {
        //        Id = model.Id,
        //        Name = model.Name,
        //        Topics = context.Bookmarks.Where(x => x.FolderId == model.Id).ToList()

        //        //.ToList(),
        //        //Folders = folder.folders?.Select(f => convertToModel(f)).ToList()
        //    };
        //}

        public bool PutFolderInFolder(FolderPutModel model)
        {
            var movingResult = context.Folders.SingleOrDefault(x => x.UserId == model.UserId && x.Id == model.MovingFolderId);
            var targetResult = context.Folders.SingleOrDefault(x => x.UserId == model.UserId && x.Id == model.DestFolderId);

            if (movingResult != null && targetResult != null)
            {
                movingResult.ParentFolder = targetResult;

                context.SaveChanges();

                return true;
            }
            else
                return false;
        }

        public bool PutBookmarksInFolder(BookmarksPutInFolderModel model)
        {
            var bookmarksResult = context.Bookmarks.Where(x => x.UserId == model.UserId && x.FolderId == model.FromFolderId);

            if (model.BookmarkId != Guid.Empty)
                bookmarksResult = bookmarksResult.Where(x => x.Id == model.BookmarkId);
            else if (model.DocId != 0)
                bookmarksResult = bookmarksResult.Where(x => x.DocId == model.DocId);

            if (bookmarksResult.ToList() != null)
            {
                Guid destFolderId = Guid.Empty;
                if (model.DestFolderId != Guid.Empty)
                    destFolderId = context.Folders.SingleOrDefault(x => x.Id == model.DestFolderId).Id;

                if (destFolderId == Guid.Empty)
                    return false;

                foreach (BookmarkModel bookmark in bookmarksResult)
                {
                    bookmark.FolderId = destFolderId;
                    context.Bookmarks.Update(bookmark);
                }

                context.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
