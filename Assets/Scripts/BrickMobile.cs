using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickMobile : MonoBehaviour
{
    
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 startDirection = new Vector2(1f, 1f);
        System.Random randNumGenerator = new System.Random();
        // speed = randNumGenerator.Next(2, 5);
        speed = 10;
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

    // Update is called once per frame
    void Update()
    {
        // startDirection = startDirection.normalized;
        // startDirection *= 2;
        // GetComponent<Rigidbody2D>().AddTorque(0.3f);
        GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * speed;
        // GetComponent<Rigidbody2D>().AddForce(startDirection*15, ForceMode2D.Force);
        
    }
}
