using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticCharacters {

	public static CharacterAttributes character1 { get; set; }
	public static CharacterAttributes character2 { get; set; }

	public static void setAttributes(CharacterAttributes attributes, Character character) {
		character.side = attributes.side;
		character.speed = attributes.speed;
		character.action1 = attributes.action1;
		character.action2 = attributes.action2;
		character.normal = attributes.normal;
        character.recovery = attributes.recovery;
        character.ko = attributes.ko;

		character.action1.character = character;
		character.action2.character = character;
	}
}