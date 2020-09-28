using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    // Start is called before the first frame update
    public static Level2 instance;
    [SerializeField]
    public GameObject paddlePrefab = default;
    [SerializeField]
    private GameObject standardBlockPrefab = default;
    [SerializeField]
    private GameObject bonusBlockPrefab = default;
    [SerializeField]
    private GameObject pickupBlockPrefab = default;
    [SerializeField]
    private GameObject blueblock = default;
    [SerializeField]
    private GameObject greenblock = default;
    [SerializeField]
    private GameObject redblock = default;
    [SerializeField]
    private GameObject orangeblock = default;
    [SerializeField]
    private GameObject whiteblock = default;
    public static bool gameIsPaused;

    public int lives;
    [SerializeField]
    GameObject ball;
    bool gamestart = false;
    public static GameObject cpad;
    public static Vector2 ballpos;
    public static Vector2 pos;
    public bool RealGameOver;
    private Vector2 paddleSpawnPos;
    public int coinCollected;
    public GameObject[] blockstart;
    [SerializeField]
    AnimationClip introPause;
    [SerializeField]
    AnimationClip outtroPause;
    [SerializeField]
    GameObject pausePanel;
    public int UltimateCount;
    public Animator trans;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        int number1 = UnityEngine.Random.Range(0, 9);
        if (number1 == 0)
        {
            bgmManager.Play(Soundname.bgm1);
        }
        if (number1 == 1)
        {
            bgmManager.Play(Soundname.bgm2);
        }
        if (number1 == 2)
        {
            bgmManager.Play(Soundname.bgm3);
        }
        if (number1 == 3)
        {
            bgmManager.Play(Soundname.bgm4);
        }
        if (number1 == 4)
        {
            bgmManager.Play(Soundname.bgm5);
        }
        if (number1 == 5)
        {
            bgmManager.Play(Soundname.bgm10);
        }
        if (number1 == 6)
        {
            bgmManager.Play(Soundname.bgm7);
        }
        if (number1 == 7)
        {
            bgmManager.Play(Soundname.bgm8);
        }
        if (number1 == 8)
        {
            bgmManager.Play(Soundname.bgm9);
        }

        lives = 3;
        UltimateCount = 0;
        gameIsPaused = false;
        coinCollected = 0;
        RealGameOver = false;
        paddleSpawnPos = new Vector2(
           (ScreenUtils.ScreenRight + ScreenUtils.ScreenLeft) / 2, ScreenUtils.ScreenBottom - 4.5f);
        cpad = Instantiate(paddlePrefab, paddleSpawnPos, Quaternion.identity);
        ballpos = cpad.transform.position;
        ballpos.y += 0.5f;
        // pos = ballpos.transform.position;
        Instantiate(ball, ballpos, Quaternion.identity);
        gamestart = true;
      //  buildlevel();
        blockstart = GameObject.FindGameObjectsWithTag("Block");

    }

    public void buildlevel()
    {
        float row = 4.6f;
        float col = 7.5f;
        for (float i = 0; i < row; i = i + 0.7f)
        {

            for (float j = -6.8f; j < col; j = j + 0.7f)
            {

                int number = UnityEngine.Random.Range(0, 12);


                if (number >= 0 && number < 2)
                {
                    Instantiate(standardBlockPrefab, new Vector2(j, i), Quaternion.identity);
                }
                else if (number == 5 || number == 2)
                {
                    Instantiate(bonusBlockPrefab, new Vector2(j, i), Quaternion.identity);
                }
                else if (number == 4 || number == 11)
                {
                    Instantiate(pickupBlockPrefab, new Vector2(j, i), Quaternion.identity);
                }
                else if (number == 6)
                {
                    Instantiate(blueblock, new Vector2(j, i), Quaternion.identity);
                }
                else if (number == 7)
                {
                    Instantiate(redblock, new Vector2(j, i), Quaternion.identity);
                }
                else if (number == 8)
                {
                    Instantiate(orangeblock, new Vector2(j, i), Quaternion.identity);
                }
                else if (number == 9)
                {
                    Instantiate(whiteblock, new Vector2(j, i), Quaternion.identity);
                }
                else if (number == 10 || number == 3)
                {
                    Instantiate(greenblock, new Vector2(j, i), Quaternion.identity);
                }
            }


        }
    }
    public void incLife()
    {
        lives++;
    }
    public void decLife()
    {
        lives--;
    }

    // Update is called once per frame
    void Update()
    {
        pos = cpad.transform.position;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;

            PauseGame();

        }
        balldied();

    }
    public void balldied()
    {
        bool blockisthere = GameObject.FindWithTag("Block");
        bool ballisthere = GameObject.FindWithTag("ball");
        if (UltimateCount == blockstart.Length || blockisthere == false)
        {
            RealGameOver = true;
        }
        if (ballisthere == false)
        {
            decLife();
            if (lives >= 0)
            {
                Instantiate(ball, ballpos, Quaternion.identity);
            }
            else
            {
                bgmManager.Stop();
                // bgmAudio.instance.des();
                SceneManager.LoadScene("gameover");
            }
        }
        if (lives < 0)
        {
            RealGameOver = true;
            //   bgmAudio.instance.des();
            bgmManager.Stop();
        }
        if (RealGameOver)
        {
            GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
            int remainingBlocks = blockstart.Length - blocks.Length;
            PlayerPrefs.SetInt("coins", coinCollected);
            PlayerPrefs.SetInt("score", (coinCollected * (lives + 1)) + remainingBlocks);
            SceneManager.LoadScene("gameover");
        }

    }

    public void PauseGame()
    {
        if (gameIsPaused)
        {
            pausePanel.SetActive(true);
            bgmManager.Pause();
            Time.timeScale = 0f;
        }
        else
        {


            pausePanel.SetActive(false);
            Time.timeScale = 1;
            bgmManager.Resume();

        }
    }
    public void mainmenu()
    {
        bgmManager.Stop();
        Time.timeScale = 1;
        SceneManager.LoadScene("menu");
    }
    public void gameexit()
    {
        Time.timeScale = 1;
        bgmManager.Stop();
        Application.Quit();
    }
    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        gameIsPaused = false;
        Time.timeScale = 1;
    }
    public void coinCount()
    {
        coinCollected++;
    }
}
