using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour {

    public GameObject impactCenter;

    public float power = 10;
    public int duration = 20;
    public int durationPushBack = 100;

    // Use this for initialization
    void Start()
    {
    }

    void FixedUpdate()
    {
        if (duration <= 0)
            Destroy(gameObject);
        duration--;
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
            velocity.x = directionX * xPercentage * power;
            velocity.y = directionY * yPercentage * power;
            ball.setVelocity(velocity);

            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Player")
        {
            Vector2 pushBack = new Vector2(power * Time.deltaTime, power * Time.deltaTime);

            Character player = col.GetComponent<Character>();
            player.hit(pushBack, durationPushBack);

            Destroy(gameObject);

        }
    }
}
