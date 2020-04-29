using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocContentAPI.Data.Interfaces;
using DocContentAPI.Data.Models;
using DocContentAPI.Models;
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

        [HttpPost("AddBookmark")]
        public ActionResult AddBookmark(AddBookmarkModel model)
        {
            bookmarks.Add(model);

            return Ok();
        }

        [HttpDelete("RemoveBookmarks")]
        public ActionResult RemoveBookmarks(RemoveBookmarkModel model)
        {
            bookmarks.Remove(model);
            return Ok();
        }

        [HttpPut("ReplaceBookmark")]
        public ActionResult ReplaceBookmark(ReplaceBookmarkModel model)
        {
            bookmarks.Replace(model);
            return Ok();
        }

        [HttpPut("RenameBookmark")]
        public ActionResult RenameBookmark(RenameBookmarkModel model)
        {
            bookmarks.Rename(model);
            return Ok();
        }

        [HttpGet("FindBookmark")]
        public RequestBookmarkModel FindBookmark(FindBookmarkModel model)
        {
            return bookmarks.Find(model);
        }

        [HttpGet("GetBookmarks")]
        public ResultBookmarkModel GetBookmarks(GetBookmarksModel model)
        {
            return bookmarks.Get(model);
        }
    }
}
