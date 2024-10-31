using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl_Game : MonoBehaviour {

    public static GameControl_Game GameCtrl;
    public GameObject PlayStopButton;
    public GameObject PlayCamera;
    public GameObject EnemyNum;
    public GameObject ShurikenNum;
    public GameObject Player;
    public GameObject BossHpStripObject;
    public GameObject StopMask;
    public GameObject Clear;
    public GameObject Fall;
    public GameObject Warning;
    public GameObject Victory;

    public GameObject StageText;
    public GameObject KillNumber;
    public GameObject LeftNumber;

    public AudioClip BossBGM;
    public AudioClip FourBGM;
    public Slider HpStrip;
    public Slider BossHpStrip;
    public Sprite Play, Stop;
    
    public bool StopTime = false;
    public bool ChangeStage = false;
    public bool FinshBGM = false;

    public float CreateBossTimer;
    public float GameOverTimer;

    public int Enum = 30;
    public int Shuriken = 10;
    public int HP = 3000;
    public int BossHP;
    public int Stage;
    public int NowStage;

    private AudioSource BGM;
    // Use this for initialization
    void Start()
    {
        StopMask.SetActive(false);
        Time.timeScale = 1;
        HpStrip.value = HpStrip.maxValue = HP;
        Stage = GameControl_Choice.Choice.Gamestage;
        NowStage = GameControl_Choice.Choice.NowStage;
        BGM = GetComponent<AudioSource>();
        StageText.GetComponent<Text>().text = "" + NowStage + "";
    }

    void Awake()
    {
        GameCtrl = this;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyNum.GetComponent<Text>().text = Enum + "/40";
        ShurikenNum.GetComponent<Text>().text = "× " + Shuriken;
        HpStrip.value = HP;
        if (Enum == 40  && NowStage < 4 && ChangeStage == false)
        {
            GameOverTimer += Time.deltaTime;
            Clear.SetActive(true);
            if (GameOverTimer > 2)
                GameOver();
        }
        else if (Enum == 40  && NowStage == 4 && ChangeStage == false)
        {
            CreateBossTimer += Time.deltaTime;
            Warning.SetActive(true);

            if (FinshBGM == false)
            {
                FinshBGM = true;
                BossBGMPlay();
            }

            if (CreateBossTimer > 2)
            {
                BossHpStripObject.SetActive(true);
                BossHP = 10000;
                BossHpStrip.value = BossHpStrip.maxValue = BossHP;
                PlayCamera.transform.position = new Vector3(-1.62f, -1, -10);
                Player.transform.position = new Vector3(-4.02f, -2.47f, 2);
                GameFour();
            }
        }

        if (NowStage > 5)
        {
            ChangeStage = true;
            this.GetComponent<AudioSource>().Stop();
            GameOverTimer += Time.deltaTime;
            Victory.SetActive(true);
            if (GameOverTimer > 9)
            {
                NowStage = 4;
                SceneManager.LoadSceneAsync(0);
            }
        }

        if (NowStage == 5)
        {
            BossHpStrip.value = BossHP;
        }

        if (HP <= 0)
        {
            GameOverTimer += Time.deltaTime;
            Destroy(Player.gameObject);
            Fall.SetActive(true);
            if (GameOverTimer > 2)
                ZerotButton();
        }
    }

    public void GameOver()
    {
        switch (Stage)
        {
            case 1:
                Stage = 2;
                break;
            case 2:
                Stage = 3;
                break;
            case 3:
                Stage = 4;
                break;
            default:
                break;
        }
        ChangeStage = true;
        SceneManager.LoadSceneAsync(1);
    }

    public void GameFour()
    {
        Create_Boss.Boss.Creat = true;
        NowStage = 5;
    }


    public void PlayStop()
    {
        if (PlayStopButton.GetComponent<Image>().sprite.name == "Stop")
        {
            KillNumber.GetComponent<Text>().text = "" + Enum + "";
            LeftNumber.GetComponent<Text>().text = "" + (40 - Enum) + "";
            PlayStopButton.GetComponent<Image>().sprite = Play;
            StopTime = true;
            Time.timeScale = 0;
            StopMask.SetActive(true);
        }
        else
        {
            PlayStopButton.GetComponent<Image>().sprite = Stop;
            Time.timeScale = 1;
            StopTime = false;
            StopMask.SetActive(false);
        }
    }


    public void BossBGMPlay()
    {
        this.GetComponent<AudioSource>().clip = BossBGM;
        this.GetComponent<AudioSource>().Play();
    }

    public void ZerotButton()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void EnemyKillNum()
    {
        Enum += 1;
    }

    public void OnHit(int damage)
    {
        HP -= damage;
        if (HP > 3000)
            HP = 3000;
    }

    public void BossOnHit(int damage)
    {
        BossHP -= damage;
    }

    public void ShurikenAdd()
    {
        if (Shuriken < 10)
            Shuriken += 1;
    }

    public void ShurikenLess()
    {
        if (Shuriken > 0)
            Shuriken -= 1;
    }
}
