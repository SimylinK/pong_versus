﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterSide {Left, Right}


public class Character : MonoBehaviour {

	private Rigidbody2D rb;

    public CharacterSide side;

    enum State { Normal, Recovery, Ko };
	private State state;
    public Sprite normal;
    public Sprite recovery;
    public Sprite ko;

    private int recoveryTime;
    private Vector2 pushBack;

    public KeyCode leftKey = KeyCode.LeftArrow;
    public KeyCode rightKey = KeyCode.RightArrow;
    public KeyCode upKey = KeyCode.UpArrow;
    public KeyCode downKey = KeyCode.DownArrow;
    public KeyCode action1Key = KeyCode.P;
    public KeyCode action2Key = KeyCode.L;

    public float speed;
    public ActionPlayer action1;
    public ActionPlayer action2;

    // Use this for initialization
    public void init() {
        rb = GetComponent<Rigidbody2D>();
        state = State.Normal;
        recoveryTime = 0;
        this.GetComponent<SpriteRenderer>().sprite = normal;
        Debug.Log("SIDE : " + side);
        if (side == CharacterSide.Right){
            Debug.Log("FLIP");
            this.GetComponent<SpriteRenderer>().flipX = true;
        }

    }


    void Update()
    {
        if (state != State.Normal) { return; }


        if (Input.GetKey(action1Key))
        {
            useAction(action1);
        }

        if (Input.GetKey(action2Key))
        {
            useAction(action2);
        }
    }

    private void useAction(ActionPlayer action) {
        action.useAction();
    }

    public void startRecovery(int recoveryTime) {
        state = State.Recovery;
        this.recoveryTime = recoveryTime;
        this.GetComponent<SpriteRenderer>().sprite = recovery;
    }


    // Update is called once per frame
    void FixedUpdate () {

        if (state == State.Recovery) {
            recoveryTime--;
            if (recoveryTime < 0) {
                state = State.Normal;
                this.GetComponent<SpriteRenderer>().sprite = normal;}
            return;
        }

        if (state == State.Ko)
        {
            recoveryTime--;
            if (recoveryTime < 0)
            {
                state = State.Normal;
                this.GetComponent<SpriteRenderer>().sprite = normal;
            }
            rb.MovePosition(rb.position + pushBack);
            return;
        }


        rb.velocity = new Vector2(0,0);

        float moveX = 0;
        if (Input.GetKey(rightKey)) { moveX++; }
        if (Input.GetKey(leftKey)) { moveX--; }

        float moveY = 0;
        if (Input.GetKey(upKey)) { moveY++; }
        if (Input.GetKey(downKey)) { moveY--; }

        if (moveX == 0 && moveY == 0) { return; }

        Vector2 movement = new Vector2(moveX, moveY);

        //rb.AddForce(movement * speed);
        rb.MovePosition(rb.position + movement * speed);
    }

    public void hit(Vector2 pushBack, int recoveryTime)
    {
        Debug.Log("HIT");

        //rb.isKinematic = false;
        state = State.Ko;
        this.GetComponent<SpriteRenderer>().sprite = ko;
        this.pushBack = pushBack;
        this.recoveryTime = recoveryTime;
    }

    /*public void OnTriggerEnter2D(Collider2D col) {
      if (col.gameObject.tag == "Ball")
      {
          //TODO : impact change with ball velocity
          this.hit(new Vector2(0,0), 10);
      }
    }*/

    public void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.tag == "Ball")
      {
          //TODO : impact change with ball velocity
          this.hit(new Vector2(0,0), 10);
      }
    }
}
