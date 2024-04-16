namespace Sobis.Core.Securitiy.JWT
{
    public static class TokenOptionsStatic
    {
        public static string Audience { get; set; }
        public static string Issuer { get; set; }
        public static int AccessTokenExpiration { get; set; }
        public static string SecurityKey { get; set; }
    }
}