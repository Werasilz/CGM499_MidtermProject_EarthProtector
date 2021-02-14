using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public ParticleSystem bulletParticle;
    public ParticleSystem explosion;
    private bool isShoot;

    RaycastHit hitRay;

    void Start()
    {

    }

    void Update()
    {
        if (isShoot)
        {
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z), transform.forward * 1000, Color.red);
            bulletParticle.gameObject.SetActive(true);

            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z), transform.forward, out hitRay, 1000)) 
            {
                if (hitRay.collider.tag == "enemy")
                {
                    Destroy(hitRay.collider.gameObject);
                    Instantiate(explosion, hitRay.collider.gameObject.transform.position, hitRay.collider.gameObject.transform.rotation);
                    GameManager.score += 1;
                }
            }
        }
        else if (!isShoot)
        {
            bulletParticle.gameObject.SetActive(false);
        }
    }

    public void onPress()
    {
        isShoot = true;
        Debug.Log("Press");
    }

    public void onRelease()
    {
        isShoot = false;
        Debug.Log("Release");
    }
}





