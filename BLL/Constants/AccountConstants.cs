using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Constants
{
    public static class AccountConstants
    {
        public const string UserRoleName = "UserRole";
        public const string AdminRoleName = "AdminRole";
        public const string AuthenticatedType = "ApplicationCookie";

        public const string Roles = "UserRole, AdminRole";

        public const string NotCorrectLoginAndPass = "Некорректные логин или пароль";
        public const string ErrorCreateUser = "Ошибка при создании пользователя";
    }
}
