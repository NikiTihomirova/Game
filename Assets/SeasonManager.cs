using UnityEngine;
using System.Collections.Generic;

public class SeasonManager : MonoBehaviour
{
    public static SeasonManager Instance { get; private set; }
    private HashSet<SeasonType> unlocked = new HashSet<SeasonType>();

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
        if (unlocked.Add(season))
        {
            Debug.Log($"Season unlocked: {season}");
        }
    }

    public bool IsSeasonUnlocked(SeasonType season)
    {
        return unlocked.Contains(season);
    }
}
