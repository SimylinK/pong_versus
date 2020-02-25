using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticCharacters {

	public static CharacterAttributes character1 { get; set; }
	public static CharacterAttributes character2 { get; set; }

	public static void setAttributes(CharacterAttributes attributes, Character character) {
		character.side = attributes.side;
		character.speed = attributes.speed;
		character.actions = attributes.actions;
		character.normal = attributes.normal;
        character.recovery = attributes.recovery;
        character.ko = attributes.ko;

		foreach (ActionPlayer action in character.actions) {
			action.character = character;
		}

	}
}