using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchAction : ActionPress {

    public GameObject punchPrefab;
    public float spawnX;
    public float power;
    //public int durationPushBack = 100;

    public GameObject fireBall;

    public PunchAction(KeyCode actionKey, int recoveryTime, GameObject punchPrefab, float spawnX, float power) 
            : base(actionKey, recoveryTime) {
        this.punchPrefab = punchPrefab;
        this.spawnX = spawnX;
        this.power = power;
    }


    public PunchAction(int recoveryTime, float spawnX, float power) 
            : base(recoveryTime) {
        this.spawnX = spawnX;
        this.power = power;
    }


    public override void use() {
        Rigidbody2D rb = character.gameObject.GetComponent<Rigidbody2D>();
        Vector2 punchSpawn = new Vector2(rb.position.x + spawnX, rb.position.y);

        GameObject punchCreated = GameObject.Instantiate(punchPrefab, punchSpawn, Quaternion.identity);
        Punch punch = punchCreated.GetComponent<Punch>();
        punch.power = power;
    }

    public void setPunchPrefab(GameObject punchPrefab) {
        this.punchPrefab = punchPrefab;
    }

    public override void addPrefab(GameObject prefab) {
        punchPrefab = prefab;
    }

    public override void setSide(CharacterSide side) {
        if (side == CharacterSide.Right) {
			spawnX *= -1;
		}
    }
}