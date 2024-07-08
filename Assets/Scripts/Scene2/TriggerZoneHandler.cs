using Assets.Scripts.Scene2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class TriggerZoneHandler : IDisposable
{
    private readonly TriggerZone[] _triggerZone = new TriggerZone[2];
    private readonly CubeCountHandler _cubeCountHandler;
    public TriggerZoneHandler(TriggerZone[] triggerZone, CubeCountHandler cubeCountHandler)
    {
        _cubeCountHandler = cubeCountHandler;
        for (int i = 0; i < _triggerZone.Length; i++)
        {
            _triggerZone[i] = triggerZone[i];
            _triggerZone[i].TriggerHappaned += OnTriggerHappaned;
            _triggerZone[i].TriggerEnd += OnTriggerEnd;
        }
    }
    private void OnTriggerHappaned(object sender, (string, string) e)
    {
        if (e.Item1 == e.Item2)
        {
            if (e.Item1 == "Red")
            {
                _cubeCountHandler.InRedZone++;
                _cubeCountHandler.ConditionForNextLvl();
                Debug.Log("In red zone = " + _cubeCountHandler.InRedZone + " cube");
                Debug.Log("Count of red cube = " + _cubeCountHandler.RedCubeCount + " cube");
            }
            if (e.Item1 == "Blue")
            {
                _cubeCountHandler.InBlueZone++;
                _cubeCountHandler.ConditionForNextLvl();
                Debug.Log("In blue zone = " + _cubeCountHandler.InBlueZone + " cube");
                Debug.Log("Count of blue cube = " + _cubeCountHandler.BlueCubeCount + " cube");
            }               
        }
    }
    private void OnTriggerEnd(object sender, (string, string) e)
    {
        if (e.Item1 == e.Item2)
        {
            if (e.Item1 == "Red")
            {
                _cubeCountHandler.InRedZone--;
                Debug.Log("In red zone = " + _cubeCountHandler.InRedZone + " cube");
                Debug.Log("Count of red cube = " + _cubeCountHandler.RedCubeCount + " cube");
            }
            if (e.Item1 == "Blue")
            {
                _cubeCountHandler.InBlueZone--;
                Debug.Log("In blue zone = " + _cubeCountHandler.InBlueZone + " cube");
                Debug.Log("Count of blue cube = " + _cubeCountHandler.BlueCubeCount + " cube");
            }
        }
    }
    public void Dispose()
    {
        for (int i = 0; i < _triggerZone.Length; i++)
        {
            _triggerZone[i].TriggerHappaned -= OnTriggerHappaned;
            _triggerZone[i].TriggerEnd -= OnTriggerEnd;
        }
    }
}
