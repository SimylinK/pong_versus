using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

    public float speedX = 1;
    public float speedY = 0;
    public float power = 1;
    public int durationPushBack = 100;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 velocity = new Vector2(speedX, speedY);
        rb.velocity = velocity;
    }

    void FixedUpdate()
    {
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            Ball ball = col.GetComponent<Ball>();
            Vector2 velocity = ball.getVelocity();
            velocity.x += speedX * power;
            velocity.y += speedY * power;
            ball.setVelocity(velocity);

            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Player")
        {
            Vector2 pushBack = new Vector2(speedX * power * Time.deltaTime, speedY * power * Time.deltaTime);

            Fighter player = col.GetComponent<Fighter>();
            player.hit(pushBack, durationPushBack);

            Destroy(gameObject);

        }
    }
}
