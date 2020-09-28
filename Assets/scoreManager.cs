using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public static scoreManager instance;
    [SerializeField]
    Text highScoreTextField;
    [SerializeField]
    Text coinTextField;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinTextField.text = PlayerPrefs.GetInt("totalcoins").ToString();
        highScoreTextField.text = PlayerPrefs.GetInt("highscore").ToString();
    }
 
}
