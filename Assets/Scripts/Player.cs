using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 1.0f;

    public KeyCode leftKey = KeyCode.LeftArrow;
    public KeyCode rightKey = KeyCode.RightArrow;
    public KeyCode upKey = KeyCode.UpArrow;
    public KeyCode downKey = KeyCode.DownArrow;

    private readonly float rightBorder = 9.5f;
    private readonly float leftBorder = -9.5f;
    private readonly float topBorder = 4.5f;
    private readonly float bottomBorder = -4.5f;

    bool m_Started;
    public LayerMask m_LayerMask;

    // Use this for initialization
    void Start () {
        //Use this to ensure that the Gizmos are being drawn when in Play Mode.
        m_Started = true;
    }

    // Update is called once per frame
    protected void Update () {
        /*
        Vector3 position = this.transform.position;

        float translationY = Input.GetAxis("Vertical") * speed;
        translationY *= Time.deltaTime;
        position.y += translationY;

        float translationX = Input.GetAxis("Horizontal") * speed;
        translationX *= Time.deltaTime;
        position.x += translationX;

        this.transform.position = position;
        */

        if (Input.GetKey(leftKey))
        {
            Vector3 position = this.transform.position;
            position.x -= speed * Time.deltaTime;
            if (position.x < leftBorder)
            {
                position.x = leftBorder;
            }
            this.transform.position = position;
        }
        if (Input.GetKey(rightKey))
        {
            Vector3 position = this.transform.position;
            position.x += speed * Time.deltaTime;
            if (position.x > rightBorder)
            {
                position.x = rightBorder;
            }
            this.transform.position = position;
        }
        if (Input.GetKey(upKey))
        {
            Vector3 position = this.transform.position;
            position.y += speed * Time.deltaTime;
            if (position.y > topBorder)
            {
                position.y = topBorder;
            }
            this.transform.position = position;
        }
        if (Input.GetKey(downKey))
        {
            Vector3 position = this.transform.position;
            position.y  -= speed * Time.deltaTime;
            if (position.y < bottomBorder)
            {
                position.y = bottomBorder;
            }
            this.transform.position = position;
        }
    }


    void FixedUpdate()
    {
        MyCollisions();
    }

    void MyCollisions()
    {
        //Use the OverlapBox to detect if there are any other colliders within this box area.
        //Use the GameObject's centre, half the size (as a radius) and rotation. This creates an invisible box around your GameObject.
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, m_LayerMask);
        int i = 0;
        //Check when there is a new collider coming into contact with the box
        while (i < hitColliders.Length)
        {
            //Output all of the collider names
            Debug.Log("Hit : " + hitColliders[i].name + i);
            //Increase the number of Colliders in the array
            i++;
        }
    }

    //Draw the Box Overlap as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (m_Started)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
