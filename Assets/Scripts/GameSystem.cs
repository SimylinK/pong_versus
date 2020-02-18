using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		Debug.Log(StaticCharacters.character1.speed);
		//Creating Player 1
		GameObject player1 = Instantiate(player, new Vector3(-5f, 0.5f, 0), Quaternion.identity);
		Character char1 = player1.GetComponent<Character>();
		StaticCharacters.setAttributes(StaticCharacters.character1, char1);
		char1.init();

		//Creating Player 2
		GameObject player2 = Instantiate(player, new Vector3(5f, 0.5f, 0), Quaternion.identity);
		Character char2 = player2.GetComponent<Character>();
		StaticCharacters.setAttributes(StaticCharacters.character2, char2);
		char2.init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
