#region Assemblies
using BusinessEntities;
using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace BusinessLayer
{
    public class UserBusiness
    {

        #region Assemblies
        UserRepository repoUser = new UserRepository();


        #endregion


        #region Public Methods

        

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="oUser"></param>
        /// <returns>Status</returns>
        public StatusModel DeleteUser(UserModel oUser)
        {
            repoUser.DeleteUser(new User()
            {
                User_ID = oUser.User_ID
            });
            return new StatusModel() { Message = "user deleted successfully", Result = true };
        }

        /// <summary>
        /// Insert or update user
        /// </summary>
        /// <param name="oUser"></param>
        /// <returns>Updated user details</returns>
        public UserUpdateModel InsertUpdateUser(UserModel oUser)
        {
            StatusModel oStatus = new StatusModel();
            User user = new User()
            {
                Employee_ID = oUser.Employee_ID,
                First_Name = oUser.First_Name,
                Last_Name = oUser.Last_Name,
                Project_ID = oUser.Project_ID
            };
            if (oUser.User_ID == 0)
            {
                user = repoUser.AddUser(user);
                oStatus = new StatusModel() { Message = "User added successfully", Result = true };
            }
            else
            {
                user.User_ID = oUser.User_ID;
                user = repoUser.UpdateUser(user);
                oStatus = new StatusModel() { Message = "User updated successfully", Result = true };
            }

            return new UserUpdateModel()
            {
                status = oStatus,
                user = new UserModel()
                {
                    User_ID = user.User_ID,
                    Project_ID = user.Project_ID,
                    Employee_ID = user.Employee_ID,
                    First_Name = user.First_Name,
                    Last_Name = user.Last_Name
                }
            };

        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>Users</returns>
        public List<UserModel> GetAllUsers()
        {
            return repoUser.GetAllUsers().Select(x => new UserModel
            {
                Employee_ID = x.Employee_ID,
                First_Name = x.First_Name,
                Last_Name = x.Last_Name,
                Project_ID = x.Project_ID,
                User_ID = x.User_ID
            }).ToList();
        }

        #endregion

    }
}
