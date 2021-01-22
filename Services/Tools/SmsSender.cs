using System.IO;
using System.Net;
using System.Threading.Tasks;

public class SmsSender
{
    public static async Task<string> SendSmsAsync(SendSms smsInfo)
    {
        return await Task.Run(() =>
        {
            try
            {
                string json = string.Empty;
                string url = @$"https://www.saharsms.com/api/{smsInfo.ApiKey}/json/SendVerify?receptor={smsInfo.SmsSendTo}&template={smsInfo.Template}&token={smsInfo.Text}";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ProtocolVersion = HttpVersion.Version10;
                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    json = reader.ReadToEnd();
                }
                return json;
            }
            catch
            {
                return "-2";
            }
        });
    }
}