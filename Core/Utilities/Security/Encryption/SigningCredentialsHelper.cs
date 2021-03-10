using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        //yine bu kısım da appsettings.json daki security key yapılanmasıdır
        public static SigningCredentials CreateSigningCredentials(SecurityKey security)
        {
            return new SigningCredentials(security, SecurityAlgorithms.HmacSha512Signature);

            //Yani Hashing işlemi yaparken .NET e de diyoruz ki SecurityKey anahtarını kullanarak Security algoritmalardan hmcsha512Signature kullanarak imzala
        }
    }
}
