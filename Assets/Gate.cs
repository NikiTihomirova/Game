using UnityEngine;

public class Gate : MonoBehaviour
{
    public SeasonType requiredSeason; // сезон, който трябва да се отключен

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Проверява дали сезонът е отключен
            if (SeasonManager.Instance.IsSeasonUnlocked(requiredSeason))
            {
                Debug.Log("Преминаване разрешено към следващия сезон");
                Destroy(gameObject); // изчезва вратата
            }
            else
            {
                Debug.Log("Не можеш да преминеш – първо вземи предмета");
            }
        }
    }
}
