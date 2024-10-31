using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcossPlayer : MonoBehaviour {

    public GameObject Player_Feet;

    private BoxCollider2D FBox2D;

    // Use this for initialization
    void Start () {

        //Player_Feet = GameObject.FindGameObjectWithTag("Feet");

        FBox2D = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
        if (Player_Feet.transform.position.y < transform.position.y)
        {
            FBox2D.enabled = false;
        }
        else
        {
            FBox2D.enabled = true;
        }

	}
}
