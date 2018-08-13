using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    public class LoginService
    {
        MockUserData userList = new MockUserData();
        /// <summary>
        /// 檢查用戶是否合法
        /// </summary>
        /// <returns></returns>
        public bool IsUserAuth(UserModel user)
        {
            Console.WriteLine($"使用者登入：帳號={user.UserName} 密碼={user.Password}");
            //檢驗
            return userList.GetAllUser()
                .Any(o => user.UserName == o.UserName && user.Password == o.Password);
            //真正邏輯

            //日誌
        }
    }
}
