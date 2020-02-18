using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFighter : MonoBehaviour {

	public GameObject fireBallLeft;
	public GameObject fireBallRight;
	public GameObject punchLeft;
	public GameObject punchRight;

	public Sprite normal;
    public Sprite recovery;
    public Sprite ko;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public CharacterAttributes createFighter(CharacterSide side) {
		
		float spawnX = 1.1f;
		float speedX = 5;
		GameObject fireballPrefab = fireBallLeft;
		GameObject punchPrefab = punchLeft;

		if (side == CharacterSide.Right) {
			spawnX *= -1;
			speedX *= -1;
			fireballPrefab = fireBallRight;
			punchPrefab = punchRight;
		}

		ActionPlayer action1 = new FireBallAction(20, fireballPrefab, spawnX, speedX, 5);
        ActionPlayer action2 = new PunchAction(20, punchPrefab, spawnX, 10);

		float speed = 0.2f;
		CharacterAttributes fighter = new CharacterAttributes(side, speed, action1, action2, normal, recovery, ko);

		

		return fighter;
	}

}
