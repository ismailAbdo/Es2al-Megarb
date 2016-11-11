using Es2al_Megarb.DatabaseClasses;
using System;
using System.Collections.Generic;
namespace Es2al_Megarb
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UsersDetails" in both code and config file together.
    public class UsersDetails : IUsersDetails
    {
        public IEnumerable<User> getAllUsers()
        {
            User u = new User();
            return u.getAllUsers();
        }
        public IEnumerable<User> getUser(string userID)
        {
            User u = new User();
            return u.getUser(userID);
        }
        public int addUser(string us)
        {
            Object userInput = us;
            User u = new User();
            return u.insertUser((User)userInput);
        }
    }
}
