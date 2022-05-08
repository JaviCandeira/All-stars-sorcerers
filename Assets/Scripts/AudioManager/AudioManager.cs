using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectSource;

    void Awake() {
      if (Instance == null){
        Instance = this;
        DontDestroyOnLoad(gameObject);
      }
      else {
        Destroy(gameObject);
      }
    }

    public void PlaySound(AudioClip clip) {
      if(effectSource.mute == false){
      effectSource.PlayOneShot(clip);
      }
    }

    public void ChangeMasterVolume(float value){
      AudioListener.volume = value;
    }

    public void ToggleSounds(){
      musicSource.mute = !musicSource.mute;
      effectSource.mute = !effectSource.mute;
    }

    public void Update(){
      Debug.Log(effectSource.mute);
    }
}
