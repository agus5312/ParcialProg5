using System.Collections.Generic;
using Data;
using UnityEngine;

namespace Player
{
    public class PlayerInventory : MonoBehaviour
    {
        public List<KeyData> keysHolder => _keysHolder;
        private List<KeyData> _keysHolder = new List<KeyData>();

        public List<GameObject> usableObjects => _usableObjects;
        private List<GameObject> _usableObjects = new List<GameObject>();

        int actualObject;

        public void AddKey(KeyData key)
        {
            if (key == null)
                return;

            _keysHolder.Add(key);
        }
        public void AddObject(GameObject usableObject)
        {
            if (usableObject == null)
                return;
            _usableObjects.Add(usableObject);
        }

        public void ChangeUsableObject(float value)
        {
            if (value > 0 && usableObjects.Count > 0)
            {
                usableObjects[actualObject].SetActive(false);
                actualObject--;
                if (actualObject < 0)
                {
                    actualObject = usableObjects.Count - 1;
                }
                usableObjects[actualObject].SetActive(true);
            }
            else if (value < 0 && usableObjects.Count > 0)
            {
                usableObjects[actualObject].SetActive(false);
                actualObject++;
                if (actualObject > usableObjects.Count - 1)
                {
                    actualObject = 0;
                }
                usableObjects[actualObject].SetActive(true);
            }
        }
    }
}
