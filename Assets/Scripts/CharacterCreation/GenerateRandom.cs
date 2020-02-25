using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRandom : MonoBehaviour {

	private List<Card> cards = new List<Card>();
	private List<Generator> generators = new List<Generator>();


	// Use this for initialization
	void Start () {
		foreach (Transform child in transform) {
    		generators.Add(child.gameObject.GetComponent<Generator>());
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Generate 10 randoms actions
	public void generateRandom() {
		for (int i = 0; i < 10; i++) {
       		int index = Random.Range(0, generators.Count);
			Generator generator = generators[index];
			Card card = generator.generateRandom();
			cards.Add(card);
		}


	}

	public List<Card> getCards() {
		return cards;
	}

}
