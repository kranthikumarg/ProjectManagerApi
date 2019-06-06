# region Assemblies
using BusinessEntities;
using Newtonsoft.Json;
using NUnit.Framework;
using ProjectManagerApi.Controllers;
using System.Collections;
using System.IO;
using System.Reflection;
using System;
#endregion
namespace ProjectManagerApi.Test
{
    [TestFixture]
    public class UserControllerTest : IDisposable
    {
        #region Private Variables Declarations

        private const string NEW_USER_SUCCESS = "User added successfully";
        private const string EXISTING_USER_SUCCESS = "User updated successfully";

        #endregion

        #region Public Methods
        public static IEnumerable GetUserTestData
        {
            get
            {
                string FileLoc = @"TestData\UserData.json";
                string FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", "").Replace("\\bin\\Debug", "");

                var jsonText = File.ReadAllText(Path.Combine(FilePath, FileLoc));
                var addUser = JsonConvert.DeserializeObject<UserModel>(jsonText);
                yield return addUser;
            }
        }

        [Test, TestCaseSource("GetUserTestData")]
        public void TestAddUser(UserModel testUser)
        {
            string message = string.Empty;
            UserController userController = new UserController();
            UserUpdateModel userResult = new UserUpdateModel();
            userResult = userController.InsertUpdateUser(testUser);
            message = userResult.status.Message;
            Assert.AreEqual(NEW_USER_SUCCESS, message);
            testUser.User_ID = userResult.user.User_ID;
            Assert.AreEqual(EXISTING_USER_SUCCESS, userController.InsertUpdateUser(testUser).status.Message);
            Assert.NotNull(userController.Get());
            Assert.IsTrue(userController.DeleteUser(testUser).Result);
        }

        public void Dispose()
        {
            DBFixtureController _DBFixture = new DBFixtureController();
            _DBFixture.DeleteTestData();
        }
        #endregion

    }
}
