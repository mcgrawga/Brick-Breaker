using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f, -1f) * Time.deltaTime * 5);
    }
}
