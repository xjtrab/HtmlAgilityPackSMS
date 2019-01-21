using System.Threading.Tasks;

public interface IEmailService
{
    Task<bool> SendEmail(string subject ,string body);
}