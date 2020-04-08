using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogging_Away
{
    class Article
    {
        String articleTitle;
        String articleDetail;
        DateTime articleDateTime;
        User postedBy;

        public Article(String title, String detail, User user)
        {
            this.articleTitle = title;
            this.articleDetail = detail;
            this.articleDateTime = DateTime.Now;
            this.postedBy = user;
        }
    }

}
