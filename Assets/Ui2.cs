using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ui2 : MonoBehaviour
{
    public Text Life;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string s = Level2.instance.lives.ToString();
        Life.text = s;
    }
}
