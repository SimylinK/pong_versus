using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionPlayer {

	public Character character;

	public virtual void listener()
    {
        return;
    }

	public virtual bool hasInput() {
		return false;
	}

	public virtual void setInput(KeyCode newKey) {
		Debug.Log("Warning : should not be called");
		return;
	}

	public virtual void addPrefab(GameObject prefab) {
		return;
	}

	public virtual void setSide(CharacterSide side) {
        return;
    }

    public virtual void init()
    {
        return;
    }
}
