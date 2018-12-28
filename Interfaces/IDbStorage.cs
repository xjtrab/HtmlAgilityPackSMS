using System.Threading.Tasks;

namespace HtmlAgilityPackSMS.Interfaces
{
    public interface IDbStorage
    {
        void SaveSMSRawData(SMSRawData data);
        SendHandListStatus GetHandListStatusLastest();
        bool SaveHandListStatus(SendHandListStatus status);
        Community GetCommunityLastest();
        bool SaveCommunity(Community entity);
    }
}