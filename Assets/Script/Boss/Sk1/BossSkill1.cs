using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill1 : MonoBehaviour {

    public GameObject CanShoot;
    public float Timer;
    private float[] Down = new float[5];
    private int CanDown;
    private GameObject Player;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        for (int i = 0; i < Down.Length; i++)
            {
                CanDown = Random.Range(0, 1168);
                Down[i] = -6.47f + (CanDown / 100);
                if (i > 0)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (Down[i] == Down[j])
                        {
                            CanDown = Random.Range(0, 1168);
                            Down[i] = -6.47f + (CanDown / 100);
                            j = 0;
                        }
                    }
                }
            }

        for (int i = 0; i < Down.Length; i++)
            Instantiate(CanShoot, new Vector3(Down[i], -0.64f, -3), Quaternion.identity);
        Instantiate(CanShoot, new Vector3(Player.transform.position.x, -0.64f, -3), Quaternion.identity);
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        /*Timer += Time.deltaTime;
        if (Timer > 2)
        {
            for (int i = 0; i < 5; i++)
            {
                CanDown = Random.Range(0, 1168);
                Down[i] = -6.47f + (CanDown / 100);
                if (i > 0)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (Down[i] == Down[j])
                        {
                            CanDown = Random.Range(0, 1168);
                            Down[i] = -6.47f + (CanDown / 100);
                            j = 0;
                        }
                    }
                }
            }

            for (int i = 0; i < 5; i++)
            {
                Instantiate(CanShoot, new Vector3(Down[i], -0.64f, -3), Quaternion.identity);
            }
            /*Instantiate(CanShoot, new Vector3(Down[0], -0.64f, -3), Quaternion.identity);
            Instantiate(CanShoot, new Vector3(Down[1], -0.64f, -3), Quaternion.identity);
            Instantiate(CanShoot, new Vector3(Down[2], -0.64f, -3), Quaternion.identity);
            Instantiate(CanShoot, new Vector3(Down[3], -0.64f, -3), Quaternion.identity);
            Instantiate(CanShoot, new Vector3(Down[4], -0.64f, -3), Quaternion.identity);
            Timer = 0;
        }*/
    }
}
