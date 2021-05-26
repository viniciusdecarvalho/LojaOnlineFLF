namespace LojaOnlineFLF.WebAPI
{
    ///<summary>
    /// Constantes
    ///</summary>
    public static class K
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
        }

        public static class Auth
        {
            public const string SecurityKey = "lojaonlineflf-autentication-validation";
            public const string Issuer = "lojaonline.webapi";
            public const string Audience = "client";
        }
    }
}