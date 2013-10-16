using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;

namespace DeviceManagerService
{

    [Table (Name = "Folder")]
    public class Folder
    {

        [Column (IsPrimaryKey = true)]
        private string ID;

        [Column]
        private string Name;

        [Column]
        private string ParentID;

    }
}