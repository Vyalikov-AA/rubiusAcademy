using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class ActionsWithTheSceneHandler
    {
        private InputButtonHandler _inputButtonHandler;
        private ActionsWithTheScene _actionsWithTheScene;
        public ActionsWithTheSceneHandler(InputButtonHandler inputButtonHandler, ActionsWithTheScene actionsWithTheScene) 
        {
            _inputButtonHandler = inputButtonHandler;
            _actionsWithTheScene = actionsWithTheScene;
            _inputButtonHandler.ButtenPressed += OnButtenPressed;
        }

        private void OnButtenPressed(object sender, InputButtonHandler.ButtonPress e)
        {
            if (e == InputButtonHandler.ButtonPress.ButtonRestartLvl)
            {
                _actionsWithTheScene.RestartLevel();
            }
            if (e == InputButtonHandler.ButtonPress.ButtonLoadNextLvl)
            {
                _actionsWithTheScene.StartLevel2();
            }
        }
    }
}
