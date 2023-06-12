using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightUsable : MonoBehaviour, iUsableObject
{
    Controles controls = null;
    bool isOn = false;
    public void Awake()
    {
        controls = new Controles();

        controls.Player.Actions.started += ctx => Actions();
    }

    public void OnDisable()
    {
        controls.Disable();
    }

    public void OnEnable()
    {
        controls.Enable();
    }
    public void Actions()
    {
        if (isOn)
        {
            Debug.Log("The flashlight is now off");
            isOn = false;
        }
        else
        {
            Debug.Log("The flashlight is now on");
            isOn = true;
        }
    }
}
