using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAction : ActionPressRelease {

    public GameObject guardPrefab;
    public float spawnX;

	private GameObject guard;

	public GuardAction(KeyCode actionKey, GameObject guardPrefab, float spawnX) 
            : base(actionKey) {
        this.guardPrefab = guardPrefab;
        this.spawnX = spawnX;
    }

    public GuardAction(float spawnX)
        : base()
    {
        this.spawnX = spawnX;
    }

    public override void press() {
        Rigidbody2D rb = character.gameObject.GetComponent<Rigidbody2D>();
        Vector2 guardSpawn = new Vector2(rb.position.x + spawnX, rb.position.y);

        guard = GameObject.Instantiate(guardPrefab, guardSpawn, Quaternion.identity);
    }

	public override void release() {
        guard.GetComponent<Guard>().destroy();
    }

    public override void addPrefab(GameObject prefab) {
        guardPrefab = prefab;
    }

    public override void setSide(CharacterSide side)
    {
        if (side == CharacterSide.Right)
        {
            spawnX *= -1;
        }
    }
}
