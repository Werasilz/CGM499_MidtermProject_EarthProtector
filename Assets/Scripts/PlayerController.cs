using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Transform arCamera;
    private Animator anim;
    public Quaternion rotateArCamera = Quaternion.identity;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, arCamera.eulerAngles.y - 15f, transform.eulerAngles.z);
    }

    void FixedUpdate()
    {
        float horizontal = variableJoystick.Horizontal;
        float vertical = variableJoystick.Vertical;

        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        transform.Translate(movement * speed * Time.deltaTime);

        if(horizontal != 0 || vertical != 0)
        {
            anim.SetBool("IsRun", true);
        }
        else
        {
            anim.SetBool("IsRun", false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("space"))
        {
            SceneManager.LoadScene("Main");
            PlaceObjectOnPlane.isSetPos = false;
        }
    }
}
