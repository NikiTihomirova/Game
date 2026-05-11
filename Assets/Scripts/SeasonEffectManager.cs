using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class SeasonEffectManager : MonoBehaviour
{
    public Volume globalVolume;

    public VolumeProfile spring;
    public VolumeProfile summer;
    public VolumeProfile autumn;
    public VolumeProfile winter;

    public float transitionDuration = 2f;

    private Coroutine activeTransition;

    public void TransitionTo(string season)
    {
        VolumeProfile target = season.ToLower() switch
        {
            "spring" => spring,
            "summer" => summer,
            "autumn" => autumn,
            "winter" => winter,
            _ => null
        };

        if (target == null || globalVolume == null)
        {
            Debug.LogError("Missing reference!");
            return;
        }

        if (activeTransition != null)
            StopCoroutine(activeTransition);

        activeTransition = StartCoroutine(Blend(target));
    }

    private IEnumerator Blend(VolumeProfile target)
    {
        VolumeProfile startProfile = globalVolume.profile;
        VolumeProfile temp = ScriptableObject.Instantiate(target);

        globalVolume.profile = temp;

        float t = 0f;

        while (t < transitionDuration)
        {
            t += Time.deltaTime;
            globalVolume.weight = Mathf.Clamp01(t / transitionDuration);
            yield return null;
        }

        globalVolume.profile = target;
        globalVolume.weight = 1f;
    }
}