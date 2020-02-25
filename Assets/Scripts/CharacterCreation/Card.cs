using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card {

	public Generator generator;
	public ActionPlayer action;
	public string title;
	public string description;

	public Card(Generator generator, ActionPlayer action, string title, string description) {
		this.action = action;
		this.title = title;
		this.description = description;
		this.generator = generator;
	}
}
