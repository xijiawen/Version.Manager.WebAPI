using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version.Manager.Model.Models.InDto
{
    public class MesFileDownLoadInDto
    {
        public string mySourcDict { get; set; }
        public string myDescDict { get; set; } 
        
        public string[] myFileType { get; set; }
    }
}
