using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Candy : MonoBehaviour {

    public static Destroy_Candy Candy;

    public float Timer;

	// Use this for initialization
	void Awake () {
        Candy = this;
	}
	
	// Update is called once per frame
	void Update () {
        Timer += Time.deltaTime;
        transform.Rotate(0, 0, 5);
        if (Timer > 3)
            Destroy(gameObject);
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameControl_Game.GameCtrl.OnHit(-500);
            MusicCtrl.SoundCtrl.HpUP();
            Destroy(gameObject);
        }
        /*if (collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }*/
    }
}
