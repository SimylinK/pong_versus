using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side : MonoBehaviour {

    // 0 = no change, 1 = will push the ball to the right/top, -1 = will push the ball to the left/bottom
    public float ballSpeedX = 0;
    public float ballSpeedY = 0;

    /*private float launchSpeed = 2f;
    private int stayTime = 0;
    private int timeBeforeLaunch = 100; */

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            Ball ball = col.GetComponent<Ball>();
            Vector2 velocity = ball.getVelocity();
            if (velocity.x * ballSpeedX < 0) { velocity.x *= -1; }
            if (velocity.y * ballSpeedY < 0) { velocity.y *= -1; }
            ball.setVelocity(velocity);
        }
    }

    /*void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            print("stayTime : " + stayTime);
            stayTime++;
            if (stayTime > timeBeforeLaunch)
            {
                //if ball is stopped launch it again
                Ball ball = col.GetComponent<Ball>();
                Vector2 velocity = ball.getVelocity();
                if (velocity.x == 0 && ballSpeedX != 0) { velocity.x = launchSpeed * ballSpeedX; }
                if (velocity.y == 0 && ballSpeedY != 0) { velocity.y = launchSpeed * ballSpeedY; }
                ball.setVelocity(velocity);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            stayTime = 0;
        }
    }*/
}
