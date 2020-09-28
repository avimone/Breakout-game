using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager 
{
   public static AudioSource audioSource;
    public static Dictionary<Soundname, AudioClip> audioClips =
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
        audioSource = source;
        audioClips.Add(Soundname.paddlehits,
           Resources.Load<AudioClip>("paddlepop"));
        audioClips.Add(Soundname.blockblack,
           Resources.Load<AudioClip>("multyball"));
        audioClips.Add(Soundname.multi,
           Resources.Load<AudioClip>("balls"));
        audioClips.Add(Soundname.blockblue,
          Resources.Load<AudioClip>("extend"));
        audioClips.Add(Soundname.blockred,
          Resources.Load<AudioClip>("Powerdown"));
        audioClips.Add(Soundname.blockpink,
         Resources.Load<AudioClip>("ThudHit"));
        audioClips.Add(Soundname.gameover,
           Resources.Load<AudioClip>("Gameover"));
        audioClips.Add(Soundname.bgm,
           Resources.Load<AudioClip>("gamesong"));
        audioClips.Add(Soundname.life,
          Resources.Load<AudioClip>("GoodPowerup"));
        audioClips.Add(Soundname.play,
          Resources.Load<AudioClip>("on"));
        audioClips.Add(Soundname.quit,
          Resources.Load<AudioClip>("off"));
        audioClips.Add(Soundname.Hover,
       Resources.Load<AudioClip>("button2"));
        audioClips.Add(Soundname.main1,
         Resources.Load<AudioClip>("main1"));
        audioClips.Add(Soundname.main2,
          Resources.Load<AudioClip>("main2"));
        audioClips.Add(Soundname.main3,
       Resources.Load<AudioClip>("main3"));
        audioClips.Add(Soundname.coin,
 Resources.Load<AudioClip>("bonus_coin_1"));
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
        audioSource.PlayOneShot(audioClips[name]);
    }
    public static void Stop()
    {

        audioSource.Stop();
    }
    public static void Pause()
    {

        audioSource.Pause();
    }
    public static void Resume()
    {

        audioSource.Play();
    }
 
}
