using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

public class YunpianSMSService : ISMSService {
    public void SendByPhone(string phone,string strContext){
        // 设置为您的apikey(https://www.yunpian.com)可查
        string apikey = "";
        // 发送的手机号
        string mobile = phone;
        // 发送模板内容
        mobile = HttpUtility.UrlEncode(mobile, Encoding.UTF8);
       
        string text = "【龙游世界】网站: " +  HttpUtility.UrlEncode(strContext, Encoding.UTF8) + " 无法访问请运维人员检查";

        // 智能模板发送短信url
        string url_send_sms = "https://sms.yunpian.com/v2/sms/single_send.json";
       
        string data_send_sms = "apikey=" + apikey + "&mobile=" + mobile + "&text=" +
            text;
        string data_send_voice = "apikey=" + apikey + "&mobile=" + mobile +
            "&code=" + "1234";

        // HttpPost(url_get_user, data_get_user);
        HttpPost(url_send_sms, data_send_sms);
        
    }
    public static void HttpPost(string Url, string postDataStr)
    {
        byte[] dataArray = Encoding.UTF8.GetBytes(postDataStr);
        // Console.Write(Encoding.UTF8.GetString(dataArray));

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = dataArray.Length;
        //request.CookieContainer = cookie;
        Stream dataStream = request.GetRequestStream();
        dataStream.Write(dataArray, 0, dataArray.Length);
        dataStream.Close();
        try
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader =
                new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            String res = reader.ReadToEnd();
            reader.Close();
            Console.Write("\nResponse Content:\n" + res + "\n");
        }
        catch (WebException e)
        {
            Console.Write(e.Message + e.ToString());
            Stream stream = e.Response.GetResponseStream();

            StreamReader reader =
                new StreamReader(stream, Encoding.UTF8);
            String res = reader.ReadToEnd();
            reader.Close();
            Console.Write("\nResponse Content:\n" + res + "\n");
        }
    }
}
