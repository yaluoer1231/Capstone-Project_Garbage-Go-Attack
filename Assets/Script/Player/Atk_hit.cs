using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atk_hit : MonoBehaviour {

    public GameObject HitEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster" || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "Glass")
        {
            Instantiate(HitEffect, new Vector3(transform.position.x, transform.position.y, -3), Quaternion.identity);
        }
    }
}
