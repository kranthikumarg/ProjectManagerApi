using System.Collections.Generic;
using System.Web.Http;
using BusinessEntities;
using BusinessLayer;

namespace ProjectManagerApi.Controllers
{
    /// <summary>
    ///  User Controller
    /// </summary>
    public class UserController : ApiController
    {
        UserBusiness _usrBusiness = new UserBusiness();
     
       

        /// <summary>
        /// To update user
        /// </summary>
        /// <param name="_userModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/updateUser")]
        public UserUpdateModel InsertUpdateUser(UserModel user)
        {
            return _usrBusiness.InsertUpdateUser(user);
        }

        /// <summary>
        /// To get all users details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/getUsers")]
        public IEnumerable<UserModel> Get()
        {
            return _usrBusiness.GetAllUsers();
        }


        /// <summary>
        /// To delete user
        /// </summary>
        /// <param name="_userModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/deleteUser")]
        public StatusModel DeleteUser(UserModel user)
        {
            return _usrBusiness.DeleteUser(user);
        }
    }
}