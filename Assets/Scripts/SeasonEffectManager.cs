using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SeasonEffectManager : MonoBehaviour
{
    public PostProcessVolume globalVolume;
    public float transitionDuration = 2f;

    public PostProcessProfile spring;
    public PostProcessProfile summer;
    public PostProcessProfile autumn;
    public PostProcessProfile winter;

    private Coroutine activeTransition;

    public void TransitionTo(string season)
    {
        PostProcessProfile target = season.ToLower() switch
        {
            "spring" => spring,
            "summer" => summer,
            "autumn" => autumn,
            "winter" => winter,
            _ => null
        };

        if (target == null)
        {
            Debug.LogWarning($"SeasonManager: No profile found for '{season}'");
            return;
        }

        if (activeTransition != null)
            StopCoroutine(activeTransition);

        activeTransition = StartCoroutine(Blend(target));
    }

    private IEnumerator Blend(PostProcessProfile target)
    {
        GameObject tempObj = new GameObject("_SeasonBlend");
        PostProcessVolume tempVol = tempObj.AddComponent<PostProcessVolume>();
        tempVol.isGlobal = true;
        tempVol.priority = globalVolume.priority + 1;
        tempVol.profile = target;
        tempVol.weight = 0f;

        float t = 0f;
        while (t < transitionDuration)
        {
            t += Time.deltaTime;
            tempVol.weight = Mathf.Clamp01(t / transitionDuration);
            yield return null;
        }

        globalVolume.profile = target;
        Destroy(tempObj);
    }
}