using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BS_Test.Data
{
    public class Comment
    {
        [Key]
        public int comId { set; get; }

        public string Comment_Data { set; get; }

        public string user { set; get; }

        public string date { set; get; }

        [ForeignKey("Post")]
        public int PID { set; get; }
        public Post Post { set; get; }

        public int vote { set; get; }
       
    }
}
