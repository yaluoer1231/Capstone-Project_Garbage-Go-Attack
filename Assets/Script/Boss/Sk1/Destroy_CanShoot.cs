using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_CanShoot : MonoBehaviour {

    public GameObject Hit;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Instantiate(Hit, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
