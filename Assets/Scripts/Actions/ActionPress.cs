using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionPress : ActionPlayer {

	public KeyCode actionKey;
	public int recoveryTime;

    public ActionPress(KeyCode actionKey, int recoveryTime) 
            : base() {
        this.actionKey = actionKey;
        this.recoveryTime = recoveryTime;
    }

	public ActionPress(int recoveryTime) 
            : base() {
        this.recoveryTime = recoveryTime;
    }


	public override void listener() {
		if (Input.GetKeyDown(actionKey))
        {
            this.useAction();
        }
	}

	public override bool hasInput() {
		return true;
	}

	public override void setInput(KeyCode newKey) {
		actionKey = newKey;
	}


	public abstract void use();

	private void useAction() {
		if (!this.character.canUseAction()) {
			return;
		}
		
		this.use();
		character.startRecovery(recoveryTime);
	}

	public void setActionKey(KeyCode actionKey) {
		this.actionKey = actionKey;
	}
}
