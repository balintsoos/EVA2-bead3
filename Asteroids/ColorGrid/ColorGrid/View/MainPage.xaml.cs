using Asteroids.Utils;
using DLToolkit.Forms.Controls;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace Asteroids.View
{
    public partial class MainPage : ContentPage
    {
        public int GameSize;

        public MainPage(int size)
        {
            InitializeComponent();
            FlowListView.Init();

            GameSize = size;

            Set(false, false);
        }

        public void OnNewGame(object sender, EventArgs e)
        {
            Set(true, true);
        }

        public void OnFieldsChanged(object sender, FieldsChangedEventArgs args)
        {

        }

        public void OnGameOver(object sender, String message)
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                Set(true, false);
                DisplayAlert("Game Over!", message, "OK");
            });
        }

        private void Set(bool isVisible, bool isEnabled)
        {
            pauseButton.IsVisible = isVisible;
            timeLabel.IsVisible = isVisible;
            leftButton.IsVisible = isVisible;
            rightButton.IsVisible = isVisible;

            pauseButton.IsEnabled = isEnabled;
            timeLabel.IsEnabled = isEnabled;
            leftButton.IsEnabled = isEnabled;
            rightButton.IsEnabled = isEnabled;
        }
    }
}
