using DocContentAPI.Data.Interfaces;
using DocContentAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DocContentAPI.Data.Repository
{
    public class Bookmarks : IBookmarks
    {
        private readonly LawyerContext bookmarkContext;

        public Bookmarks(LawyerContext bookmarkContext)
        {
            this.bookmarkContext = bookmarkContext;
        }

        public Guid Add(Bookmark bookmark)
        {
            bookmark.Id = Guid.NewGuid();
            bookmark.DateAdd = DateTime.Now;

            bookmarkContext.Bookmarks.Add(bookmark);
            bookmarkContext.SaveChanges();

            return bookmark.Id;
        }

        public bool Remove(Bookmark bookmark)
        {
            bookmarkContext.Bookmarks.Remove(bookmark);
            bookmarkContext.SaveChanges();
            return true;
        }

        public BookmarkRequest Find(Guid userId, int docId, int view, int page, int scrollPos, Guid folderId)
        {
            var bookmarks = bookmarkContext.Bookmarks.Where(x => x.UserId == userId && x.DocId == docId && x.View == view && x.Page == page && x.ScrollPos == scrollPos);

            if (folderId != null)
            {
                bookmarks = bookmarks.Where(x => x.FolderId == folderId);
            }

            var result = bookmarks.Select(c => new BookmarkRequest
            {
                DateAdd = c.DateAdd,
                DocId = c.DocId,
                FolderId = c.FolderId,
                Id = c.Id,
                Name = c.Name,
                Page = c.Page,
                ScrollPos = c.ScrollPos,
                View = c.View
            });

            return result.FirstOrDefault();
        }

        public BookmarksResult Get(Guid userId, int fromPos, int count, Guid folderId, int topicId, int pos, DocsSort sort = DocsSort.ByName)
        {
            var bookmarks = bookmarkContext.Bookmarks.Where(x => x.UserId == userId);

            if (topicId > 0)
            {
                bookmarks = bookmarks.Where(x => x.DocId == topicId);

                if (pos >= 0)
                    bookmarks = bookmarks.Where(x => x.Page == pos);
            }
            else
                bookmarks = bookmarks.Where(x => x.FolderId == folderId).OrderBy(o => o.FolderId)
                                            .ThenBy(o => o.DocId).ThenByDescending(o => o.DateAdd);

            var result = bookmarks.ToList();

            var topics = new List<List<Bookmark>>();
            int total = 0;
            List<Bookmark> bookmarksList = new List<Bookmark>();

            foreach (Bookmark bk in result)
            {
                if (total > 0)
                {
                    if (total >= fromPos && total <= fromPos + count)
                        topics.Add(bookmarksList);

                    bookmarksList = new List<Bookmark>();
                }
                total += 1;

                Bookmark bookmark = new Bookmark
                {
                    Id = bk.Id,
                    DocId = bk.DocId,
                    DateAdd = bk.DateAdd,
                    Name = bk.Name,
                    TopicName = bk.TopicName,
                    View = bk.View,
                    Page = bk.Page,
                    ScrollPos = bk.ScrollPos,
                    FolderId = bk.FolderId
                };

                if (!DBNull.Value.Equals(bk.Cid))
                {
                    bookmark.Cid = bk.Cid;
                    bookmark.Changed = bk.Changed;
                    bookmark.Notificated = bk.Notificated;
                }

                bookmark.Noactive = !DBNull.Value.Equals(bk.Noactive);
                bookmark.Preactive = !DBNull.Value.Equals(bk.Preactive);
                bookmarksList.Add(bookmark);
            }

            if (total > 0)
                topics.Add(bookmarksList);

            if (sort == DocsSort.ByName)
                topics = topics.OrderByDescending(b => b.First().TopicName).ToList();
            else if (sort == DocsSort.ByAddDate)
                topics = topics.OrderByDescending(b => b.Max(b => b.DateAdd)).ToList();

            BookmarksResult bmResult = new BookmarksResult();
            bmResult.Topics = topics;
            bmResult.Total = total;

            if (topics.Count > 0)
            {
                bmResult.FirstPos = fromPos;
                bmResult.LastPos = fromPos + topics.Count - 1;
            }
            else
            {
                bmResult.FirstPos = 0;
                bmResult.LastPos = 0;
            }

            return bmResult;
        }

        public Guid Replace(Guid userId, int docId, string title, int view, int page, int scrollpos, Guid folder_id)
        {
            BookmarkRequest bookmarkRequest = Find(userId, docId, view, page, scrollpos, folder_id);

            Remove(new Bookmark { Id = bookmarkRequest.Id });

            Bookmark bookmark = new Bookmark
            {
                UserId = userId,
                DocId = docId,
                TopicName = title,
                View = view,
                Page = page,
                ScrollPos = scrollpos,
                FolderId = folder_id
            };

            Guid newBmId = Add(bookmark);

            return newBmId;
        }
    }
}
