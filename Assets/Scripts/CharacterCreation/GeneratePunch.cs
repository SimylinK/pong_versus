using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePunch : Generator {

	public GameObject punchLeft;
	public GameObject punchRight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override Card generateRandom() {
		int recoveryTime = 20;
		float spawnX = 1.1f;
		int power = 10;
		ActionPlayer action = new PunchAction(recoveryTime, spawnX, power);
		Card card = new Card(this, action, "Punch", "recoveryTime : " + recoveryTime + "\n power : " + power);
		return card;
	}

	public override void addPrefab(CharacterSide side, ActionPlayer action) {
		if (side == CharacterSide.Left) {
			action.addPrefab(punchLeft);
		} else {
			action.addPrefab(punchRight);
		}
	}
}
