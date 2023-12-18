using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDeadControl : MonoBehaviour
{
    public Image RedScreen;
    public RectTransform ScreenA;

    void Start()
    {
        // Kýrmýzý ekraný baþlangýçta gizle
        RedScreen.color = new Color(1f, 0f, 0f, 0f);
    }

    void Update()
    {
        // Karakter öldüðünde
        if (GetComponent<PlayerHealth>().health <= 0)
        {
            StartCoroutine(DeadAnimation());
        }
    }

    IEnumerator DeadAnimation()
    {
        // Kýrmýzý ekran efektini aktif hale getir
        StartCoroutine(FadeIn(RedScreen, 4f));

        // Bekleme süresi (kýrmýzý ekranýn görünmesi için)
        float beklemeSuresi = 3f; // Örneðin 3 saniye bekleyelim
        yield return new WaitForSeconds(beklemeSuresi);

        // Ekranýn A özelliðini yükselterek çýkart
        while (ScreenA.anchoredPosition.y < 100f) // 100 deðeri örnek bir hedef deðerdir, kendi oyununuzda uygun bir deðer seçin
        {
            ScreenA.anchoredPosition += new Vector2(0f, 1f) * Time.deltaTime * 50f; // 50 deðeri örnek bir hýzdýr, kendi oyununuzda uygun bir deðer seçin
            yield return null;
        }

        // Sahne deðiþimi
        SceneManager.LoadScene(4); // "SonrakiSahne" kýsmýný kendi sahnenizle deðiþtirin
    }

    IEnumerator FadeIn(Image image, float fadeTime)
    {
        float elapsedTime = 0f;
        Color startColor = image.color;

        while (elapsedTime < fadeTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeTime);
            image.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        image.color = new Color(startColor.r, startColor.g, startColor.b, 1f); // Tamamen görünür yap
    }
}
