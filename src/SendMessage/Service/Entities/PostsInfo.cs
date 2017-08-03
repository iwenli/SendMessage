using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMessage.Service.Entities
{
    /// <summary>
    /// 发帖结果
    /// </summary>
    class PostsInfo : WebResponseResult
    {
         
       public  string err { set; get; }

        public string errmsg { set; get; }

        public int n { set; get; }

        public int ok { set; get; }

        public bool status { set; get; }

    }
}
