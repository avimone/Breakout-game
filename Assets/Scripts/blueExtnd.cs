using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueExtnd : MonoBehaviour
{
    public GameObject Extnd;
    public GameObject Shrnk;
    public GameObject ballMulty;
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
        if (collision.gameObject.tag == "ball")
        {
            int powerChooser = Random.Range(0, 4);
            if (powerChooser == 0)
            {
                Instantiate(Shrnk, transform.position, Quaternion.identity);
            }
            if (powerChooser == 1)
            {
                Instantiate(Extnd, transform.position, Quaternion.identity);
            }
            if (powerChooser == 2)
            {
                Instantiate(Shrnk, transform.position, Quaternion.identity);
            }
            if (powerChooser == 3)
            {
                Instantiate(ballMulty, transform.position, Quaternion.identity);
            }
            if (powerChooser == 4)
            {
                Instantiate(ballMulty, transform.position, Quaternion.identity);
            }
        }
    }
}
