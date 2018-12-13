
using Newtonsoft.Json;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Library
{
    public class JwtUtils
    {
        public static string key = "1q2w3e4r5t!@^*&()_+=";
        protected string HMacSha256Hash( string message)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            using (var hmacsha256 = new HMACSHA256(keyBytes))
            {
                var buffer = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(message));
                var b64 = Base64.EncodeBase64(Encoding.UTF8.GetString(buffer));
                return b64;
            }
        }

        /// <summary>
        /// 加密jwt,hs256
        /// </summary>
        /// <param name="header"></param>
        /// <param name="claim"></param>
        /// <returns></returns>
        public string EncodingJwt(JwtHeader header, JwtClaim claim)
        {
            var base64Header = Base64.EncodeBase64(Encoding.UTF8,JsonConvert.SerializeObject(header));
            var base64Claim = Base64.EncodeBase64(Encoding.UTF8,JsonConvert.SerializeObject(claim));
            var signature = HMacSha256Hash(base64Header + "." + base64Claim);
            return base64Header + "." + base64Claim + "." + signature;
        }
        /// <summary>
        /// 解密jwt,hs256
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public JwtClaim DecodingJwt(string token)
        {
            
            var claimstr=token.Split('.');
            string header, claim,signature;
            header = claimstr[0];
            claim = claimstr[1];
            signature = claimstr[2];
            //
            string sign=HMacSha256Hash(header + "." + claim);
            if (sign.Replace("+"," ")==signature)
            {
                return JsonConvert.DeserializeObject<JwtClaim>(Base64.DecodeBase64(Encoding.UTF8, claim));
            }
            return null;
        }
    }
}