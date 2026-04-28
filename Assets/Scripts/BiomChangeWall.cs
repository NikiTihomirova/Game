using UnityEngine;

public class BiomChangeWall : MonoBehaviour
{
    public string season = "Summer";
    private SeasonEffectManager seasonManager;

    void Start()
    {
        seasonManager = FindAnyObjectByType<SeasonEffectManager>();
        GetComponent<Collider>().isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            seasonManager.TransitionTo(season);
    }
}
