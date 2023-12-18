using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 5f;

    void Start()
    {
        // Alpha deðerini 0.0f (tamamen þeffaf) olarak ayarla
        canvasGroup.alpha = 0.0f;

        // Alpha deðerini zamanla deðiþtirmek için coroutine baþlat
        StartCoroutine(FadeInImage());
    }

    IEnumerator FadeInImage()
    {
        float currentTime = 0f;

        while (currentTime < fadeDuration)
        {
            // Alpha deðerini arttýr
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, currentTime / fadeDuration);

            // Zamaný güncelle
            currentTime += Time.deltaTime;

            yield return null; // Bir frame beklet
        }

        // 5 saniye sonra diðer sahneye geç
        yield return new WaitForSeconds(3f);

        // Ýkinci sahneye geçiþ yap
        SwitchToNextScene();
    }

    void SwitchToNextScene()
    {
       
        SceneManager.LoadScene(1);
    }
}
