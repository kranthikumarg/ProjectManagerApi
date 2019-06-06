#region Assemblies
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
#endregion

namespace DataAccessLayer
{
    public class UserRepository
    {
        #region Public Methods
       

        /// <summary>
        /// To get user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUserById(long userId)
        {
            using (var context = new ProjectManagerContext())
            {
                return context.Users.Where(x => x.User_ID == userId).FirstOrDefault();
            }
        }

        /// <summary>
        /// To get all users
        /// 
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {
            using (var context = new ProjectManagerContext())
            {
                return context.Users.ToList();
            }
        }

        /// <summary>
        /// To add user
        /// </summary>
        /// <param name="oUser"></param>
        /// <returns></returns>
        public User AddUser(User oUser)
        {
            using (var context = new ProjectManagerContext())
            {
                context.Users.Add(oUser);
                context.SaveChanges();
                return oUser;
            }
        }

        /// <summary>
        /// To update user
        /// </summary>
        /// <param name="oUser"></param>
        /// <returns></returns>
        public User UpdateUser(User oUser)
        {
            using (var context = new ProjectManagerContext())
            {
                context.Users.Attach(oUser);
                context.Entry(oUser).State = EntityState.Modified;
                context.SaveChanges();
                return oUser;
            }
        }

        /// <summary>
        /// To delete user
        /// </summary>
        /// <param name="oUser"></param>
        /// <returns></returns>
        public bool DeleteUser(User oUser)
        {
            using (var context = new ProjectManagerContext())
            {
                oUser = context.Users.FirstOrDefault(x => x.User_ID == oUser.User_ID);
                context.Users.Remove(oUser);
                context.SaveChanges();
                return true;
            }
        }
        #endregion

    }
}
