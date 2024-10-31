using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy_Create : MonoBehaviour {

    public static Candy_Create CandyCreate;

    public GameObject Candy;
    public float Timer;
    public float Down;
    public int Stage = 0;
    

	// Use this for initialization
	void Start () {
        Stage = GameControl_Game.GameCtrl.NowStage;
	}

    void Awake()
    {
        CandyCreate = this;
    }

    // Update is called once per frame
    void Update () {
        Timer += Time.deltaTime;
        if (Timer > 3 && Stage < 5)
        {
            int CandyDown = Random.Range(0, 708);
            Down = transform.position.x - 3.54f + (CandyDown / 100);
            Instantiate(Candy, new Vector3(Down, transform.position.y + 3.08f, -8), Quaternion.identity);
            Timer = 0;
        }
        else if(Timer > 10 && Stage == 5){
            int CandyDown = Random.Range(0, 354);
            Down = transform.position.x - 3.54f + (CandyDown / 100);
            Instantiate(Candy, new Vector3(Down, transform.position.y + 3.08f, -8), Quaternion.identity);
            Timer = 0;
        }
    }

    public void StageBoss()
    {
        Stage = 5;
    }
}
