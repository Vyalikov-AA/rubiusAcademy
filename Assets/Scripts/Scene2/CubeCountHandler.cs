using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scene2
{
    internal class CubeCountHandler
    {
        private int _redCubeCount;
        private int _blueCubeCount;
        private int _inRedZone;
        private int _inBlueZone;
        public event EventHandler Condition;
        public int RedCubeCount
        {
            get => _redCubeCount;
            set => _redCubeCount = value;
        }
        public int BlueCubeCount
        {
            get => _blueCubeCount;
            set => _blueCubeCount = value;
        }
        public int InRedZone
        {
            get => _inRedZone;
            set => _inRedZone = value;
        }
        public int InBlueZone
        {
            get => _inBlueZone;
            set => _inBlueZone = value;
        }
        public CubeCountHandler(CubesScriptableObjects scriptableObjects)
        {
            _redCubeCount = scriptableObjects.CountOfCubeRed;
            _blueCubeCount = scriptableObjects.CountOfCubeBlue;
            _inRedZone = scriptableObjects.CountOfCubeInRedZone;
            _inBlueZone = scriptableObjects.CountOfCubeInBlueZone;
            if ((_inBlueZone == _blueCubeCount) && (_inRedZone == _redCubeCount))
            {
                Condition?.Invoke(this, new EventArgs());
            }
        }
        public void ConditionForNextLvl()
        {
            if ((_inBlueZone == _blueCubeCount) && (_inRedZone == _redCubeCount))
            {
                Condition?.Invoke(this, new EventArgs());
            }
        }
    }
}
