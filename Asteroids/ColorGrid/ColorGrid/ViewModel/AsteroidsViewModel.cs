using Asteroids.Model;
using Asteroids.Utils;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Xamarin.Forms;

namespace Asteroids.ViewModel
{
    public class AsteroidsViewModel : INotifyPropertyChanged
    {
        #region Private fields

        private AsteroidsModel _model;
        private String _timer;

        #endregion

        public DelegateCommand NewGameCommand { get; private set; }
        public DelegateCommand PauseResumeCommand { get; private set; }
        public DelegateCommand TurnCommand { get; private set; }

        public String PauseResumeLabel
        {
            get
            {
                if (_model.Paused)
                {
                    return "Resume";
                }
                else
                {
                    return "Pause";
                }
            }
        }

        public String TimerLabel
        {
            get { return _timer; }
            set
            {
                _timer = "Time: " + value;
                OnPropertyChanged();
            }
        }

        public Int32 ColumnCount
        {
            get { return _model.GameBoard.Width; }
        }

        public ObservableCollection<Field> Fields { get; private set; }

        #region Constructor

        public AsteroidsViewModel(AsteroidsModel model)
        {
            _model = model;
            _model.FieldsChanged += new EventHandler(Model_FieldsChanged);
            _model.TimePassed += new EventHandler<int>(Model_TimePassed);
            _model.GameOver += new EventHandler<int>(Model_GameOver);

            NewGameCommand = new DelegateCommand(param => StartNewGame());
            PauseResumeCommand = new DelegateCommand(param => PauseResume());
            TurnCommand = new DelegateCommand(param => Turn(param.ToString()));

            TimerLabel = "0";

            Fields = new ObservableCollection<Field>();
        }

        #endregion

        #region Model event handlers

        private void Model_FieldsChanged(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                FieldType[][] matrix = new FieldType[_model.GameBoard.Width][];

                for (int i = 0; i < matrix.Length; i++)
                {
                    matrix[i] = new FieldType[_model.GameBoard.Height];

                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] = FieldType.EMPTY;
                    }
                }

                foreach (Coordinate asteroid in _model.Asteroids)
                {
                    matrix[asteroid.X][asteroid.Y] = FieldType.ASTEROID;
                }

                matrix[_model.Player.X][_model.Player.Y] = FieldType.PLAYER;

                Fields.Clear();

                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        Fields.Add(new Field(i, j, matrix[j][i]));
                    }
                }

                OnFieldsChanged?.Invoke(this, new FieldsChangedEventArgs(_model.Player, _model.Asteroids));
            });
        }

        private void Model_TimePassed(object sender, int time)
        {
            TimerLabel = time.ToString();
        }

        private void Model_GameOver(object sender, int time)
        {
            string message = "You lived for " + time.ToString() + " seconds";

            if (OnGameOver != null)
                OnGameOver(this, message);
        }

        #endregion

        #region Public Methods

        public void StartNewGame()
        {
            _model.NewGame();
            TimerLabel = "0";

            OnPropertyChanged("PauseResumeLabel");
            OnNewGame?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Private Methods

        private void PauseResume()
        {
            if (_model.Paused)
            {
                _model.Resume();
            }
            else
            {
                _model.Pause();
            }

            OnPropertyChanged("PauseResumeLabel");
        }

        private void Turn(String direction)
        {
            switch (direction)
            {
                case "left":
                    _model.TurnLeft();
                    break;
                case "right":
                    _model.TurnRight();
                    break;
            }
        }

        private void OnPropertyChanged([CallerMemberName] String property = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #endregion

        #region Public Events

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler OnNewGame;
        public event EventHandler<String> OnGameOver;
        public event EventHandler<FieldsChangedEventArgs> OnFieldsChanged;

        #endregion
    }
}
