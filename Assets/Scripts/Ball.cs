using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;
    // public Transform explosion;
    public GameManager gameManager;


    // Start is called before the first frame update
    void Start() {
        transform.position = paddle.position;
    }

    void StartBall() {
        rb = GetComponent<Rigidbody2D> ();
        float paddleDirection = Input.GetAxis("Horizontal");
        float x = 1f;
        if (paddleDirection == 0){
            x = 0f;    
        }
        if (paddleDirection < 0){
            x *= -1f;    
        }
        rb.velocity = new Vector2(x, 1f).normalized * speed;
    }

    // Update is called once per frame
    void Update() {
        if (gameManager.gameOver || gameManager.levelOver){
            return;
        }
        if (!inPlay) {
            transform.position = paddle.position;
        }
        if (Input.GetButtonDown("Jump") && !inPlay){
            inPlay = true;
            StartBall();
        }
        GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * speed;
    }

    void OnTriggerEnter2D(Collider2D other) {
         if (other.CompareTag("Bottom")) {
            rb.velocity = Vector2.zero;
            inPlay = false;
            gameManager.loseLife();
            gameManager.soundLossOfLife.Play();
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        gameManager.soundBallBounce.Play();
    }

}
