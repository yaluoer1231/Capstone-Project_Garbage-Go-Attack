using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGun : MonoBehaviour
{
    public static WaterGun Water;

    public GameObject WaterHit;
    void Start()
    {
        WaterHit.SetActive(false);
    }

    void Awake()
    {
        Water = this;
    }

    void GunShoot()
    {
        BossMusicCtrl.BossMusic.WaterSound();
        WaterHit.SetActive(true);
    }
    

    void Dispear()
    {
        Destroy(gameObject);
    }
}

    
