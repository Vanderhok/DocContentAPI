using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocContentAPI.Data.Interfaces;
using DocContentAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace DocContentAPI.Controllers
{//http://localhost:2233/api/Bookmark
    [Route("api/[controller]")]
    public class BookmarkController : ControllerBase
    {
        private readonly IBookmarks bookmarks;

        public BookmarkController(IBookmarks bookmarks)
        {
            this.bookmarks = bookmarks;
        }

        //http://localhost:2233/api/Bookmark/AddBookmark
        [HttpPost("AddBookmark")]
        public ActionResult AddBookmark([FromBody]Bookmark bookmark)
        {
            bookmarks.Add(bookmark);

            return Ok();
        }

        //http://localhost:2233/api/Bookmark/RemoveBookmarks
        [HttpPost("RemoveBookmarks")]
        public ActionResult RemoveBookmarks([FromBody]Bookmark bookmark)
        {
            bookmarks.Remove(bookmark);
            return Ok();
        }

        //http://localhost:2233/api/Bookmark/ReplaceBookmark
        [HttpPost("ReplaceBookmark")]
        public ActionResult ReplaceBookmark(Guid userId, int docId, string title, int view, int page, int scrollPos, Guid folderId)
        {
            bookmarks.Replace(userId, docId, title, view, page, scrollPos, folderId);
            return Ok();
        }

        //http://localhost:2233/api/Bookmark/FindBookmark
        [HttpGet("FindBookmark")]
        public BookmarkRequest FindBookmark(Guid userId, int docId, int view, int page, int scrollPos, Guid folderId)
        {
            return bookmarks.Find(userId, docId, view, page, scrollPos, folderId);
        }

        //http://localhost:2233/api/Bookmark/GetBookmarks
        [HttpGet("GetBookmarks")]
        public BookmarksResult GetBookmarks(Guid userId, int fromPos, int count, Guid folderId, int topicId, int pos, DocsSort sort)
        {
            return bookmarks.Get(userId, fromPos, count, folderId, topicId, pos, sort);
        }
    }
}
