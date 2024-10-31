using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl_1 : MonoBehaviour {

    public static GameControl_1 GameCtrl1;
    public GameObject EnemyNum;
    public GameObject Player;
    public Slider HpStrip;

    public int Enum = 0;
    public int HP = 3000;
    public int Stage;
    public int NowStage;

    // Use this for initialization
    void Start(){
        HpStrip.value = HpStrip.maxValue = HP;
        Stage = GameControl_Choice.Choice.Gamestage;
        NowStage = GameControl_Choice.Choice.NowStage;
    }

    void Awake(){
        GameCtrl1 = this;
    }

    // Update is called once per frame
    void Update () {
        Enum = CreateEnem.Create.enemyTatal;
        EnemyNum.GetComponent<Text>().text = Enum + "/40";
        HpStrip.value = HP;

        if (HP <= 0)
        {
            Destroy(Player.gameObject);
            ZerotButton();
        }
    }

	public void ZerotButton(){
        SceneManager.LoadSceneAsync(1);
    }

    public void OnHit(int damage)
    {
        HP -= damage;
    }
}
