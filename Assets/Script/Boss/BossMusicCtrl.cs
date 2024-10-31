using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusicCtrl : MonoBehaviour {

    public static BossMusicCtrl BossMusic;

    public AudioClip WaterGunSound;

    private AudioSource BossSource;

	// Use this for initialization
	void Start () {
        BossSource = GetComponent<AudioSource>();
	}

    void Awake()
    {
        BossMusic = this;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void WaterSound()
    {
        BossSource.PlayOneShot(WaterGunSound, 1);
    }
}
