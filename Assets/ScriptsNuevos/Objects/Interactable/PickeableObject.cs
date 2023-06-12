using System.Collections;
using Player;
using UnityEngine;

public class PickeableObject : MonoBehaviour, iActionEjecutor
{
    PlayerInventory playerInventory;
    [SerializeField] GameObject objectPrefab;
    [SerializeField] GameObject parent;
    [SerializeField] Vector3 posInParent = new Vector3(0.655f,-0.422f,0.805f);

    public void Action(GameObject player)
    {
        playerInventory = player.GetComponent<PlayerInventory>();
        GameObject prefab = Instantiate(objectPrefab);
        playerInventory.AddObject(prefab);
        prefab.transform.parent = parent.transform;
        prefab.transform.localRotation = new Quaternion(0,0,0,0);
        prefab.transform.localPosition = posInParent;
        if(playerInventory.usableObjects.Count > 1)
        {
            prefab.SetActive(false);
        }
        Debug.Log("You pick a " + gameObject.name);
        Destroy(gameObject);   
    }
}
