using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFighter : MonoBehaviour {

	public GameObject fireBallLeft;
	public GameObject fireBallRight;
	public GameObject punchLeft;
	public GameObject punchRight;
	public GameObject guard;

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
		GameObject guardPrefab = guard;

		if (side == CharacterSide.Right) {
			spawnX *= -1;
			speedX *= -1;
			fireballPrefab = fireBallRight;
			punchPrefab = punchRight;
		}

		List<ActionPlayer> actions = new List<ActionPlayer>();
		actions.Add(new FireBallAction(KeyCode.KeypadEnter, 20, fireballPrefab, spawnX, speedX, 5));
        actions.Add(new PunchAction(KeyCode.KeypadPlus, 20, punchPrefab, spawnX, 10));
		actions.Add(new GuardAction(KeyCode.KeypadMinus, guardPrefab, spawnX));


		float speed = 0.2f;
		CharacterAttributes fighter = new CharacterAttributes(side, speed, actions, normal, recovery, ko);

		

		return fighter;
	}

}
