using System;
using System.Collections.Generic;
using System.Text;
using DAL.Databases;
using DAL.Interfaces;
namespace BLL.Logic
{
    // user functions thats connecting the controller to the DB
    public class UserData
    {
        private IUser users = new DAL.functions.UserFunctions();

        public List<User> GetUser()
        {
            return users.GetUser();
        }

        public User GetUserById(int id)
        {
            return users.GetUserById(id);
        }

        public User AddNewUser(User user1)
        {
            return users.AddNewUser(user1);
        }

        public User DeleteUser(int id)
        {
            return users.DeleteUser(id);
        }

        public User UpdateUser(User user1, int id)
        {
            return users.UpdateUser(user1, id);
        }

        public User UserLogin(User user1)
        {
            return users.UserLogin(user1);
        }
        public User UpdateToken(User user1, string token)
        {
            return users.UpdateToken(user1, token);
        }





    }
}
