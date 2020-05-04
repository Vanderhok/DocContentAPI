using DocContentAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI.Models
{
    public class BookmarkResultModel
    {
        public int Total { get; set; }
        public int FirstPos { get; set; }
        public int LastPos { get; set; }
        public List<List<BookmarkModel>> Topics { get; set; }
    }
}
