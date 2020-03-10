using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePassive : Generator {

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
        float speedBonus = 1.1f;
        ActionPlayer action = new PassiveAction();
        Card card = new Card(this, action, "Bonus de vitesse", "speed bonus : " + speedBonus);
        return card;
    }
}
