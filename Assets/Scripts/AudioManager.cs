using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

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




}

