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
        private Board _board;
        private MainPage _gamePage;
        private NavigationPage _mainPage;

        public App()
        {
            _board = new Board(5, 5);
            _viewModel = new AsteroidsViewModel(new AsteroidsModel(_board.Width, _board.Width));

            _gamePage = new MainPage();

            _viewModel.OnNewGame += new EventHandler(_gamePage.OnNewGame);
            _viewModel.OnGameOver += new EventHandler<String>(_gamePage.OnGameOver);
            _viewModel.OnFieldsChanged += new EventHandler<FieldsChangedEventArgs>(_gamePage.OnFieldsChanged);

            _gamePage.BindingContext = _viewModel;

            _mainPage = new NavigationPage(_gamePage);

            MainPage = _mainPage;
        }
    }
}
