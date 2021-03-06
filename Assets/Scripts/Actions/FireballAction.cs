﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallAction : ActionPress {


    public GameObject fireBallPrefab;
    public float spawnX;
    public float speedX;
    public float power;
    //public int durationPushBack = 100;

    public FireBallAction(KeyCode actionKey, int recoveryTime, GameObject fireBallPrefab, float spawnX, float speedX, float power) 
            : base(actionKey, recoveryTime) {
        this.fireBallPrefab = fireBallPrefab;
        this.spawnX = spawnX;
        this.speedX = speedX;
        this.power = power;
    }

    public FireBallAction(int recoveryTime, float spawnX, float speedX, float power)
            : base(recoveryTime)
    {
        this.spawnX = spawnX;
        this.speedX = speedX;
        this.power = power;
    }

    public override void use() {
        Rigidbody2D rb = character.gameObject.GetComponent<Rigidbody2D>();
        Vector2 fireballSpawn = new Vector2(rb.position.x + spawnX, rb.position.y);

        GameObject fireBallCreated = GameObject.Instantiate(fireBallPrefab, fireballSpawn, Quaternion.identity);
        FireBall fireBall = fireBallCreated.GetComponent<FireBall>();
        fireBall.speedX = speedX;
        fireBall.speedY = 0;
        fireBall.power = power;
    }

    public override void addPrefab(GameObject prefab) {
        fireBallPrefab = prefab;
    }

    public override void setSide(CharacterSide side)
    {
        if (side == CharacterSide.Right)
        {
            spawnX *= -1;
            speedX *= -1;
        }
    }
}
