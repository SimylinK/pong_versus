using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionPlayer {

	public Character character;
	public int recoveryTime;

	public ActionPlayer(int recoveryTime) {
		this.recoveryTime = recoveryTime;
	}

	public abstract void use();

	public void useAction() {
		this.use();
		character.startRecovery(recoveryTime);
	}	
}
