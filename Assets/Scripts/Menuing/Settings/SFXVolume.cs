using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SFXVolume : MonoBehaviour
{
    public Slider volumeSlider;
    public TextMeshProUGUI value;
    private void Start()
    {
        // Ensure the slider is not null
        if (volumeSlider != null)
        {
            volumeSlider.value = (((float)MainManager.instance.sfxVol)/100);
            AudioManager.instance.SFXVolume = volumeSlider.value;
            value.text = (int)(volumeSlider.value * 100) + "%";
           
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        }
        else
        {
            Debug.LogWarning("Volume slider is not assigned in the inspector.");
        }
    }

    
    private void OnVolumeChanged(float volume)
    {
        value.text = (int)(volume * 100)+ "%";
        MainManager.instance.sfxVol = (int)(volume*100);
        AudioManager.instance.SFXVolume = volume;
    }
}
