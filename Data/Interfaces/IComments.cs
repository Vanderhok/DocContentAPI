using DocContentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI
{
  public  interface IComments
    {
        public Guid AddComment(CommentaryModel commentary);

        /// <summary>
        /// Get Comments by DocId
        /// </summary>
        /// <param name="docId"></param>
        /// <returns></returns>
        public IEnumerable<RequestComment> GetComments(int docId);

        /// <summary>
        /// Get Comments by UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<CommentaryModel> GetComments(Guid userId);

        public CommentaryModel GetCommentData(Guid id);

        public RequestComment GetCommentWithAnswers(Guid id);
   }
}
