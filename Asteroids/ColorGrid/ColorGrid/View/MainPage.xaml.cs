using Asteroids.Utils;
using DLToolkit.Forms.Controls;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Asteroids.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            pauseButton.IsVisible = false;
            timeLabel.IsVisible = false;
        }

        public void OnNewGame(object sender, EventArgs e)
        {
            pauseButton.IsVisible = true;
            timeLabel.IsVisible = true;
        }

        public void OnFieldsChanged(object sender, FieldsChangedEventArgs args)
        {

        }

        public void OnGameOver(object sender, String message)
        {
            DisplayAlert("Game Over!", message, "OK");
        }
    }
}
