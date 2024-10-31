using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanShoot : MonoBehaviour
{
    public GameObject CanShoot_Can;
    public float Timer;
    private bool Start = false;

    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > 1.05f && Start == false)
        {
            CanShoot_Can.SetActive(true);
            Start = true;
        }
        if (Timer > 2)
            Destroy(gameObject);
    }

}
