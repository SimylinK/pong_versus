using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGuard : Generator
{

    public GameObject guard;

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
        float spawnX = 1.1f;
        ActionPlayer action = new GuardAction(spawnX);
        Card card = new Card(this, action, "Guard", "");
        return card;
    }

    public override void addPrefab(CharacterSide side, ActionPlayer action)
    {
        action.addPrefab(guard);
    }
}
