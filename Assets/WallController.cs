using UnityEngine;

public class WallController : MonoBehaviour
{

    [SerializeField] private GameObject objectToRemove;
    [SerializeField] private string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            if (objectToRemove != null)
            {
                Destroy(objectToRemove);
            }
            Destroy(gameObject);
        }
    }
}

