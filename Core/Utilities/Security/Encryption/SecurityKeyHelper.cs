using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        //SecurityKey bizim api projemizde appsettings.json dosyamızda belirttiğimiz SecurityKey alanımızdrı. Burada ref vermek için : Microsoft.IdentityModel.Tokens; nugetten yüklenir ve using e eklenir **
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)); //securitykey imizi encoding ile string e çevirrerek geriye gönderidk.
        }
    }
}
