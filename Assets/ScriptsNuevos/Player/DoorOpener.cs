using Data;
using Objects;
using UnityEngine;

namespace Player
{

    public class DoorOpener : MonoBehaviour
    {
        PlayerInventory playerInventory;
        public void TryOpenDoor(DoorObject door)
        {
            playerInventory = FindObjectOfType<PlayerInventory>();
            if (playerInventory.keysHolder.Count != 0)
            {
                foreach (KeyData key in playerInventory.keysHolder)
                {
                    door.TryOpenWith(key);
                }
                door.Result();
            }
            else
                Debug.Log("I haven't any keys");
        }
    }
}
