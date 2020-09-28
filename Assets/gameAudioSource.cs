using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameAudioSource : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        // make sure we only have one of this game object
        // in the game
        if (!audioManager.initialized)
        {
            // initialize audio manager and persist audio source across scenes
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioManager.Initialize(audioSource);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // duplicate game object, so destroy
            Destroy(gameObject);
        }
    }
}
