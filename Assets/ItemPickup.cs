using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public SeasonType seasonToUnlock; // кой сезон отключва този предмет

    private void OnTriggerEnter(Collider other)
    {
        // Проверява дали това е играчът
        if (other.CompareTag("Player"))
        {
            // Извиква SeasonManager, за да отключи следващия сезон
            SeasonManager.Instance.UnlockSeasonNext(seasonToUnlock);

            // Изтрива предмета от сцената
            Destroy(gameObject);
        }
    }
}
