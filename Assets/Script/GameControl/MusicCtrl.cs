using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCtrl : MonoBehaviour {

    public static MusicCtrl SoundCtrl;
    public AudioClip Hit;
    public AudioClip Atk1_Hit;
    public AudioClip VictorySoure;
    public AudioClip EatCandy;

    private AudioSource SoundEffect;
    // Use this for initialization
    void Start () {
		SoundEffect = GetComponent<AudioSource>();
    }

    void Awake()
    {
        SoundCtrl = this;    
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnHit()
    {
        SoundEffect.PlayOneShot(Hit, 1);
    }

    public void Atk1Hit()
    {
        SoundEffect.PlayOneShot(Atk1_Hit, 1);
    }

    public void Victory()       //吃糖果
    {
        SoundEffect.PlayOneShot(VictorySoure, 1);
    }

    public void HpUP()
    {
        SoundEffect.PlayOneShot(EatCandy, 1);
    }
}
