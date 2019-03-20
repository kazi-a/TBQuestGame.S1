using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.PresentationLayer;
using TBQuestGame.DataLayer;
using TBQuestGame.Models;

namespace TBQuestGame.BusinessLayer
{
    /// <summary>
    /// business logic layer class
    /// manages windows and interacts with the data layer
    /// </summary>
    public class GameBusiness
    {
        GameSessionViewModel _gameSessionViewModel;
        bool _newPlayer = false; // player data coming from GameData class
        Player _player = new Player();
        PlayerSetupView _playerSetupView = null;
        List<string> _messages;

        public GameBusiness()
        {
            SetupPlayer();
            InitializeDataSet();
            InstantiateAndShowView();
        }

        /// <summary>
        /// setup new or existing player
        /// </summary>
        private void SetupPlayer()
        {
            if (_newPlayer)
            {
                _playerSetupView = new PlayerSetupView(_player);
                _playerSetupView.ShowDialog();

                //
                // setup up game based player properties
                //
                _player.PerfamancePoints = 0;
                _player.Health = 100;
                _player.Lives = 3;
            }
            else
            {
                _player = GameData.PlayerData();
            }
        }

        /// <summary>
        /// initialize data set
        /// </summary>
        private void InitializeDataSet()
        {
            _player = GameData.PlayerData();
            _messages = GameData.InitialMessages();
        }

        /// <summary>
        /// create view model with data set
        /// </summary>
        private void InstantiateAndShowView()
        {
            //
            // instantiate the view model and initialize the data set
            //
            _gameSessionViewModel = new GameSessionViewModel(_player, _messages);
            GameSessionView gameSessionView = new GameSessionView(_gameSessionViewModel);

            gameSessionView.DataContext = _gameSessionViewModel;

            gameSessionView.Show();

        }
    }
}
