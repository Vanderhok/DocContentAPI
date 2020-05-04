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
        public ActionResult AddBookmark(BookmarkAddModel model)
        {
            bookmarks.Add(model);

            return Ok();
        }

        [HttpDelete("RemoveBookmarks")]
        public ActionResult RemoveBookmarks(BookmarkRemoveModel model)
        {
            bookmarks.Remove(model);
            return Ok();
        }

        [HttpPut("ReplaceBookmark")]
        public ActionResult ReplaceBookmark(BookmarkReplaceModel model)
        {
            bookmarks.Replace(model);
            return Ok();
        }

        [HttpPut("RenameBookmark")]
        public ActionResult RenameBookmark(BookmarkRenameModel model)
        {
            bookmarks.Rename(model);
            return Ok();
        }

        [HttpGet("FindBookmark")]
        public BookmarkRequestModel FindBookmark(BookmarkFindModel model)
        {
            return bookmarks.Find(model);
        }

        [HttpGet("GetBookmarks")]
        public BookmarkResultModel GetBookmarks(BookmarkGetModel model)
        {
            return bookmarks.Get(model);
        }
    }
}
