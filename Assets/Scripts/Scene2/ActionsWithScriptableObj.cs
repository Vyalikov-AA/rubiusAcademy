using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsWithScriptableObj : MonoBehaviour
{
    private CubesScriptableObjects _scriptableObjects;
    private string _tagName;
    private bool _onOffTriger;

    public ActionsWithScriptableObj(string _string, CubesScriptableObjects scriptableObjects, bool _bool)
    {
        _scriptableObjects = scriptableObjects;
        _tagName = _string;
        _onOffTriger = _bool;
        _mathOperation();
    }

    private void _mathOperation()
    {
        if (_tagName == "BlueCube")
        {
            if (_onOffTriger)
            {
                _scriptableObjects.CountOfCubeInBlueZone++;
            }
            else
            {
                _scriptableObjects.CountOfCubeInBlueZone--;
            }
        }
        if (_tagName == "RedCube")
        {
            if (_onOffTriger)
            {
                _scriptableObjects.CountOfCubeInRedZone++;
            }
            else
            {
                _scriptableObjects.CountOfCubeInRedZone--;
            }
        }
    }
}
