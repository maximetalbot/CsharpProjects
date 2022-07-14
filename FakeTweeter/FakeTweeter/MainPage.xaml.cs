using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Collections.ObjectModel;
using FakeTweeter.models;

namespace FakeTweeter
{
    public partial class MainPage : ContentPage
    {
        public NetworkAccess naCurrent { get; set; } = Connectivity.NetworkAccess;
        ObservableCollection<Tweet> tweets = new ObservableCollection<Tweet>();
        string lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum viverra elit diam, at mollis diam sagittis a. Aenean iaculis at diam non dignissim. Nam ut ornare metus. Nunc at dui magna. Praesent scelerisque tortor non ultrices tempor. Ut pulvinar, purus ut imperdiet mattis, tortor sem tempus nibh, eu lobortis lacus nibh malesuada urna.";
        public MainPage()
        {
            InitializeComponent();
            // Peuplement randomisé d'une liste de tweets
            for (int i = 0; i < new Random().Next(3,100); i++)
            {
                this.tweets.Add(new Tweet
                {
                    dateCreation = DateTime.Now.ToString(),
                    identifiant = "tweet#" + new Random().Next(0001, 9999) + "",
                    idUtilisateur = "user#" + new Random().Next(0001, 9999) + "",
                    nomUtilisateur = CodeMetier.GenerateName(new Random().Next(2, 9)),
                    pseudoUtilisateur = CodeMetier.GenerateName(new Random().Next(2, 9)) + ".N°" + new Random().Next(4),
                    texte = lorem,
                    avatar = ImageSource.FromUri(new Uri("https://picsum.photos/200/200?random=" + new Random().Next(1, 10)))
                });
            }
            // Déclaration de l'itemSource de la listview
            this.tweetList.ItemsSource = this.tweets;
        }

        private void SeConnecter_Clicked(object sender, EventArgs e)
        {
            // D'abord cacher l'éventuelle érreur précédente
            cacherErreur();
            // Test de connectivité internet par Xamarin Essentials
            //if (naCurrent == NetworkAccess.None)
            if (internet.IsToggled == false)
            {
                afficherErreur("Vous n'êtes pas connecté à internet.");
            }
            else
            {
                // Test de format de l'identifiant
                if (identifiant.Text == null || string.IsNullOrEmpty(identifiant.Text.ToString()) || identifiant.Text.Length < 3)
                {
                    afficherErreur("Veuillez saisir un identifiant d'au moins 3 caractères.");
                    deconnecte();
                    return;
                }
                // test de format du mot de passe
                if (motdepasse.Text == null || string.IsNullOrEmpty(motdepasse.Text.ToString()) || motdepasse.Text.Length < 4)
                {
                    afficherErreur("Veuillez saisir un mot de passe d'au moins 6 caractères.");
                    deconnecte();
                    return;
                }
                // Test d'activation du switch
                if (sesouvenir.IsToggled)
                {
                    DisplayAlert("Information", "Vous serez automatiquement connecté au prochain lancement.", "Compris");
                }
                // Vérification de la validité du couple identifiant/mdp
                if (TwitterService.authenticate(identifiant.Text.ToString(), motdepasse.Text.ToString()) == true)
                {
                    DisplayAlert("Bienvenue", "Vous êtes connecté.", "OK");
                    connecte();
                }
            }
        }

        private void Internet_Toggle(object sender, ToggledEventArgs e)
        {
            if (internet.IsToggled == false)
            {
                naCurrent = NetworkAccess.None;
            }
            else
            {
                naCurrent = NetworkAccess.Internet;
            }
        }

        private void cacherErreur()
        {
            erreur.IsVisible = false;
        }

        private void afficherErreur(string message)
        {
            erreur.IsVisible = true;
            erreur.Text = message;
        }

        private void deconnecte()
        {
            formulaire.IsVisible = true;
            tweetList.IsVisible = false;
        }

        private void connecte()
        {
            formulaire.IsVisible = false;
            tweetList.IsVisible = true;
        }

        private async void tweetList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var tweet = (Tweet)tweetList.SelectedItem;
            await Navigation.PushAsync(new DetailTweet(tweet));
        }
    }
}
