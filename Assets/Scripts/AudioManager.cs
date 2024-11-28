using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private float volume;

    public AudioClip[] clips;
    AudioSource audioSource; //reference to the audio source component on the game object

    void Awake()
    {
        // if instance is null, store a reference to this instance
        if (instance == null)
        {
            // a reference does not exist, so store it
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Another instance of this gameobject has been made so destroy it
            // as we already have one
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume", 0.5f);
        }
    }

    public void PlayClip(int clipNumber, float volume)
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(clips[clipNumber], volume); // start clip
    }


    public void StopClip()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop(); //stop currently playing clip

    }
    #region Volume
    public void SetVolume(float enteredVol)
    {
        volume = enteredVol;
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public float GetVolume()
    {
        return PlayerPrefs.GetFloat("Volume");
    }

    #endregion
}

