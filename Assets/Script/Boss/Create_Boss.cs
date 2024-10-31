using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Boss : MonoBehaviour {

    public static Create_Boss Boss;
    public GameObject CanBoss;
    public bool Creat = false;
	// Use this for initialization
	void Start () {
		
	}

    void Awake()
    {
        Boss = this;
    }

    // Update is called once per frame
    void Update () {
        if (Creat == true)
        {
            Instantiate(CanBoss, transform.position, Quaternion.identity);
            Candy_Create.CandyCreate.StageBoss();
            Creat = false;
        }
    }
}
