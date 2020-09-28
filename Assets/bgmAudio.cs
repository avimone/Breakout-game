using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmAudio : MonoBehaviour
{
    public static bgmAudio instance;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        if (!bgmManager.initialized)
        {
            // initialize audio manager and persist audio source across scenes
            AudioSource audioSource1 = gameObject.GetComponent<AudioSource>();
            bgmManager.Initialize(audioSource1);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // duplicate game object, so destroy
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void des()
    {
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        bgmManager.initialized = false;
    }
}
