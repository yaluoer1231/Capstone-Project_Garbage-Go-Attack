using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour {

    public GameObject Hit;

    private float DestroyTime = 0.5f;
    private float Timer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Timer += Time.deltaTime;
        if (Timer > DestroyTime)
        {
            Destroy(gameObject);
            Timer = 0;
        }
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Ball" )
        {
            if (collision.gameObject.tag == "Boss" || collision.gameObject.tag == "Monster" || collision.gameObject.tag == "Glass")
            {
                Instantiate(Hit, new Vector3(transform.position.x, transform.position.y, -3), Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Ball")
            Destroy(gameObject);
    }
}
