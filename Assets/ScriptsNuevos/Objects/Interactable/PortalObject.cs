using System.Collections;
using StarterAssets;
using UnityEngine;

public class PortalObject : MonoBehaviour, iActionEjecutor
{
    [SerializeField] GameObject connectedPortal;

    public void Action(GameObject player)
    {
        StartCoroutine(Teleport(player));
    }

    IEnumerator Teleport(GameObject player)
    {
        FirstPersonController characterController = FindObjectOfType<FirstPersonController>();
        characterController.enabled = false;
        yield return new WaitForEndOfFrame();
        player.transform.position = connectedPortal.transform.position - connectedPortal.transform.forward;
        player.transform.rotation = Quaternion.Euler(0, 180, 0);
        yield return new WaitForEndOfFrame();
        characterController.enabled = true;
    }
}
