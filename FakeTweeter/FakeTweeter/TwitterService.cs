using FakeTweeter.services;
using FakeTweeter.models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FakeTweeter;

[assembly: Dependency(typeof(TwitterService))]
namespace FakeTweeter
{
    public class TwitterService : ITweeterService
    {
        public static bool authenticate(string utilisateur, string motdepasse)
        {
            if (motdepasse == "admin" && utilisateur == "admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Tweet> getTweets(string chaine)
        {
            var tweets = new List<Tweet>();
            tweets.Add(new Tweet());
            return tweets;
        }

    }
}
