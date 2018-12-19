
using System.Threading.Tasks;
using HtmlAgilityPackSMS;
using HtmlAgilityPackSMS.Interfaces;

namespace HtmlAgilityPackSMS.DataAccess
{
    public class Dbstorage : IDbStorage
    {
        public Dbstorage()
        {

        }
        public void SaveSMSRawData(SMSRawData data)
        {
            using (var db = new efContext())
            {
                db.SMSRawDatas.Add(data);
                db.SaveChanges();
            }
        }
    }
}