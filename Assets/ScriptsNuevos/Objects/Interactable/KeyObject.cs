using Data;
using UnityEngine;
using Player;

namespace Objects
{
    public class KeyObject : MonoBehaviour, iActionEjecutor
    {
        public KeyData Data => data;
        [SerializeField] private KeyData data;

        public void Action(GameObject player)
        {
            PlayerInventory playerInventory = player.GetComponent<PlayerInventory>();
            playerInventory.AddKey(data);
            Debug.Log("You pick the " + data.Place + "'s key");
            Destroy(gameObject);
        }
    }
}
