using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scene2
{
    internal class SpawnCubesHandler
    {
        private readonly SpawnCubes _spawnCubes;
        private readonly CubeCountHandler _cubeCountHandler;
        private readonly InputButtonHandlerScene2 _inputButtonHandler;
        public SpawnCubesHandler(   InputButtonHandlerScene2 inputButtonHandler, 
                                    SpawnCubes spawnCubes, 
                                    CubeCountHandler cubeCountHandler)
        {
            _inputButtonHandler = inputButtonHandler;
            _spawnCubes = spawnCubes;
            _cubeCountHandler = cubeCountHandler;
            _inputButtonHandler.ButtonPressed += OnButtonPressed;
        }
        private void OnButtonPressed(object sender, InputButtonHandlerScene2.ButtonPress e)
        {
            if (e == InputButtonHandlerScene2.ButtonPress.ButonRedCube)
            {
                _spawnCubes.Spawn(_inputButtonHandler.GameObjectRedCube);
                _cubeCountHandler.RedCubeCount++;
            }
            if (e == InputButtonHandlerScene2.ButtonPress.ButonBlueCube)
            {
                _spawnCubes.Spawn(_inputButtonHandler.GameObjectBlueCube);
                _cubeCountHandler.BlueCubeCount++;
            }
        }
    }
}
