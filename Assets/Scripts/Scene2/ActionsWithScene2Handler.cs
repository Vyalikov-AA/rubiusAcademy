using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scene2
{
    internal class ActionsWithScene2Handler:IDisposable
    {
        private readonly InputButtonHandlerScene2 _inputButtonHandler;
        private readonly ActionsWithScene2 _actionsWithTheScene;
        private readonly CubeCountHandler _cubeCountHandler;
        public ActionsWithScene2Handler(InputButtonHandlerScene2 inputButtonHandler,
                                        ActionsWithScene2 actionsWithTheScene2, 
                                        CubeCountHandler cubeCountHandler)
        {
            _inputButtonHandler = inputButtonHandler;
            _actionsWithTheScene = actionsWithTheScene2;
            _cubeCountHandler = cubeCountHandler;
            _inputButtonHandler.ButtonPressed    += OnButtonPressed;
            _cubeCountHandler.Condition         += OnCondition;
        }
        private void OnButtonPressed(object sender, InputButtonHandlerScene2.ButtonPress e)
        {
            if (e == InputButtonHandlerScene2.ButtonPress.ButtonRestartLvl)
            {
                _actionsWithTheScene.RestartLevel();
            }
            if (e == InputButtonHandlerScene2.ButtonPress.ButtonLoadNextLvl)
            {
                _actionsWithTheScene.StartLevel3();
            }
        }        
        private void OnCondition(object sender, EventArgs e)
        {
            _actionsWithTheScene.StartLevel3();
        }
        public void Dispose()
        {
            _inputButtonHandler.ButtonPressed    -= OnButtonPressed;
            _cubeCountHandler.Condition         -= OnCondition;
        }
    }
}
