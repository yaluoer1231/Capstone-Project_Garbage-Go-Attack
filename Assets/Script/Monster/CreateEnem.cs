using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnem : MonoBehaviour {

    public static CreateEnem Create;
    public GameObject enemy;
    public GameObject CreateEnemy2;
    public int enemyLimit = 40;
    public int enemyMax = 10;
    public int enemyNum = 0;
    public int enemyTatal = 30;
    public float timer;
        
	void Start () {

    }

    void Awake()
    {
        Create = this;
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;

        if (timer > 1 && enemyNum < enemyMax && enemyTatal < enemyLimit && enemyNum % 2 == 0)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            timer = 0;
            enemyNum += 1;
            enemyTatal += 1;
            
        }
        else if (timer > 1 && enemyNum < enemyMax && enemyTatal < enemyLimit && enemyNum % 2 > 0)
        {
            Instantiate(enemy, CreateEnemy2.transform.position, Quaternion.identity);
            timer = 0;
            enemyNum += 1;
            enemyTatal += 1;
        }
        else if (timer > 1 && enemyNum >= enemyMax)
            timer = 0;

        
    }

    public void Enemyless()
    {
        enemyNum -= 1;
        GameControl_Game.GameCtrl.EnemyKillNum();
    }
}
