﻿using DocContentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI
{
  public  interface IComments
    {
        //public int AddComment(Commentary commentary);

        /// <summary>
        /// By DocId
        /// </summary>
        /// <param name="DocId"></param>
        /// <returns></returns>
        public IEnumerable<Commentary> GetComments(int DocId);

        /// <summary>
        /// By UserId
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public IEnumerable<Commentary> GetComments(Guid UserId);

    }
}