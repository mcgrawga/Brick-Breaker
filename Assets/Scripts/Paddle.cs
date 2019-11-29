using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float paddleSpeed;
    public float leftXBound;
    public float rightXBound;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameOver || gameManager.levelOver){
            return;
        }
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontal * Time.deltaTime * paddleSpeed);
        if (transform.position.x < leftXBound) {
            transform.position = new Vector2(leftXBound, transform.position.y);
        } else if (transform.position.x > rightXBound) {
            transform.position = new Vector2(rightXBound, transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("ExtraLife")){
            gameManager.addLife();
            gameManager.soundCaughtPowerUp.Play();
            Destroy(other.gameObject);
        }
    }

    // void OnCollisionEnter2D(Collision2D other) {
    //     if (other.transform.CompareTag("Ball")){
    //         gameManager.soundPaddleHit.Play();
    //     }
    // }
}
