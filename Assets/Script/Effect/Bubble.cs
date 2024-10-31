using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {

    public float ColorA;
    private Renderer Bubblerenderer;

    // Use this for initialization
    void Start () {
        Bubblerenderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        //if (Bubblerenderer.material.color.a < 1)
            ColorA -= Time.deltaTime;
        Bubblerenderer.material.color = new Color(1, 1, 1, 1-ColorA);
    }
}
