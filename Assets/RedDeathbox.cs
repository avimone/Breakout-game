using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDeathbox : MonoBehaviour
{
    public GameObject Deathline;
    public GameObject Lifeline;
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
            int DeathChooser = Random.Range(0, 4);
            if (DeathChooser == 0)
            {
                Instantiate(Deathline, transform.position, Quaternion.identity);
            }
            if (DeathChooser == 2)
            {
                Instantiate(Lifeline, transform.position, Quaternion.identity);
            }
            if (DeathChooser == 3)
            {
                Instantiate(Lifeline, transform.position, Quaternion.identity);
            }
        }
    }
}
