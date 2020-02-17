using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            Ball ball = col.GetComponent<Ball>();
            Vector2 velocity = ball.getVelocity();
            velocity.x *= -1;
            ball.setVelocity(velocity);

            Destroy(gameObject);
        }
    }
}
