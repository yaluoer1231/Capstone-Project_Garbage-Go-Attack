using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Bag : MonoBehaviour {

    public static Enemy_Bag Bag;
    public Slider MonsterHpStrip;

    public float timer;
    public int NowType = 0;
    public int Hp;

    private GameObject Player;
    private GameObject Player_Atk;
    private bool Stop = false;
    // Use this for initialization
    void Start()
    {
        int HpAdd = Random.Range(0, 20);
        Hp = 640 + HpAdd;
        //Hp = 100;
        MonsterHpStrip.value = MonsterHpStrip.maxValue = Hp;
        NowType = Random.Range(0, 4);
    }

    void Awake()
    {
        Bag = this;
    }

    // Update is called once per frame
    void Update()
    {
        MonsterHpStrip.value = Hp;
        Stop = GameControl_Game.GameCtrl.StopTime;
        Player = GameObject.FindGameObjectWithTag("Player");
        Player_Atk = GameObject.FindGameObjectWithTag("Atk");
        timer += Time.deltaTime;
        int type = Random.Range(0, 4);

        if (timer > 1)
        {
            timer = 0;
            NowType = type;
        }
        else if (Stop == true)
        {
            transform.Translate(0, 0, 0);
        }
        else
        {
            switch (NowType)
            {
                case 0://往左下
                    if (transform.position.x > -6.18)
                    {
                        if (transform.position.y > -3)
                        {
                            transform.Translate(-0.03f, -0.03f, 0);
                            transform.localScale = new Vector3(0.25f, 0.25f, 1);
                        }
                        else
                        {
                            transform.Translate(-0.03f, 0, 0);
                            transform.localScale = new Vector3(0.25f, 0.25f, 1);
                        }
                    }
                    else
                    {
                        if (transform.position.y > -3)
                        {
                            transform.Translate(0, -0.03f, 0);
                            transform.localScale = new Vector3(0.25f, 0.25f, 1);
                        }
                    }
                    break;
                case 1: //往左上
                    if (transform.position.x > -6.18)
                    {
                        if (transform.position.y < 3.37)
                        {
                            transform.Translate(-0.03f, 0.03f, 0);
                            transform.localScale = new Vector3(0.25f, 0.25f, 1);
                        }
                        else
                        {
                            transform.Translate(-0.03f, 0, 0);
                            transform.localScale = new Vector3(0.25f, 0.25f, 1);
                        }
                    }
                    else
                    {
                        if (transform.position.y < 3.37)
                        {
                            transform.Translate(0, 0.03f, 0);
                            transform.localScale = new Vector3(0.25f, 0.25f, 1);
                        }
                    }
                    break;
                case 2://往右上
                    if (transform.position.x < 6.16)
                    {
                        if (transform.position.y < 3.37)
                        {
                            transform.Translate(0.03f, 0.03f, 0);
                            transform.localScale = new Vector3(-0.25f, 0.25f, 1);
                        }
                        else
                        {
                            transform.Translate(0.03f, 0, 0);
                            transform.localScale = new Vector3(-0.25f, 0.25f, 1);
                        }
                    }
                    else
                    {
                        if (transform.position.y < 3.37)
                        {
                            transform.Translate(0, 0.03f, 0);
                            transform.localScale = new Vector3(-0.25f, 0.25f, 1);
                        }
                    }
                    break;
                case 3://往右下
                    if (transform.position.x < 6.16)
                    {
                        if (transform.position.y > -3)
                        {
                            transform.Translate(0.03f, -0.03f, 0);
                            transform.localScale = new Vector3(-0.25f, 0.25f, 1);
                        }
                        else
                        {
                            transform.Translate(0.03f, 0, 0);
                            transform.localScale = new Vector3(-0.25f, 0.25f, 1);
                        }
                    }
                    else
                    {
                        if (transform.position.y > -3)
                        {
                            transform.Translate(0, -0.03f, 0);
                            transform.localScale = new Vector3(-0.25f, 0.25f, 1);
                        }
                    }
                    break;
                case 4:
                    if (Player_Atk.transform.position.x > Player.transform.position.x)
                    {
                        if (transform.position.x < 5.26)
                            transform.Translate(0.5f, 0, 0);
                        transform.localScale = new Vector3(0.25f, 0.25f, 1);
                    }
                    else if (Player_Atk.transform.position.x < Player.transform.position.x)
                    {
                        if (transform.position.x > -5.28)
                            transform.Translate(-0.5f, 0, 0);
                        transform.localScale = new Vector3(-0.25f, 0.25f, 1);
                    }
                    NowType = 6;
                    break;
                default:
                    transform.Translate(0, 0, 0);
                    break;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Monster" && collision.gameObject.tag != "Player")
        {
            timer = 0.5f;
            if (collision.gameObject.tag == "Ball")
            {
                NowType = 6;
                MusicCtrl.SoundCtrl.OnHit();
                Hp -= 250;
            }
            if (collision.gameObject.tag == "Atk1")
            {
                NowType = 4;
                MusicCtrl.SoundCtrl.Atk1Hit();
                Hp -= 150;
            }
            if (collision.gameObject.tag == "Atk2")
            {
                NowType = 4;
                MusicCtrl.SoundCtrl.OnHit();
                Hp -= 100;
            }
            if (Hp <= 0)
            {
                Destroy(gameObject);
                this.enabled = false;
                CreateEnem.Create.Enemyless();
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ball")
        {
            Destroy(gameObject);
            this.enabled = false;
        }
    }
}
