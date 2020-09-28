using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackbox : MonoBehaviour
{
    public int flag;
    public SpriteRenderer bb;
    public Sprite newSprite;
    public Sprite newSprite2;
    // Start is called before the first frame update
    void Start()
    {
        flag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
          
            if(flag>1)
            {
                audioManager.Play(Soundname.blockpink);
                Destroy(gameObject);
                Levelbuild.instance.UltimateCount++;
            }
            flag++;
            if (flag == 1)
            {
                audioManager.Play(Soundname.blockblack);
                bb.sprite = newSprite;
            }
            if (flag == 2)
            {
                audioManager.Play(Soundname.blockblack);
                bb.sprite = newSprite2;
            }
        }
    }
}
