using System.Threading.Tasks;

namespace HtmlAgilityPackSMS.Interfaces
{
    public interface IDbStorage
    {
        void SaveSMSRawData(SMSRawData data);
    }
}