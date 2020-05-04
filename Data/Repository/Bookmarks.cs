using DocContentAPI.Data.Interfaces;
using DocContentAPI.Data.Models;
using DocContentAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DocContentAPI.Data.Repository
{
    public class Bookmarks : IBookmarks
    {
        private readonly LawyerContext context;

        public Bookmarks(LawyerContext context)
        {
            this.context = context;
        }

        public Guid Add(BookmarkAddModel model)
        {
            context.Bookmarks.Add(new BookmarkModel
            {
                Id = Guid.NewGuid(),
                UserId = model.UserId,
                DateAdd = DateTime.Now,
                DocId = model.DocId,
                TopicName = model.TopicName,
                View = model.View,
                Page = model.Page,
                ScrollPos = model.ScrollPos,
                FolderId = model.FolderId
            });

            context.SaveChanges();

            return model.Id;
        }

        public bool Remove(BookmarkRemoveModel model)
        {
            context.Bookmarks.Remove(new BookmarkModel
            {
                Id = model.Id,
                UserId = model.UserId,
                DocId = model.DocId,
                FolderId = model.FolderId
            });

            context.SaveChanges();
            return true;
        }

        public BookmarkRequestModel Find(BookmarkFindModel model)
        {
            var bookmarks = context.Bookmarks.Where(x => x.UserId == model.UserId && x.DocId == model.DocId && x.View == model.View && x.Page == model.Page && x.ScrollPos == model.ScrollPos);

            if (model.FolderId != null)
            {
                bookmarks = bookmarks.Where(x => x.FolderId == model.FolderId);
            }

            var result = bookmarks.Select(c => new BookmarkRequestModel
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

        public BookmarkResultModel Get(BookmarkGetModel model)
        {//S* UserId должен быть обязательным

            var query = context.Bookmarks.Where(x => x.UserId == model.UserId);

            if (model.DocId > 0)
            {
                query = query.Where(x => x.DocId == model.DocId);

                if (model.Pos >= 0)
                    query = query.Where(x => x.Page == model.Pos);
            }
            else if (model.FolderId != Guid.Empty)
                query = query.Where(x => x.FolderId == model.FolderId);

            query = query.OrderBy(o => o.FolderId).ThenBy(o => o.DocId).ThenByDescending(o => o.DateAdd);

            var result = query.ToList();

            var topics = new List<List<BookmarkModel>>();
            int total = 0;
            List<BookmarkModel> bookmarksList = new List<BookmarkModel>();

            foreach (var bk in result)
            {
                if (total > 0)
                {
                    if (total >= model.FromPos && total <= model.FromPos + model.Count)
                        topics.Add(bookmarksList);

                    bookmarksList = new List<BookmarkModel>();
                }
                total += 1;

                BookmarkModel bookmark = new BookmarkModel
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

            if (model.Sort == DocsSort.ByName)
                topics = topics.OrderByDescending(b => b.First().TopicName).ToList();
            else if (model.Sort == DocsSort.ByAddDate)
                topics = topics.OrderByDescending(b => b.Max(b => b.DateAdd)).ToList();

            BookmarkResultModel bmResult = new BookmarkResultModel();
            bmResult.Topics = topics;
            bmResult.Total = total;

            if (topics.Count > 0)
            {
                bmResult.FirstPos = model.FromPos;
                bmResult.LastPos = model.FromPos + topics.Count - 1;
            }
            else
            {
                bmResult.FirstPos = 0;
                bmResult.LastPos = 0;
            }

            return bmResult;
        }

        public Guid Replace(BookmarkReplaceModel model)
        {
            BookmarkRequestModel bookmarkRequest =
                Find(new BookmarkFindModel
                {
                    UserId = model.UserId,
                    DocId = model.DocId,
                    View = model.View,
                    Page = model.Page,
                    ScrollPos = model.ScrollPos,
                    FolderId = model.FolderId
                });

            Remove(new BookmarkRemoveModel { Id = bookmarkRequest.Id });

            Guid newBmId =
                Add(new BookmarkAddModel
                {
                    DocId = model.DocId,
                    FolderId = model.FolderId,
                    Page = model.Page,
                    ScrollPos = model.ScrollPos,
                    TopicName = model.TopicName,
                    UserId = model.UserId,
                    View = model.View
                });

            return newBmId;
        }

        public bool Rename(BookmarkRenameModel model)
        {
            context.Bookmarks.Update(new BookmarkModel
            {
                Id = model.Id,
                Name = model.Name,
                UserId = model.UserId
            });

            context.SaveChanges();

            return true;
        }
    }
}
