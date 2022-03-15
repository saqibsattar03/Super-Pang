using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    public static bool IsFired = false;
    public Transform player;
    [SerializeField] float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        IsFired = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            IsFired = true;
        }
        if (IsFired)
        {
            transform.localScale = transform.localScale + Vector3.up * Time.deltaTime * speed;
            Debug.Log(transform.localScale);
        }
        else 
        {
            transform.position = player.position;
            transform.localScale = new Vector3(1.0f, 0.0f, 1.0f);
        }
        
    }
}
