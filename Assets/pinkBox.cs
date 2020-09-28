using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinkBox : MonoBehaviour
{
    // Start is called before the first frame update
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
            int lifeChooser = Random.Range(0, 19);
            if (lifeChooser == 0)
            {
                Instantiate(Lifeline, transform.position, Quaternion.identity);
            }
        }
    }
}
