using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class valueSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer AuMixer;
    [SerializeField] private Slider musicSlider;

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        AuMixer.SetFloat("music",Mathf.Log10((float)volume)*20);
    }
}
