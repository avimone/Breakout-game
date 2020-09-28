﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pad") || collision.gameObject.CompareTag("ball"))
        {
            audioManager.Play(Soundname.blockred);
            paddle.instance.sizedown();
            Destroy(gameObject);
        }
    }
}
