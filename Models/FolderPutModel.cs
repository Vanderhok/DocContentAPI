using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI.Models
{
    public class FolderPutModel
    {
        public Guid UserId { get; set; }
        /// <summary>
        /// Перемещаемая папка
        /// </summary>
        public Guid MovingFolderId { get; set; }
        /// <summary>
        /// Папка-приемник
        /// </summary>
        public Guid DestFolderId { get; set; }
    }
}
