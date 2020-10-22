using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BS_Test.Data
{
    public class Post
    {
        [Key]
        public int PID { set; get; }
        public string post_data { set; get; }
        [MaxLength(100)]
        public string user { set; get; }
        public string date { set; get; }
        public int active { set; get; }
        public List<Comment> Comment_List { set; get; }

    }
}
