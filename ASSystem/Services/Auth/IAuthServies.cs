namespace ASSystem.Services.Auth
{
    public interface IAuthServies
    {
        public void Login(string username, string password);
        public void Logout();

        public void Register(string username, string password);

        // genarate token
        public string GenerateJSONWebToken();
        // genarate refresh token
        public string GenerateRefreshToken();
        public string GenerateAccessToken();

    }
}
