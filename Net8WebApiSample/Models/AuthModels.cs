namespace Web.Models
{
    public class LoginRequestModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponseModel
    {
        public string AccessToken { get; set; }
    }
}
