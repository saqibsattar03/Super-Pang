using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] ballPrefab;
    // Start is called before the first frame update
    void Start()
    {
       
        StartCoroutine(ballSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ballSpawner()
    {
        int randomIndex = Random.Range(0, ballPrefab.Length);
        Vector2 vect = new Vector2(Random.Range(0.0f, 6.0f),5.2f);
        Instantiate(ballPrefab[randomIndex], vect, Quaternion.identity);
        yield return new WaitForSeconds(4f);
        StartCoroutine(ballSpawner());
    }
}
