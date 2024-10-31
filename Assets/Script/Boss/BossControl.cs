using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossControl : MonoBehaviour
{

    public static BossControl BosCtrl;
    public GameObject Ski1;
    public GameObject WaterGun;
    public GameObject Sk1;
    public GameObject Sk2;

    public AudioClip Gun_PrePare;


    public int Hp = 8100;
    public int Mode;
    public float Timer;

    private GameObject Player;
    private AudioSource BossSound;
    private int ModDebug;
    // Use this for initialization
    void Start()
    {
        Instantiate(WaterGun, Sk2.transform.position, Quaternion.identity);
        Player = GameObject.FindGameObjectWithTag("Player");
        BossSound = GetComponent<AudioSource>();
        Hp = 10000;
    }

    void Awake()
    {
        BosCtrl = this;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Player.transform.position.y > 1 && Timer > 2)
        {
            Instantiate(Ski1, Sk1.transform.position, Quaternion.identity);
            Timer = 0;
        }
        else if (Timer > 2)
        {
            Mode = Random.Range(0, 10);

            switch (Mode)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    Instantiate(Ski1, Sk1.transform.position, Quaternion.identity);
                    break;

                case 6:
                case 7:
                case 8:
                case 9:
                    BossSound.PlayOneShot(Gun_PrePare, 2);
                    Instantiate(WaterGun, Sk2.transform.position, Quaternion.identity);
                    break;

                default:
                    break;
            }
            Timer = 0;
        }


        if (Hp < 0)
        {
            GameControl_Game.GameCtrl.NowStage = 6;
            Destroy(gameObject);
            MusicCtrl.SoundCtrl.Victory();
            this.enabled = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            MusicCtrl.SoundCtrl.OnHit();
            GameControl_Game.GameCtrl.BossOnHit(100);
            Hp -= 100;
        }

        if (collision.gameObject.tag == "Atk1")
        {
            MusicCtrl.SoundCtrl.Atk1Hit();
            GameControl_Game.GameCtrl.BossOnHit(150);
            Hp -= 150;
        }

        if (collision.gameObject.tag == "Atk2")
        {
            MusicCtrl.SoundCtrl.OnHit();
            GameControl_Game.GameCtrl.BossOnHit(250);
            Hp -= 250;
        }
    }
}
