using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blogging_Away
{
    class User
    {
        String userName;
        String userType; 
        
        public User(String userName, String userType)
        {
            if(String.IsNullOrWhiteSpace(userName) || String.IsNullOrWhiteSpace(userType))
            {
                MessageBox.Show("Invalid Username or usertype");
                return;
            }

            if(userType.ToLower() == "author" || userType.ToLower() == "follower")
            {
                this.userName = userName;
                this.userType = userType;
            }
        }
    }
}
