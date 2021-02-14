using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthController : MonoBehaviour
{
    public ParticleSystem explosion;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
            Instantiate(explosion, other.gameObject.transform.position, other.transform.rotation);
            GameManager.health -= 10;
        }
    }
}
