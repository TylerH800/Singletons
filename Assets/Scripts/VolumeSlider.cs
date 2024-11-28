using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;

    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
    }
    public void UpdateVolume()
    {
        AudioManager.instance.SetVolume(volumeSlider.value);
    }
}
