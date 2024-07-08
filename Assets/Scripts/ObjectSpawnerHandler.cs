using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class ObjectSpawnerHandler
    {
        private readonly InputButtonHandler _inputButtonHandler;
        private ObjectSpawner _objectSpawner;
        public ObjectSpawnerHandler(InputButtonHandler inputButtonHandler, ObjectSpawner objectSpawner) 
        {
            _inputButtonHandler = inputButtonHandler;
            _objectSpawner = objectSpawner;
            _inputButtonHandler.ButtenPressed += OnButtenPressed;
        }

        private void OnButtenPressed(object sender, InputButtonHandler.ButtonPress type)
        {
            if (type == InputButtonHandler.ButtonPress.ButtonGetCoin) 
            {
                _objectSpawner.Spawn(_inputButtonHandler._coinGameObject);
            }
            if (type == InputButtonHandler.ButtonPress.ButtonIncreaseHp)
            {
                _objectSpawner.Spawn(_inputButtonHandler._healthUpGameObject);
            }
            if (type == InputButtonHandler.ButtonPress.ButtonDecreaseHp)
            {
                _objectSpawner.Spawn(_inputButtonHandler._healthDownGameObject);
            }
        }
    }
}
