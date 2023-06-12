using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] GameObject indicator;
    GameObject player;
    private void Awake()
    {
        if (FindObjectOfType<ActionController>())
        {
            player = FindObjectOfType<ActionController>().gameObject;
        }
        else
            Debug.LogWarning("Player not found");
    }

    private void OnMouseEnter()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 3)
        {
            indicator.SetActive(true);
        }
    }

    private void OnMouseOver()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 3)
        {
            indicator.SetActive(true);
        }
        else
        {
            indicator.SetActive(false);
        }
    }

    private void OnMouseExit()
    {
        indicator.SetActive(false);
    }
}
