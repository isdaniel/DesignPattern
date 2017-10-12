using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    public class MockUserData
    {
        List<UserModel> _userList = new List<UserModel>();

        public MockUserData()
        {
            _userList.Add(new UserModel() { RowID = 1, Password = "123456", UserName = "test123" });

        }

        public List<UserModel> GetAllUser()
        {
            return _userList;
        }

    }
}
