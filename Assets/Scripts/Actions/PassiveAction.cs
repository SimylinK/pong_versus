using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveAction : ActionPlayer {

    float speedBonus;

    public PassiveAction()
            : base()
    {
    }


    public override void init()
    { 
        this.character.speed += speedBonus;
    }
}
