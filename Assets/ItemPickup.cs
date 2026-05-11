using UnityEngine;
using StarterAssets;

public class ItemPickup : MonoBehaviour
{
    public SeasonType seasonToUnlock;

    public ThirdPersonController player;
    public GameObject restartPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SeasonManager.Instance.UnlockSeasonNext(seasonToUnlock);

            if (gameObject.name == "water")
            {
                restartPanel.SetActive(true);
                player.canMove = false;
                Time.timeScale = 0f;
            }

            Destroy(gameObject);
        }
    }
}