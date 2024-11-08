using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("AudioClip")]
    public AudioClip audioClipDrill,audioClipTaskCompleted; 
    
    [Header("AudioSource")]
    public AudioSource audioSource;

    public static AudioController instance;
    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playDrillAudio(float audioSourcevolume)
    {
        print("audio player is called");
        if (!audioSource.isPlaying)
        {
         //   audioSource.Play();
        }
        audioSource.volume = 1f;
      
        Invoke(nameof(StopDrillAudio), 0.5f);

    }

    
    public void StopDrillAudio()
    {
        print("stop audio is called");
       // audioSource.volume = 0;
       // audioSource.Stop();
    }

    public void playTaskCompleteAudio()
    {
        audioSource.volume = 1;
        audioSource.PlayOneShot(audioClipTaskCompleted);

    }
}
