using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {
    public Transform[] PatrolPoints;
    public float moveSpeed;
    private int currentPoint;
	// Use this for initialization
	void Start () {
        transform.position = PatrolPoints[0].position;
        currentPoint = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position == PatrolPoints[currentPoint].position)
        {
            currentPoint++;
        }
        if (currentPoint >= PatrolPoints.Length)
        {
            currentPoint = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position,PatrolPoints[currentPoint].position, moveSpeed*Time.deltaTime);
	}
    private void OnTriggerEnter(Collider other)
    {
        if (transform.tag == "portal_enemy")
        {
            if (other.transform.tag.Equals("portal"))
                transform.position = new Vector3(-0.5f, 0.25f, 27f);
            if (other.transform.tag.Equals("portal1"))
                transform.position = new Vector3(-21f, 0.25f, 18.8f);
            if (other.transform.tag.Equals("portal2"))
                transform.position = new Vector3(-1, 0.25f, -1);
            if (other.transform.tag.Equals("portal3"))
                transform.position = new Vector3(18.7f, 0.25f, 20f);
        }
    }
        
}
