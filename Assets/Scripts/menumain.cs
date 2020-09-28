using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menumain : MonoBehaviour
{
    private void Awake()
    {
        int number2 = UnityEngine.Random.Range(0, 3);
        if (number2 == 0)
        {
            audioManager.Play(Soundname.main1);
        }
        if (number2 == 1)
        {
            audioManager.Play(Soundname.main2);
        }
        if (number2 == 2)
        {
            audioManager.Play(Soundname.main3);
        }
       // audioManager.Play(Soundname.main1);
    }
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gamestart()
    {
        audioManager.Stop();
        audioManager.Play(Soundname.play);
        SceneManager.LoadScene("game");
    }
    public void gameoptions()
    {
        audioManager.Stop();

        audioManager.Play(Soundname.play);
      
        SceneManager.LoadScene("optionmenu");
    }
   public void gameexit()
    {
        audioManager.Play(Soundname.quit);
        Application.Quit();
    }
     public void onHover()
    {
        audioManager.Play(Soundname.Hover);
    }
}
