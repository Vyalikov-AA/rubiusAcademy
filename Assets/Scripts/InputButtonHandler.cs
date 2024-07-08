using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class InputButtonHandler : MonoBehaviour
{
    [SerializeField] private string ButonForward, ButonBack, ButonLeft, ButonRight;
    public GameObject _coinGameObject;
    public GameObject _healthUpGameObject;
    public GameObject _healthDownGameObject;
    public event EventHandler<ButtonPress> ButtenPressed;

    public enum ButtonPress
    {
        ButonForward,
        ButonBack,
        ButonLeft,
        ButonRight,
        ButtonGetCoin,
        ButtonIncreaseHp,
        ButtonDecreaseHp,
        ButtonRestartLvl,
        ButtonLoadNextLvl,
        ButtonCamera
    }
    public void Update()
    {
        if (Input.GetKey(ButonForward))
        {
            ButtenPressed?.Invoke(this, ButtonPress.ButonForward);
        }
        if (Input.GetKey(ButonBack))
        {
            ButtenPressed?.Invoke(this, ButtonPress.ButonBack);
        }
        if (Input.GetKey(ButonLeft))
        {
            ButtenPressed?.Invoke(this, ButtonPress.ButonLeft);
        }
        if (Input.GetKey(ButonRight))
        {
            ButtenPressed?.Invoke(this, ButtonPress.ButonRight);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ButtenPressed?.Invoke(this, ButtonPress.ButtonGetCoin);
            Debug.Log("Spawn Coin object");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ButtenPressed?.Invoke(this, ButtonPress.ButtonIncreaseHp);
            Debug.Log("Spawn Increase Hp object");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ButtenPressed?.Invoke(this, ButtonPress.ButtonDecreaseHp);
            Debug.Log("Spawn Decrease Hp object");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ButtenPressed?.Invoke(this, ButtonPress.ButtonRestartLvl);
            Debug.Log("Restart Lvl");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ButtenPressed?.Invoke(this, ButtonPress.ButtonLoadNextLvl);
            Debug.Log("Load Next Lvl");
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            ButtenPressed?.Invoke(this, ButtonPress.ButtonCamera);
            Debug.Log("Change camera mod");
        }
    }
}
