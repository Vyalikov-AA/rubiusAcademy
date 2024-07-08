using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts
{
    internal class PlayerMovementsHandler: IDisposable
    {
        private PlayerView _playerView;
        private readonly PlayerParametrsHandler _playerParametrsHandler;
        private readonly PlayerSpawner _playerSpawner;
        private readonly PlayerMovements _playerMovements;
        private readonly InputButtonHandler _inputButtonHandler;
        private readonly float _movementSpeed;
        private readonly float _rotateSpeed;
        public PlayerMovementsHandler(  PlayerView playerView, 
                                        PlayerParametrsHandler playerParametrsHandler, 
                                        PlayerSpawner playerSpawner,
                                        PlayerMovements playerMovements,
                                        InputButtonHandler inputButtonHandler) 
        {
            _playerView = playerView;
            _playerParametrsHandler = playerParametrsHandler;
            _playerSpawner = playerSpawner;
            _playerMovements = playerMovements;
            _inputButtonHandler = inputButtonHandler;
            _movementSpeed = _playerParametrsHandler.SpeedPlayer;
            _rotateSpeed = _playerParametrsHandler.RotatePlayer;
            _playerSpawner.PlayerSpawned += OnPlayerSpawned;
            _inputButtonHandler.ButtenPressed += OnButtonPressed;

        }

        private void OnButtonPressed(object sender, InputButtonHandler.ButtonPress e)
        {
            if (e == InputButtonHandler.ButtonPress.ButonForward)
            {
                _playerMovements.Move(_playerView, _movementSpeed, Vector3.forward);
            }
            if (e == InputButtonHandler.ButtonPress.ButonBack)
            {
                _playerMovements.Move(_playerView, _movementSpeed, Vector3.back);
            }
            if (e == InputButtonHandler.ButtonPress.ButonLeft)
            {
                _playerMovements.Rotate(_playerView, _rotateSpeed, Vector3.down);
            }
            if (e == InputButtonHandler.ButtonPress.ButonRight)
            {
                _playerMovements.Rotate(_playerView, _rotateSpeed, Vector3.up);
            }
        }

        private void OnPlayerSpawned(object sender, PlayerView e)
        {
            _playerView = e;
            _playerSpawner.PlayerSpawned += OnPlayerSpawned;
        }

        public void Dispose()
        {
            _playerSpawner.PlayerSpawned -= OnPlayerSpawned;
            _inputButtonHandler.ButtenPressed -= OnButtonPressed;
        }
    }
}
