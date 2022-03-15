using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text textScore;
    public GameObject panel;

    public enum Direction { North, East, South, West };



    public static GameManager instance;


    void Awake()
	{
       


        if (instance != null)
		{
            Destroy(gameObject);
		}
		else
		{
            instance = this;
		}
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = "Score:" + score;
    }

    public void addScore()
    {
        score += 1;
    }

    public void restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
