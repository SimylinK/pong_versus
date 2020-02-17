using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchAction : ActionPlayer {

    public GameObject punchPrefab;
    public int player = 1;
    public float speedX = 1;
    public float speedY = 0;
    public float power = 1;
    public int durationPushBack = 100;

    private Rigidbody2D rb;

    public GameObject fireBall;

    public PunchAction(Rigidbody2D rb, GameObject punchPrefab) {
        this.rb = rb;
        this.punchPrefab = punchPrefab;
    }

	// return recovery time
    public override int use() {
        float spawnX = 1.1f;
        if (player == 2) { spawnX = -1.1f; }
        Vector2 punchSpawn = new Vector2(rb.position.x + spawnX, rb.position.y);

        GameObject.Instantiate(punchPrefab, punchSpawn, Quaternion.identity);
        
		return 20;
    } 
}