using Data;
using Player;
using UnityEngine;

namespace Objects
{
    public class DoorObject : MonoBehaviour, iActionEjecutor
    {
        bool IsOpen;

        [SerializeField] private KeyData keyNeeded;

        private void Start()
        {
            IsOpen = false;
        }

        public void TryOpenWith(KeyData key)
        {
            if (IsOpen)
            {
                Debug.Log("Already opened");
                return;
            }

            if (key == keyNeeded)
            {
                Open(key);
            }
        }

        public void Result()
        {
            if(IsOpen == false)
                Debug.Log("I don't have the Key");
        }

        private void Open(KeyData key)
        {
            IsOpen = true;
            Debug.Log("The " + key.Place + "'s key works! The door is now open");
        }

        public void Action(GameObject player)
        {
            DoorOpener doorOpener = player.GetComponent<DoorOpener>();
            if (player == null)
            {
                Debug.LogWarning("There is no -DoorOpener-");
            }
            else
            {
                doorOpener.TryOpenDoor(this);
            }
        }
    }
}
