using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionPressRelease : ActionPlayer {

	public KeyCode actionKey;

    public ActionPressRelease(KeyCode actionKey) 
            : base() {
        this.actionKey = actionKey;
    }

    public ActionPressRelease()
        : base()
    {
    }

    public override void listener() {
		if (Input.GetKeyDown(actionKey))
        {
            this.useActionPress();
        }
		if (Input.GetKeyUp(actionKey))
        {
            this.useActionRelease();
        }
	}

	public override bool hasInput() {
		return true;
	}

	public override void setInput(KeyCode newKey) {
		actionKey = newKey;
	}

	public abstract void press();
	public abstract void release();



	private void useActionPress() {
		if (!character.canUseAction()) {
			return;
		}
		
		this.press();
		character.lockActions(this);

	}


	private void useActionRelease() {
		if (this.character.actionLocking != this) {
			return;
		}
		
		this.release();
		character.unlockActions();

	}
}
