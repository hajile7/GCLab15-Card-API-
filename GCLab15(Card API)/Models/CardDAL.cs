using Microsoft.AspNetCore.DataProtection;
using System.Net;
using static System.Net.WebRequestMethods;

using Newtonsoft.Json;
namespace GCLab15_Card_API_.Models
{
    public class CardDAL
    {
        public static CardModel GetCard() //Adjust here
        {
            //adjust 
            //setup
            string key = Secret.Key; //this is equal to our api key. The key is alone in the secret class. make sure to add secret file to gitignore
            string url = $"https://deckofcardsapi.com/api/deck/{key}/draw/?count=5"; //this is the API's url

            //request (almost always stays same)
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //convert to JSON (almost always stays the same)
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            //Adjust
            //Convert to C#
            //install nuget Newtonsoft.json
            CardModel result = JsonConvert.DeserializeObject<CardModel>(JSON);
            return result;
        }
    }
}
