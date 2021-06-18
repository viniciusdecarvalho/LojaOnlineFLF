namespace LojaOnlineFLF.WebAPI
{
    ///<summary>
    /// Constantes
    ///</summary>
    internal static class K
    {
        ///<summary>
        /// Constantes de MediaType
        ///</summary>
        public static class MediaTypes
        {

            ///<summary>
            /// application/json
            ///</summary>
            public const string AplicationJson = "application/json";

            ///<summary>
            /// application/xml
            ///</summary>
            public const string AplicationXml = "application/xml";

            ///<summary>
            /// application/problem+json
            ///</summary>
            public const string AplicationProblemJson = "application/problem+json";
        }

        public static class Cultures
        {
            public const string Default = "pt-BR";
        }

        public static class Auth
        {
            public const string SecurityKey = "lojaonlineflf-autentication-validation";
            public const string Issuer = "lojaonline.webapi";
            public const string Audience = "client";
        }
    }
}