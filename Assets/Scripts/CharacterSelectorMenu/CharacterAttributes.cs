using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttributes {

    public CharacterSide side;
	public float speed;
    public List<ActionPlayer> actions;
    public Sprite normal;
    public Sprite recovery;
    public Sprite ko;

	public CharacterAttributes(CharacterSide side, float speed, List<ActionPlayer> actions, Sprite normal, Sprite recovery, Sprite ko) {
        this.side = side;
        this.speed = speed;
        this.actions = actions;
        this.normal = normal;
        this.recovery = recovery;
        this.ko = ko;
    }
}
