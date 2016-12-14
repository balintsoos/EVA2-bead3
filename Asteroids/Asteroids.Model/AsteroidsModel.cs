using Asteroids.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Asteroids.Model
{
    public class AsteroidsModel
    {
        #region Private fields

        private List<Coordinate> _asteroids;
        private Coordinate _player;

        private Board _gameBoard;

        private bool _paused;

        private Timer _timer;
        private int _time;

        private ShuffledPositionList _shuffledList;

        #endregion

        #region Constructor

        public AsteroidsModel(int boardWidth, int boardHeight)
        {
            _gameBoard = new Board(boardWidth, boardHeight);
        }

        #endregion

        #region Public properties

        public Board GameBoard
        {
            get { return _gameBoard; }
        }

        public Coordinate Player
        {
            get { return _player; }
        }

        public List<Coordinate> Asteroids
        {
            get { return _asteroids; }
        }

        public bool Paused
        {
            get { return _paused; }
        }

        public int Time
        {
            get { return _time; }
        }

        #endregion

        #region Public methods

        public void NewGame()
        {
            InitPlayer();
            InitAsteroids();
            InitTimer();
            OnFieldsChanged();

            _paused = false;
        }

        public void Pause()
        {
            _paused = true;
            _timer?.Stop();
        }

        public void Resume()
        {
            _paused = false;
            _timer?.Start();
        }

        public void TurnLeft()
        {
            if (!_paused && _player.X > 0)
            {
                _player.X -= 1;

                OnFieldsChanged();
                CheckCollision();
            }
        }

        public void TurnRight()
        {
            if (!_paused && _player.X < _gameBoard.Width - 1)
            {
                _player.X += 1;

                OnFieldsChanged();
                CheckCollision();
            }
        }

        #endregion

        #region Private methods

        private void TimeChanged(object sender, ElapsedEventArgs e)
        {
            _time += 1;
            MoveAsteroids();
            AddAsteroids();

            OnFieldsChanged();
            OnTimePassed();

            CheckCollision();
        }

        private void InitPlayer()
        {
            int centerField = _gameBoard.Width / 2 + 1;

            _player = new Coordinate(centerField - 1, _gameBoard.Height - 1);
        }

        private void InitAsteroids()
        {
            _asteroids = new List<Coordinate>();
            _shuffledList = new ShuffledPositionList(_gameBoard.Width);
        }

        private void InitTimer()
        {
            _timer?.Stop();

            _time = 0;
            _timer = new Timer(1000);
            _timer.Elapsed += TimeChanged;
            _timer.Start();
        }

        private void CheckCollision()
        {
            foreach (Coordinate asteroid in _asteroids)
            {
                if (asteroid.Equals(_player))
                {
                    OnGameOver();
                    return;
                }
            }
        }

        private void AddAsteroids()
        {
            int distanceOfWaves = 3;
            int lengthOfWave = 10;

            _shuffledList.Shuffle();

            int numberOfNewAsteroids = _time % distanceOfWaves == 0
                ? _time / lengthOfWave + 1
                : 1;

            for (int i = 0; i < numberOfNewAsteroids; i++)
            {
                _asteroids.Add(new Coordinate(_shuffledList[i], 0));
            }
        }

        private void MoveAsteroids()
        {
            DeletePassedAsteroids();

            foreach (Coordinate asteroid in _asteroids)
            {
                asteroid.Y = asteroid.Y + 1;
            }
        }

        private void DeletePassedAsteroids()
        {
            _asteroids.RemoveAll(a => a.Y >= _gameBoard.Height - 1);
        }

        #endregion

        #region Events

        public event EventHandler<int> GameOver;

        public event EventHandler FieldsChanged;

        public event EventHandler<int> TimePassed;

        #endregion

        #region Event triggers

        private void OnGameOver()
        {
            Pause();

            GameOver?.Invoke(this, _time);
        }

        private void OnFieldsChanged()
        {
            FieldsChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnTimePassed()
        {
            TimePassed?.Invoke(this, _time);
        }

        #endregion
    }
}
