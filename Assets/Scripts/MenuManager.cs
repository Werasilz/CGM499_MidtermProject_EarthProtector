using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartButton()
    {
        SceneManager.LoadScene("ARGame");
        PlaceObjectOnPlane.isSetPos = false;
    }
}
