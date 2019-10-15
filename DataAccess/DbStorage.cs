
using System.Threading.Tasks;
using HtmlAgilityPackSMS;
using HtmlAgilityPackSMS.Interfaces;
using System.Linq;

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

        public SendHandListStatus GetHandListStatusLastest()
        {
            SendHandListStatus status;
            using (var db = new efContext())
            {
                status = db.SendHandListStatuss.OrderByDescending(l => l.Id).FirstOrDefault();
            }
            return status;
        }
        public bool SaveHandListStatus(SendHandListStatus status)
        {
            using (var db = new efContext())
            {
                db.SendHandListStatuss.Add(status);
                return db.SaveChanges() > 0;
            }
        }

        #region Community
        public Community GetCommunityLastest()
        {
            Community entity;
            using (var db = new efContext())
            {
                entity = db.Communitys.OrderByDescending(l => l.Id).FirstOrDefault();
            }
            return entity;
        }

        public bool SaveCommunity(Community entity)
        {
            using (var db = new efContext())
            {
                db.Communitys.Add(entity);
                return db.SaveChanges() > 0;
            }
        }

        public bool SaveGlobalStatus(GlobalStatus status)
        {
            using (var db = new efContext())
            {
                db.GlobalStatuses.Add(status);
                return db.SaveChanges() > 0;
            }
        }
        #endregion
    }
}