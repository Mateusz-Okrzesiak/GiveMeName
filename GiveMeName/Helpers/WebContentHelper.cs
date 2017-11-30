using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GiveMeName.Models;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using System.Net.Mail;
using System.IO;
using Google.Apis.YouTube.v3;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using AutoMapper;

namespace GiveMeName.Helpers
{
    public static class WebContentHelper
    {
        private const string key = "PasteYourApiKey!!!!";
        private const string YouTubeApiLink = @"https://www.googleapis.com/youtube/v3/commentThreads?key=";
        private const string YouTubeApiLink2 = "&textFormat=plainText&part=snippet&videoId=";

        public static string GetContent(string videoUrl)
        {             
            int startIndex = videoUrl.IndexOf("=");
            string videoId = videoUrl.Substring(++startIndex);

            string FullUrl = YouTubeApiLink + key + YouTubeApiLink2 + videoId;

            WebClient client = new WebClient();
            var json = client.DownloadString(FullUrl); 

            return json;
        }

        public static List<User> GetUserInfo(string json)
        {
            List<User> users = new List<User>();

            JObject jsonoObj = JObject.Parse(json);
            var data = jsonoObj["items"];

            int i = 0;
            foreach (JObject item in data)
            {
                User u = new User();
                u.Name = (string)data[i]["snippet"]["topLevelComment"]["snippet"]["authorDisplayName"];
                u.Comment = (string)data[i]["snippet"]["topLevelComment"]["snippet"]["textDisplay"];
                users.Add(u);
                i++;
            }
            return users;
        }
    }
}