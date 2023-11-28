// DamageIndicator.cs

using System.Collections;
using UnityEngine;

public class DamageIndicator : MonoBehaviour
{
    public CanvasGroup damageCanvasGroup;
    public float fadeDuration = 1.5f;

    void Start()
    {
        damageCanvasGroup = GetComponent<CanvasGroup>();
    }

    public void ShowDamageIndicator()
    {
        StartCoroutine(FadeCanvasGroup());
    }

    IEnumerator FadeCanvasGroup()
    {
        damageCanvasGroup.alpha = 1f;

        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            damageCanvasGroup.alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            yield return null;
        }

        damageCanvasGroup.alpha = 0f;
    }
}
