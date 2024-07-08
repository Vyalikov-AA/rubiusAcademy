using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

namespace Assets.Scripts
{
    internal class CameraMovementsHandler: IDisposable
    {
        private PlayerView _playerView;
        private InputButtonHandler _inputButtonHandler;
        private CameraMovements _cameraMovements;
        private PlayerSpawner _playerSpawner;
        public CameraMovementsHandler(  PlayerView playerView, 
                                        InputButtonHandler inputButtonHandler, 
                                        CameraMovements cameraMovements, 
                                        PlayerSpawner playerSpawner)
        {
            _playerView = playerView;
            _inputButtonHandler = inputButtonHandler;
            _cameraMovements = cameraMovements;
            _playerSpawner = playerSpawner;
            _inputButtonHandler.ButtenPressed += OnButtenPressed;
            _playerSpawner.PlayerSpawned += OnPlayerSpawned;
        }
        private void OnPlayerSpawned(object sender, PlayerView e)
        {
            _playerView = e;
            _playerSpawner.PlayerSpawned += OnPlayerSpawned;
        }

        private void OnButtenPressed(object sender, InputButtonHandler.ButtonPress e)
        {
            if (e == InputButtonHandler.ButtonPress.ButtonCamera)
            {
                _cameraMovements.Move(_playerView);
            }
        }
        public void Dispose()
        {
            _inputButtonHandler.ButtenPressed -= OnButtenPressed;
        }
    }
}
