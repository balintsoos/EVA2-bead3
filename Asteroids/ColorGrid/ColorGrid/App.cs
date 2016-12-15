using Asteroids.Model;
using Asteroids.ViewModel;
using Asteroids.View;
using Asteroids.Utils;
using System;
using Xamarin.Forms;

namespace Asteroids
{
    public class App : Application
    {
        private AsteroidsViewModel _viewModel;
        private int _fieldSize;
        private Board _board;
        private MainPage _gamePage;
        private NavigationPage _mainPage;

        public App()
        {
            _board = new Board(5, 5);
            _fieldSize = 100;
            _viewModel = new AsteroidsViewModel(new AsteroidsModel(_board.Width, _board.Width));

            _viewModel.OnNewGame += new EventHandler(ViewModel_OnNewGame);
            _viewModel.OnGameOver += new EventHandler<String>(ViewModel_OnGameOver);
            _viewModel.OnFieldsChanged += new EventHandler<FieldsChangedEventArgs>(ViewModel_OnFieldsChanged);

            _gamePage = new MainPage();
            _gamePage.BindingContext = _viewModel;

            _mainPage = new NavigationPage(_gamePage);

            MainPage = _mainPage;
        }

        private void ViewModel_OnNewGame(object sender, EventArgs e)
        {
           
        }

        private void ViewModel_OnGameOver(object sender, String message)
        {
            _mainPage.DisplayAlert("Game Over!", message, "OK");
            _viewModel.StartNewGame();
        }

        private void ViewModel_OnFieldsChanged(object sender, EventArgs e)
        {

        }
    }
}
