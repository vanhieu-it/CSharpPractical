using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IUserService
    {
        string GetUserName(int userId);
    }

    public class GreetingService
    {
        private readonly IUserService _userService;

        public GreetingService(IUserService userService)
        {
            _userService = userService;
        }

        public string GreetUser(int userId)
        {
            var userName = _userService.GetUserName(userId);
            return $"Hello, {userName}!";
        }
    }
}
