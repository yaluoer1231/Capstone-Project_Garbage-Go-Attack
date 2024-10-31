using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public bool Stop = false;
    public float Timer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Timer += Time.deltaTime;
        Stop = GameControl_Game.GameCtrl.StopTime;
        if (Stop == true)
            transform.Translate(0, 0, 0);
        else
            transform.Translate(0, -0.05f, 0);

        if (Timer > 3)
            Destroy(gameObject);
    }
}
