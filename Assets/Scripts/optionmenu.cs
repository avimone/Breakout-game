using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class optionmenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void mainmenu()
    {
        audioManager.Play(Soundname.play);
       
        SceneManager.LoadScene("menu");
    }
    public void soundoffon()
    {
        SceneManager.LoadScene("optionmenu");
    }
    public void gameexit()
    {
        audioManager.Play(Soundname.quit);
      //  SceneManager.LoadScene("game");
       Application.Quit();
    }
    public void onHover()
    {
        audioManager.Play(Soundname.Hover);
    }
    
}
