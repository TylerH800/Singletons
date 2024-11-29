using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip[] clips;
    public AudioSource musicSource;
    public AudioSource sfxSource;

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
        if (PlayerPrefs.HasKey("musicVol"))
        {
            PlayerPrefs.GetFloat("musicVol");
        }
        else
        {
            PlayerPrefs.SetFloat("musicVol", 0.5f);
        }

        if (PlayerPrefs.HasKey("sfxVol"))
        {
            PlayerPrefs.GetFloat("sfxVol");
        }
        else
        {
            PlayerPrefs.SetFloat("sfxVol", 0.5f);
        }

        if (PlayerPrefs.HasKey("masterVol"))
        {
            PlayerPrefs.GetFloat("masterVol");
        }
        else
        {
            PlayerPrefs.SetFloat("masterVol", 0.5f);
        }
    }

    public void PlayClip(int clipNumber, AudioSource source)
    {
        source.PlayOneShot(clips[clipNumber]); // start clip
    }


    public void StopClip()
    {
        musicSource.Stop();
        sfxSource.Stop();

    }
 

}

