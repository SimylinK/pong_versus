using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

    public GameObject impactCenter;

    public float speedX;
    public float speedY;
    public float power;
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
            Vector2 ballPosition = col.gameObject.transform.position;
            Vector2 fireballPosition = impactCenter.transform.position;

            float xDistance = Mathf.Abs(ballPosition.x - fireballPosition.x);
            float yDistance = Mathf.Abs(ballPosition.y - fireballPosition.y);
            float directionX = Mathf.Sign(ballPosition.x - fireballPosition.x);
            float directionY = Mathf.Sign(ballPosition.y - fireballPosition.y);

            float xPercentage = (xDistance) / (xDistance + yDistance);
            float yPercentage = (yDistance) / (xDistance + yDistance);

            Ball ball = col.GetComponent<Ball>();
            Vector2 velocity = ball.getVelocity();
            velocity.x += directionX * power * xPercentage;
            velocity.y += directionY * power * yPercentage;
            ball.setVelocity(velocity);

            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Player")
        {
            Vector2 pushBack = new Vector2(speedX * power * Time.deltaTime, speedY * power * Time.deltaTime);

            Character player = col.GetComponent<Character>();
            player.hit(pushBack, durationPushBack);

            Destroy(gameObject);

        }
    }
}
