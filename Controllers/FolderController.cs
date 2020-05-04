using DocContentAPI.Data.Interfaces;
using DocContentAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DocContentAPI.Controllers
{//http://localhost:2233/api/Folder
    [Route("api/[controller]")]
    public class FolderController : ControllerBase
    {
        private readonly IFolders folders;

        public FolderController(IFolders folders)
        {
            this.folders = folders;
        }

        [HttpPost("AddFolder")]
        public ActionResult AddFolder(FolderAddModel model)
        {
            folders.Add(model);

            return Ok();
        }

        [HttpPost("RemoveFolder")]
        public ActionResult RemoveFolder(FolderRemoveModel model)
        {
            folders.Remove(model);

            return Ok();
        }

        [HttpPut("RenameFolder")]
        public ActionResult RenameFolder(FolderRenameModel model)
        {
            folders.Rename(model);

            return Ok();
        }

        [HttpPut("PutFolderInFolder")]
        public ActionResult PutFolderInFolder(FolderPutModel model)
        {
            folders.PutFolderInFolder(model);

            return Ok();
        }

        [HttpPut("PutBookmarksInFolder")]
        public ActionResult PutBookmarksInFolder(BookmarksPutInFolderModel model)
        {
            folders.PutBookmarksInFolder(model);

            return Ok();
        }

        [HttpGet("GetFolderContents")]
        public FolderContentsModel GetFolderContents(Guid userId, Guid folderId, int docId, int pos)
        {
            return folders.GetFolderContents(userId, folderId, docId, pos);

        }



    }
}
