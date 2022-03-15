using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject nextBall;
    public Rigidbody2D rb;
    private Vector2 startForce;
    [SerializeField] GameObject ballParticle;
    [SerializeField] AudioClip explodeSound;
    private AudioSource ballExplodeSound;

    private void Awake()
    {
        startForce = new Vector2(Random.Range(0.0f, 2.5f), 0.0f);
    }
    // Start is called before the first frame update
    void Start()
    {
        ballExplodeSound = GetComponent<AudioSource>();

        rb.AddForce(startForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ballSplit()
    {
        if (nextBall != null)
        {
            GameObject ball1 = Instantiate(nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
            GameObject ball2 = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);
            ball1.GetComponent<Ball>().startForce = new Vector2(2f, 4f);
            ball2.GetComponent<Ball>().startForce = new Vector2(-2f, 4f);
            explode();
        }
        lastBallExplode();

    }

    void explode()
    {
        GameObject firework = Instantiate(ballParticle,rb.position, Quaternion.identity);
        firework.GetComponent<ParticleSystem>().Play();
        ballExplodeSound.PlayOneShot(explodeSound, 1.0f);
    }

    void lastBallExplode() 
    {
        GameObject firework = Instantiate(ballParticle, rb.position, Quaternion.identity);
        firework.GetComponent<ParticleSystem>().Play();
        Destroy(gameObject);
        ballExplodeSound.PlayOneShot(explodeSound, 1.0f);

    }
}
