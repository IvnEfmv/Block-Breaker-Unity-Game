
using UnityEngine;

public class Ball : MonoBehaviour
{
    //config params
    [SerializeField] Paddle paddle;
    [SerializeField] float xPush, yPush;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor;
    
    //state
    public bool hasStarted = false;
    Vector2 paddleToBallVector;

    //Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;

    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted) 
        {
            StickBallToPaddle();
            LaunchOnMouseClick();
        }

    }

    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            hasStarted = true;
            myRigidbody2D.velocity = new Vector2(xPush,yPush);
        }
    }

    private void StickBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(-0.2f, randomFactor),
            Random.Range(-0.2f, randomFactor));

        if (hasStarted) 
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidbody2D.velocity += velocityTweak;
        }
    }
}
