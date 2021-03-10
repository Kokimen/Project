using System;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken //Erişim Anahtarı, anlamsız karakterlerden oluşur
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
