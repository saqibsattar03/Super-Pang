using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 speed;

    public GameManager.Direction direction;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = new Vector2(20.0f, 0.0f);
        StartCoroutine(TestCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        moveLeft();
        moveRight();
       
    }

    void moveLeft()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.MovePosition(rb.position - speed * Time.deltaTime);
        }
    }

    void moveRight()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.MovePosition(rb.position + speed * Time.deltaTime);
        }
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.collider.tag == "ball")
        {
            Time.timeScale = 0;
            FindObjectOfType<GameManager>().panel.SetActive(true);
            Camera.main.GetComponentInChildren<AudioSource>().Stop();
        }

	}

    IEnumerator TestCoroutine()
	{
       
        yield return new WaitForSeconds(1);
        StartCoroutine(TestCoroutine());
	}


}
