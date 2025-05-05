using AgriEnergyConnect.Data;

namespace AgriEnergyConnect.Logic
{
    public class AuthenticationLogic
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationLogic(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool compareHashedPasswords()
        {
            return true;
        }

        public string hashUserPassword()
        {
            return String.Empty;
        }

        public User SignUserIn(string username, string password)
        {
            EnvironmentVariables._isLoggedIn = true;
            EnvironmentVariables._userRole = "Farmer"; //Load from user
            return new User();
        }

        public User SignUserOut(string username, string password)
        {
            EnvironmentVariables._isLoggedIn = false;
            EnvironmentVariables._userRole = null;
            return new User();
        }
    }
}
