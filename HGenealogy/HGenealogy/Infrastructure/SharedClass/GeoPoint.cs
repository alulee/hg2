using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;


namespace HGenealogy.SharedClass
{
    public class GeoUtil
    {
        public static double[] GetGeoPointFromGoogleAPI(string address)
        {
            var url = String.Format("http://maps.google.com/maps/api/geocode/json?sensor=false&address={0}", address);

            string result = String.Empty;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            using (var response = request.GetResponse())
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    //Json格式: 請參考http://code.google.com/intl/zh-TW/apis/maps/documentation/geocoding/
                    result = sr.ReadToEnd();
                    double[] j = getLatLng(result);
                    return j;
                }
            }
        }

        /// <summary>
        /// 傳入Geocoding API產生的Json字串，取得經緯度
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static double[] getLatLng(string json)
        {
            //將Json字串轉成物件
            RootObject rootObj = JsonConvert.DeserializeObject<RootObject>(json);
            //從results開始往下找
            if (rootObj != null && rootObj.results != null && rootObj.results.Count > 0)
            {
                double lat = rootObj.results[0].geometry.location.lat;//緯度
                double lng = rootObj.results[0].geometry.location.lng;//經度

                double[] latLng = { lat, lng };
                return latLng;
            }

            return null;
        }


        /// <summary>
        /// 把地址轉成Json格式，這樣回傳字串裡才有緯經度
        /// 因為使用到Geocoding API地理編碼技術，請注意使用限制：http://code.google.com/intl/zh-TW/apis/maps/documentation/geocoding/#Limits
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static string convertAddressToJsonString(string address)
        {

            var url = "http://maps.googleapis.com/maps/api/geocode/json?sensor=false&address=" + HttpUtility.UrlEncode(address, Encoding.UTF8);
            string result = String.Empty;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            //指定語言，否則Google預設回傳英文 
            request.Headers.Add("Accept-Language", "zh-tw");

            using (var response = request.GetResponse())
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                result = sr.ReadToEnd();
            }

            return result;
        }


    }

    public class GeoPoint2
    {
        public decimal? lat { get; set; }
        public decimal? lon { get; set; }
    }
    public class GeoPoint
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
    public class AddressComponent
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public List<string> types { get; set; }
    }
    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }
    public class Northeast
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }
    public class Southwest
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }
    public class Viewport
    {
        public Northeast northeast { get; set; }
        public Southwest southwest { get; set; }
    }
    public class Geometry
    {
        public Location location { get; set; }
        public string location_type { get; set; }
        public Viewport viewport { get; set; }
    }
    public class Result
    {
        public List<AddressComponent> address_components { get; set; }
        public string formatted_address { get; set; }
        public Geometry geometry { get; set; }
        public bool partial_match { get; set; }
        public List<string> types { get; set; }
    }
    public class RootObject
    {
        public List<Result> results { get; set; }
        public string status { get; set; }
    }

}