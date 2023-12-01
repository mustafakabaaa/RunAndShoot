using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSFX : MonoBehaviour
{
    public AudioClip clickSound; // Sesi depolamak için bir deðiþken
    private Button button; // Buton referansý

    void Start()
    {
        // Buton referansýný al
        button = GetComponent<Button>();

        // Butonun týklama olayýna fonksiyonu baðla
        if (button != null)
        {
            button.onClick.AddListener(PlayClickSound);
        }
    }

    void PlayClickSound()
    {
        // Ses dosyasýný çal
        if (clickSound != null)
        {
            AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position);
        }
    }
}
