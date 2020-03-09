using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFireball : Generator
{

    public GameObject fireballLeft;
    public GameObject fireballRight;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override Card generateRandom()
    {
        int recoveryTime = 20;
        float spawnX = 1.1f;
        float speedX = 5;
        int power = 10;
        ActionPlayer action = new FireBallAction(recoveryTime, spawnX, speedX, power);
        Card card = new Card(this, action, "Fireball", "recoveryTime : " + recoveryTime + "\n power : " + power + "\n speed : " + speedX);
        return card;
    }

    public override void addPrefab(CharacterSide side, ActionPlayer action)
    {
        if (side == CharacterSide.Left)
        {
            action.addPrefab(fireballLeft);
        }
        else
        {
            action.addPrefab(fireballRight);
        }
    }
}
