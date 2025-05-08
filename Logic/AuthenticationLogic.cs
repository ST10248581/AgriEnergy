using System.Security.Cryptography;
using System.Text;
using AgriEnergyConnect.Data;

namespace AgriEnergyConnect.Logic
{
    public class AuthenticationLogic
    {
        public bool compareHashedPasswords(string hashedPassword, string enteredHashedPassword)
        {
           if (hashedPassword == null || enteredHashedPassword == null) { throw new Exception("Password cannot be null"); }

           return hashedPassword == enteredHashedPassword;
        }

        public string hashUserPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // Convert to hex string
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }

        public User SignUserUp(string name, string email, string password, int roleId)
        {
            if (string.IsNullOrEmpty(name)) throw new Exception("Name is required.");
            if (string.IsNullOrEmpty(email)) throw new Exception("Email is required.");
            if (string.IsNullOrEmpty(password)) throw new Exception("Password is required.");
            if (roleId == 0) throw new Exception("User role required");

            using (var dm = new AgriEnergyConnectContext())
            {
                var role = dm.UserRoles.FirstOrDefault(r => r.RoleId == roleId);
                if (role == null) throw new Exception("User role not found.");

                var user = new User()
                {
                    Name = name,
                    Email = email,
                    Password = password,
                    RoleId = role.RoleId
                };

                dm.Add(user);
                dm.SaveChanges();

                return user;
            }
            
        }

        public void SignUserIn(string email, string password)
        {
            using (var dm = new AgriEnergyConnectContext())
            {
                //Emails stored in lower case
                var user = dm.Users.FirstOrDefault(u => u.Email == email.ToLower());
                if (user == null) throw new Exception("Incorrect email or password, please try again.");

                var userRole = dm.UserRoles.FirstOrDefault(r => r.RoleId == user.RoleId);
                if (userRole == null) throw new Exception("User role not found, sign in attempt failed.");

                bool isCorrectPassword = compareHashedPasswords(hashUserPassword(password), hashUserPassword(user.Password));
                if (!isCorrectPassword) throw new Exception("Incorrect email or password, please try again.");

                EnvironmentVariables._isLoggedIn = true;
                EnvironmentVariables._userId = user.UserId;
                EnvironmentVariables._userRoleId = userRole.RoleId;
                EnvironmentVariables._userRole = userRole.RoleName;
            }
            
        }

        public void SignUserOut()
        {
            EnvironmentVariables._isLoggedIn = false;
            EnvironmentVariables._userId = 0;
            EnvironmentVariables._userRoleId = 0;
            EnvironmentVariables._userRole = null;
        }
    }
}
