using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttributes {

    public CharacterSide side;
	public float speed;
    public ActionPlayer action1;
    public ActionPlayer action2;
    public Sprite normal;
    public Sprite recovery;
    public Sprite ko;

	public CharacterAttributes(CharacterSide side, float speed, ActionPlayer action1, ActionPlayer action2, Sprite normal, Sprite recovery, Sprite ko) {
        this.side = side;
        this.speed = speed;
        this.action1 = action1;
        this.action2 = action2;
        this.normal = normal;
        this.recovery = recovery;
        this.ko = ko;
    }
}
