using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public Renderer asteroidRenderer;
    public Material[] materialsAsteroid;
    private Transform earth;
    public float speed;
    public float spinSpeed;
    private Rigidbody rb;

    void Awake()
    {
        asteroidRenderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();

        RandomMaterial();

        earth = GameObject.Find("Earth").transform;
    }

    void Update()
    {
        rb.AddForce((earth.position - transform.position).normalized * speed * Time.deltaTime);

        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime, Space.World);

        //transform.position = Vector3.MoveTowards(transform.position, earth.transform.position, 0.03f);
    }

    public void RandomMaterial()
    {
        int i = Random.Range(0, 5);

        if (i == 0)
        {
            asteroidRenderer.material = new Material(materialsAsteroid[0]);
        }
        else if (i == 1)
        {
            asteroidRenderer.material = new Material(materialsAsteroid[1]);
        }
        else if (i == 2)
        {
            asteroidRenderer.material = new Material(materialsAsteroid[2]);
        }
        else if (i == 3)
        {
            asteroidRenderer.material = new Material(materialsAsteroid[3]);
        }
        else if (i == 4)
        {
            asteroidRenderer.material = new Material(materialsAsteroid[4]);
        }
    }
}
