using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_CanDownHit : MonoBehaviour {

    public AudioClip Hit;
    public float Timer;

    private Renderer renderer2;
    private AudioSource Des_Hit;
    // Use this for initialization
    void Start()
    {
        Des_Hit = GetComponent<AudioSource>();
        Des_Hit.PlayOneShot(Hit, 0.5f);
        renderer2 = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > 1)
            Destroy(gameObject);
    }

    void Disapear()
    {
        renderer2.material.color = new Color(0.5f, 0.5f, 0.5f, 0);
    }
}
