using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scoreandretry : MonoBehaviour
{
    public Text HighScore;
    public Text Score;
    public Text coins;

    // Start is called before the first frame update
    void Start()
    {
        audioManager.Play(Soundname.gameover);
        Score.text = PlayerPrefs.GetInt("score").ToString();
        coins.text = PlayerPrefs.GetInt("coins").ToString();
   
      int getCoins = PlayerPrefs.GetInt("coins");
            AddCoins(getCoins);
        if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("highscore"))
        {
           int HighScore= PlayerPrefs.GetInt("score");
            PlayerPrefs.SetInt("highscore", HighScore);
        }
        HighScore.text = PlayerPrefs.GetInt("highscore").ToString();
    }
    public void AddCoins(int amount)
    {
        int TotalCoins = PlayerPrefs.GetInt("totalcoins");
        TotalCoins = TotalCoins + amount;
        PlayerPrefs.SetInt("totalcoins", TotalCoins);
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void mainmenu()
    {
        SceneManager.LoadScene("menu");
    }
    public void retry()
    {
        SceneManager.LoadScene("game");
    }
    public void gameexit()
    {
        Application.Quit();
    }
    public void next()
    {
        SceneManager.LoadScene("NextLevel");
    }
}
