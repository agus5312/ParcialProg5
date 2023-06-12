using Player;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    Controles controls = null;
    PlayerInventory playerInventory;
    private void Awake()
    {
        playerInventory = GetComponent<PlayerInventory>();

        controls = new Controles();

        controls.Player.Interact.started += ctx => MakeAction();
        controls.Player.Change.started += ctx => ChangeObject();
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    void MakeAction()
    {
        GameObject mainCamera1 = Camera.main.gameObject;
        Ray ray = new Ray(mainCamera1.transform.position, mainCamera1.transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.GetComponent<InteractableObject>())
            {
                hitInfo.collider.GetComponent<iActionEjecutor>().Action(this.gameObject);
            }
        }
    }
    void ChangeObject()
    {
        playerInventory.ChangeUsableObject(controls.Player.Change.ReadValue<Vector2>().y);
    }
}
