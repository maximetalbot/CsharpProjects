using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FakeTweeter.models
{
    public class Tweet
    {
        public string identifiant { get; set; }
        public string dateCreation { get; set; }
        public string texte { get; set; }
        public string nomUtilisateur { get; set; }
        public string idUtilisateur { get; set; }
        public string pseudoUtilisateur { get; set; }
        public ImageSource avatar { get; set; }
    }
}
