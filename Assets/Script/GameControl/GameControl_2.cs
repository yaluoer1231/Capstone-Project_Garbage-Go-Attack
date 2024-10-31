using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl_2 : MonoBehaviour {

    public GameObject EnemyNum;
    public int Enum = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Enum = CreateEnem.Create.enemyTatal;
        EnemyNum.GetComponent<Text>().text = Enum + "/40";
    }

    public void ZerotButton(){
        SceneManager.LoadSceneAsync(1);
    }
}
