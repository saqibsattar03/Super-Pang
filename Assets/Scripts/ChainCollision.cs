using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainCollision : MonoBehaviour
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
        Chain.IsFired = false;
        if (collision.tag == "ball") 
        {
            collision.GetComponent<Ball>().ballSplit();
            FindObjectOfType<GameManager>().addScore();
        }
	}
}
