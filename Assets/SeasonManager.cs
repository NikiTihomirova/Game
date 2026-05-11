using UnityEngine;
using System.Collections.Generic;
using StarterAssets;

public class SeasonManager : MonoBehaviour
{
    public static SeasonManager Instance { get; private set; }

    private HashSet<SeasonType> unlocked = new HashSet<SeasonType>();

    [Header("Collectibles")]
    public int totalItems = 4; // колко предмета имаш общо
    private int collectedItems = 0;

    [Header("End Game")]
    public GameObject restartPanel;
    public ThirdPersonController player;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void UnlockSeasonNext(SeasonType season)
    {
        // отключване на сезон
        unlocked.Add(season);

        // броене на предмети
        collectedItems++;

        Debug.Log($"Събрани предмети: {collectedItems}");

        CheckIfGameFinished();
    }

    public bool IsSeasonUnlocked(SeasonType season)
    {
        return unlocked.Contains(season);
    }

    private void CheckIfGameFinished()
    {
        if (collectedItems >= totalItems)
        {
            Debug.Log("Взе последния предмет!");

            restartPanel.SetActive(true);
            player.canMove = false;
            Time.timeScale = 0f;
        }
    }
}