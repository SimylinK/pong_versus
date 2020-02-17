using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classic : Player
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    new
	void Update () {
        base.Update();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //print(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            print("Point of contact: " + hit.point);
        }
    }
}
