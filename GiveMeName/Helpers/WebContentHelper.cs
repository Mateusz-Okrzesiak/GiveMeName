using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GiveMeName.Models;
using System.Net;
using System.Text;
using HtmlAgilityPack;

namespace GiveMeName.Helpers
{
    public static class WebContentHelper
    {

       public static string GetContent(string urlAdress)
        {
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            string webContent =  client.DownloadString(urlAdress);

            StringBuilder sb = new StringBuilder();
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(urlAdress);
            foreach (HtmlTextNode node in doc.DocumentNode.SelectNodes("//a[@id='author-text']/a"))
            {
                sb.AppendLine(node.Text);
            }
            string final = sb.ToString();

            HtmlNodeCollection tags = doc.DocumentNode.SelectNodes("//tag1//tag2");


            //string html;
            //// obtain some arbitrary html....
            //using (var client1 = new WebClient())
            //{
            //    html = client1.DownloadString("http://stackoverflow.com/questions/2038104");
            //}
            //// use the html agility pack: http://www.codeplex.com/htmlagilitypack
            //HtmlDocument doc = new HtmlDocument();
            //doc.LoadHtml(html);
            //StringBuilder sb = new StringBuilder();
            //foreach (HtmlTextNode node in doc.DocumentNode.SelectNodes("//text()"))
            //{
            //    sb.AppendLine(node.Text);
            //}
            //string final = sb.ToString();
            return webContent;
        }
       
        public static List<User> GetUserInfo(string webContent)
        {
            List<User> users = new List<User>();

            return users;
        }
    }
}