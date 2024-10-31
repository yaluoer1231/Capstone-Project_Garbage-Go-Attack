﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
        gameObject.transform.position = new Vector3(-1.61f, 0.54f, -10);
	}
	
	// Update is called once per frame
	void Update () {
        try
        {
            Vector3 pos = transform.position;
            pos.x = target.position.x;
            pos.y = target.position.y;
            if (pos.x > -1.61 && pos.x < 1.55 && pos.y > 0.54 && pos.y < 2.15)
            {
                transform.position = pos;
            }
            else if (pos.x < -1.61 || pos.x > 1.55)
            {
                if (pos.y < 0.54 || pos.y > 2.15)
                {

                }
                else
                {
                    float speed = pos.y - transform.position.y;
                    gameObject.transform.position += new Vector3(0f, speed, 0);
                    speed = 0;
                }
            }
            else if (pos.y < 0.54 || pos.y > 2.15)
            {
                float speed = pos.x - transform.position.x;
                gameObject.transform.position += new Vector3(speed, 0, 0);
                speed = 0;
            }
        }
        catch {
            this.enabled = false;
        }
    }
}