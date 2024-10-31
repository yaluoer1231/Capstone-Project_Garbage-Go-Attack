using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Can : MonoBehaviour {

    public static Enemy_Can Can;
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
        Hp = 990 + HpAdd;
        //Hp = 100;
        MonsterHpStrip.value = MonsterHpStrip.maxValue = Hp;
        NowType = Random.Range(0, 7);
        
        Player = GameObject.FindGameObjectWithTag("Player");
        Player_Atk = GameObject.FindGameObjectWithTag("Atk");
    }

    void Awake()
    {

        Can = this;
    }

    // Update is called once per frame
    void Update()
    {
        MonsterHpStrip.value = Hp;
        Stop = GameControl_Game.GameCtrl.StopTime;
        timer += Time.deltaTime;
        int type = Random.Range(0, 7);

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
                case 0:
                case 1:
                case 2:
                    if (transform.position.x > -5.98)
                    {
                        transform.Translate(-0.03f, 0, 0);
                        transform.localScale = new Vector3(0.2f, 0.2f, 1);
                    }
                    break;
                case 3:
                case 4:
                case 5:
                    if (transform.position.x < 5.98)
                    {
                        transform.Translate(0.03f, 0, 0);
                        transform.localScale = new Vector3(-0.2f, 0.2f, 1);
                    }
                    break;
                case 6:
                    transform.Translate(0, 0, 0); break;
                case 7:
                    if (Player_Atk.transform.position.x > Player.transform.position.x)
                    {
                        if (transform.position.x < 5.98)
                            transform.Translate(0.5f, 0, 0);
                        transform.localScale = new Vector3(0.2f, 0.2f, 1);
                    }
                    else if (Player_Atk.transform.position.x < Player.transform.position.x)
                    {
                        if (transform.position.x > -5.98)
                            transform.Translate(-0.5f, 0, 0);
                        transform.localScale = new Vector3(-0.2f, 0.2f, 1);
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
                Hp -= 200;
                //Debug.Log(-100);
            }
            if (collision.gameObject.tag == "Atk1")
            {
                NowType = 7;
                MusicCtrl.SoundCtrl.Atk1Hit();
                Hp -= 150;
            }
            if (collision.gameObject.tag == "Atk2")
            {
                NowType = 7;
                MusicCtrl.SoundCtrl.OnHit();
                Hp -= 250;
            }
            if (Hp < 0)
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
