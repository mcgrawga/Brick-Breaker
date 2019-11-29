using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int pointVal;
    public int hitsToBreak;
    public int hits = 0;
    public Sprite firstHitSprite;
    public Sprite secondHitSprite;
    public Transform explosion;
    public GameManager gameManager;
    public Transform powerUp;
    public int powerUpChance;
    public int speedMin;
    public int speedMax;
    private float speed;
    public bool isMover;



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        if (isMover){
            Vector2 startDirection = new Vector2(1f, 1f);
            System.Random randNumGenerator = new System.Random();
            speed = randNumGenerator.Next(speedMin, speedMax);
            string xSign, ySign;
            xSign = randNumGenerator.Next(1,100) <= 50 ? "neg" : "pos" ;
            ySign = randNumGenerator.Next(1,100) <= 50 ? "neg" : "pos" ;
            if (xSign == "neg" && ySign == "neg")
                startDirection = new Vector2(-1f, -1f);
            if (xSign == "pos" && ySign == "pos")
                startDirection = new Vector2(1f, 1f);
            if (xSign == "pos" && ySign == "neg")
                startDirection = new Vector2(1f, -1f);
            if (xSign == "neg" && ySign == "pos")
                startDirection = new Vector2(-1f, 1f);
             GetComponent<Rigidbody2D>().AddForce(startDirection.normalized*speed, ForceMode2D.Force);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isMover){
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * speed;
        }
    }

    void explode() {
        // Create Explosion
        Transform e = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(e.gameObject, 2);

        // Destroy Brick
        Destroy(gameObject);
    }

    void chanceForPowerUp(){
        int randChance = Random.Range(1,101);
        if (randChance < powerUpChance) {
            Transform pu = Instantiate(powerUp, transform.position, Quaternion.identity);
            Rigidbody2D rb = pu.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.CompareTag("Ball")){
            hits++;
            if (hits == 1 && hits < hitsToBreak) {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = this.firstHitSprite;
                gameManager.soundBrickHit1.Play();
            } else if (hits == 2 && hits < hitsToBreak) {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = this.secondHitSprite;
                gameManager.soundBrickHit2.Play();
            } else {
                explode();
                gameManager.soundBrickHitExplode.Play();
                chanceForPowerUp();

                // Update Score
                gameManager.updateScore(pointVal);

                // Update Number of Bricks
                gameManager.updateNumberOfBricks(-1);
            }
        }
    }
}
