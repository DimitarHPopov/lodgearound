using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LodgeAround.Common
{
    public class Utility
    {   
        public static string GetHash(string str)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(str);
            SHA1Managed hash = new SHA1Managed();
            return Convert.ToBase64String(hash.ComputeHash(plainTextBytes));
        }

        public static string ConvertToBase64(string str)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(str);

            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);

            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
