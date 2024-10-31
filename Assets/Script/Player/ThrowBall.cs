using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ThrowBall : MonoBehaviour {


    public GameObject blot;   //放置武器的預置物
    public Slider CDTime;

    public float Speed = 1500;
    public float Timer;
    public int Ballnum = 10;

    private Transform player;
    private GameObject button;   //放置產生的光球
                                 // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        CDTime.value = CDTime.maxValue = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Ballnum < 10)
            CDTime.value = Timer;

        if (Input.GetKeyDown(KeyCode.C) && Ballnum > 0)
        {
            button = (GameObject) Instantiate(blot, transform.position, Quaternion.identity);
            if (player.position.x < transform.position.x)
            {
                button.GetComponent<Rigidbody2D>().AddForce(Vector2.right * Speed);
            }
            else
            {
                button.GetComponent<Rigidbody2D>().AddForce(Vector2.left * Speed);
            }
            Ballnum -= 1;
            GameControl_Game.GameCtrl.ShurikenLess();
        }

        if (Timer > 3 && Ballnum < 10)
        {
            GameControl_Game.GameCtrl.ShurikenAdd();
            Ballnum += 1;
            Timer = 0;
        }
        else if (Timer > 3)
            Timer = 0;
    }

}
