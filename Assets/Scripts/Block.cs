using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ball"))
        {
            audioManager.Play(Soundname.blockpink);
            Levelbuild.instance.UltimateCount++;
          //  Level2.instance.UltimateCount++;
            Destroy(gameObject);
        }
    }
}
