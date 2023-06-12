using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Key", menuName = "Items/Key")]
    public class KeyData : ScriptableObject
    {
        public string Place => place;
        [SerializeField] private string place;
    }
}
