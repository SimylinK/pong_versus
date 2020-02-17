using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallAction : ActionPlayer {


    public GameObject fireBallPrefab;
    public int player = 1;
    public float speedX = 1;
    public float speedY = 0;
    public float power = 1;
    public int durationPushBack = 100;

    private Rigidbody2D rb;

    public GameObject fireBall;

    public FireBallAction(Rigidbody2D rb, GameObject fireBallPrefab) {
        this.rb = rb;
        this.fireBallPrefab = fireBallPrefab;

        /*fireBallPrefab = Resources.Load<GameObject>("Prefabs/fire_ball");
        if (fireBallPrefab == null) {
            Debug.Log ("Error while loading prefab fire_ball");
        }*/
    }

	// return recovery time
    public override int use() {
        float spawnX = 1.1f;
        if (player == 2) { spawnX = -1.1f; }
        Vector2 fireballSpawn = new Vector2(rb.position.x + spawnX, rb.position.y);

        GameObject.Instantiate(fireBallPrefab, fireballSpawn, Quaternion.identity);
        
		return 20;
		//state = State.Recovery;
        //recoveryTime = 20;

        //this.GetComponent<SpriteRenderer>().sprite = recovery;
    } 
}
