﻿namespace Asteroids.Windows
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new Asteroids.App());
        }
    }
}
