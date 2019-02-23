namespace TrafficSignalsConfigurator.Web.ViewModels
{
    public interface IAuthService
    {
        AuthDataViewModel GetAuthData(string id);
        string HashPassword(string password);
        bool VerifyPassword(string actualPassword, string hashedPassword);
    }
}