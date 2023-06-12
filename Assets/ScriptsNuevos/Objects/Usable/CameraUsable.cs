using UnityEngine;

public class CameraUsable : MonoBehaviour, iUsableObject
{
    Controles controls = null;

    public void Actions()
    {
        Debug.Log("flash");
    }

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
}
