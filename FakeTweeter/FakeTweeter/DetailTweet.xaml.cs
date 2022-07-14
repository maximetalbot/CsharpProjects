using FakeTweeter.models;
using FakeTweeter.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FakeTweeter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailTweet : ContentPage
    {
        Tweet tweet;
        public DetailTweet(Tweet tweet)
        {
            InitializeComponent();
            this.tweet = tweet;
            avatar.Source = tweet.avatar;
            pseudoUtilisateur.Text = tweet.pseudoUtilisateur;
            idUtilisateur.Text = tweet.idUtilisateur;
            texte.Text = tweet.texte;

            getJoke();
        }

        private async void getJoke()
        {
            ChuckNorrisJokeService svc = new ChuckNorrisJokeService();
            ChuckNorrisJoke joke = await svc.GetRandomJokeAsync();
            if(joke != null)
            {
                this.citation.Text = joke.value;
            }
        }
    }
}