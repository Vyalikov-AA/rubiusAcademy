using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class CameraMovements
    {
        private bool _modeCamera;
        private readonly GameObject _cameraGameObject;
        private PlayerView _playerView;


        public CameraMovements(GameObject cameraGameObject)
        {
            _cameraGameObject = cameraGameObject;
        }

        public void Move(PlayerView playerView)
        {
            if (!_modeCamera)
            {
                _playerView = playerView;
                _cameraGameObject.transform.SetPositionAndRotation(_playerView.transform.position - Vector3.back, _playerView.transform.rotation);
                _cameraGameObject.transform.SetParent(_playerView.transform, true);
                _modeCamera = true;
            }
            else
            {
                _cameraGameObject.transform.SetParent(null);
                _modeCamera = false;
            }
        }
    }
}
