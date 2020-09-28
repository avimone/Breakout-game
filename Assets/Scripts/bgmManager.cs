using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmManager 
{
    public static AudioSource audioSource1;
    public static Dictionary<Soundname, AudioClip> audioClips1 =
        new Dictionary<Soundname, AudioClip>();
    public static bool initialized = false;
    public static bool Initialized
    {
        get { return initialized; }
    }


    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource1 = source;
        audioClips1.Add(Soundname.bgm1,
           Resources.Load<AudioClip>("bgm1"));
        audioClips1.Add(Soundname.bgm2,
           Resources.Load<AudioClip>("bgm2"));
        audioClips1.Add(Soundname.bgm3,
           Resources.Load<AudioClip>("bgm3"));
        audioClips1.Add(Soundname.bgm4,
          Resources.Load<AudioClip>("bgm4"));
   
        audioClips1.Add(Soundname.bgm6,
         Resources.Load<AudioClip>("bgm6"));
        audioClips1.Add(Soundname.bgm7,
           Resources.Load<AudioClip>("bgm7"));
        audioClips1.Add(Soundname.bgm8,
           Resources.Load<AudioClip>("bgm8"));
        audioClips1.Add(Soundname.bgm9,
          Resources.Load<AudioClip>("bgm9"));
        audioClips1.Add(Soundname.bgm10,
          Resources.Load<AudioClip>("bgm10"));
        
        //   audioClips.Add(Soundname.menuintro,
        //       Resources.Load<AudioClip>(""));
        /*  audioClips.Add(AudioClipName.BurgerDeath,
              Resources.Load<AudioClip>("BurgerDeath"));
          audioClips.Add(AudioClipName.BurgerShot,
              Resources.Load<AudioClip>("BurgerShot"));
          audioClips.Add(AudioClipName.Explosion,
               Resources.Load<AudioClip>("Explosion"));
          audioClips.Add(AudioClipName.MenuButtonClick,
               Resources.Load<AudioClip>("ButtonClick"));
          audioClips.Add(AudioClipName.PauseGame,
                Resources.Load<AudioClip>("ButtonClick"));
          audioClips.Add(AudioClipName.TeddyShot,
              Resources.Load<AudioClip>("TeddyShot"));*/
    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(Soundname name)
    {
        audioSource1.clip = audioClips1[name];
        audioSource1.Play();
    }
    public static void Stop()
    {
       
        audioSource1.Stop();
    }
    public static void Pause()
    {
        audioSource1.volume = 0.1f;
      //  audioSource1.Pause();
    }
    public static void Resume()
    {

        audioSource1.volume = 0.5f;
    }
}
