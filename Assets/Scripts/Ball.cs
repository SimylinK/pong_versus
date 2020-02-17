using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speedX = 0;
    public float speedY = 0;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        Vector3 position = this.transform.position;
        position.x -= speedX * Time.deltaTime;
        position.y -= speedY * Time.deltaTime;
        this.transform.position = position;

        Debug.Log("Ball velocity : " + rb.velocity);

    }

    public Vector2 getVelocity()
    {
        return rb.velocity;
    }

    public void setVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;
    }
}
