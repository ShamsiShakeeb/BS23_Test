using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BS_Test.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrainStation23.Controllers
{

    public class VotingSystem : Controller
    {

        private readonly DatabaseContext _context;

        public VotingSystem(DatabaseContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("api/getReport/{page}")]
        public ActionResult get_Report(int page)
        {

            var data = _context.post.Select(x => x).ToList();
  
            List<KeyValuePair<List<Posting>, List<Commenting>>> report = new List<KeyValuePair<List<Posting>, List<Commenting>>>();
            int count = 0;
            int page_nation = 0;

            for (int i = 0; i < data.Count(); i++)
            {
                List<Posting> post = new List<Posting>();
                List<Commenting> comments = new List<Commenting>();
                count++;

                if (count > 10)
                {
                    page_nation++;
                    count = 0;
                }

                var com = _context.comment.Where(x => x.PID == data[i].PID)
                 .Select(x => x).ToList();

                int like = _context.comment.Where(x => x.PID == data[i].PID && x.vote == 1)
                 .Select(x => x).ToList().Count();

                int unlike = _context.comment.Where(x => x.PID == data[i].PID && x.vote == -1)
                .Select(x => x).ToList().Count();

                var pos = new Posting
                {
                    Post = data[i].post_data,
                    Time = data[i].date,
                    CommentCount = com.Count().ToString(),
                    user = data[i].user,
                    page = page_nation,
                };

               

                for (int j = 0; j < com.Count; j++)
                {
                    var coms = new Commenting
                    {
                        data = com[j].Comment_Data,
                        time = com[j].date,
                        user = com[j].user,
                        like = like.ToString(),
                        disLike = unlike.ToString(),
                        page=page_nation,
                    };
                    comments.Add(coms);
                    count++;
                }
                post.Add(pos);

               
                    var page_post = post.Where(x => x.page == page).Select(y => y).ToList();
                    var page_comment = comments.Where(x => x.page == page).Select(y => y).ToList();
                
              

                var pair = new KeyValuePair<List<Posting>, List<Commenting>>(page_post, page_comment);

                report.Add(pair);





            }
            return Json( new { success=true , data=report });
        }


        [HttpGet]
        [Route("api/getReport/{page}/{queryByPost}")]
        public ActionResult get_Report(int page,string queryByPost)
        {

            var data = _context.post.Where(x => x.post_data.ToUpper().Contains(queryByPost.ToUpper())).Select(x => x).ToList();

            List<KeyValuePair<List<Posting>, List<Commenting>>> report = new List<KeyValuePair<List<Posting>, List<Commenting>>>();
            int count = 0;
            int page_nation = 0;

            for (int i = 0; i < data.Count(); i++)
            {
                List<Posting> post = new List<Posting>();
                List<Commenting> comments = new List<Commenting>();
                count++;

                if (count > 10)
                {
                    page_nation++;
                    count = 0;
                }

                var com = _context.comment.Where(x => x.PID == data[i].PID)
                 .Select(x => x).ToList();

                int like = _context.comment.Where(x => x.PID == data[i].PID && x.vote == 1)
                 .Select(x => x).ToList().Count();

                int unlike = _context.comment.Where(x => x.PID == data[i].PID && x.vote == -1)
                .Select(x => x).ToList().Count();

                var pos = new Posting
                {
                    Post = data[i].post_data,
                    Time = data[i].date,
                    CommentCount = com.Count().ToString(),
                    user = data[i].user,
                    page = page_nation,
                };



                for (int j = 0; j < com.Count; j++)
                {
                    var coms = new Commenting
                    {
                        data = com[j].Comment_Data,
                        time = com[j].date,
                        user = com[j].user,
                        like = like.ToString(),
                        disLike = unlike.ToString(),
                        page = page_nation,
                    };
                    comments.Add(coms);
                    count++;
                }
                post.Add(pos);


                var page_post = post.Where(x => x.page == page).Select(y => y).ToList();
                var page_comment = comments.Where(x => x.page == page).Select(y => y).ToList();



                var pair = new KeyValuePair<List<Posting>, List<Commenting>>(page_post, page_comment);

                report.Add(pair);





            }
            return Json(new { success = true, data = report });
        }




        [HttpGet]
        [Route("api/Vote/{cid}/{vote}")]
        public async Task<ActionResult> AddVote(int cid, int vote)
        {
            if (vote != 1 || vote != -1)
            {
                return Json(new { success = false });
            }

            var data = _context.comment.Where(x => x.comId == cid).Select(y => y).FirstOrDefault();

            if (data == null)
            {
                return Json(new { success = false });
            }

            data.vote = vote;
            await _context.SaveChangesAsync();
            return Json(new { success = true });

        }








        [HttpPost]
        [Route("api/AddPost")]
        public async Task<ActionResult> AddPost(Post post)
        {
            var obj = new Post
            {
                post_data = post.post_data,
                user = post.user,
                date = (DateTime.UtcNow).ToString(),
                active = 1,
            };

            _context.post.Add(obj);
            var res = await _context.SaveChangesAsync();
            if (res > 0)
            {
                return Json(new { success = true, data = "Post Added Successfully" });
            }
            else
            {
                return Json(new { success = true, data = "Something Went Wrong" });
            }
        }
        [HttpPost]
        [Route("api/AddComment/{pid}")]
        public async Task<ActionResult> AddComment(int pid, Comment com)
        {
            var obj = new Comment
            {
                Comment_Data = com.Comment_Data,
                user = com.user,
                date = (DateTime.UtcNow).ToString(),
                PID = pid,
                vote=0,
            };

            _context.comment.Add(obj);
            var res = await _context.SaveChangesAsync();
            if (res > 0)
            {
                return Json(new { success = true, data = "Post Added Successfully" });
            }
            else
            {
                return Json(new { success = true, data = "Something Went Wrong" });
            }
        }

        
       


        struct Posting
        {
            public string Post { set; get; }

            public int page { set; get; }
            public string Time { set; get; }

            public string user { set; get; }

            public string CommentCount { set; get; }


        }
        struct Commenting
        {
            public string data { set; get; }
            public string user { set; get; }

            public string time { set; get; }

            public string like { set; get; }

            public string disLike { set; get; }

            public int page { set; get; }
        }


    }
}
