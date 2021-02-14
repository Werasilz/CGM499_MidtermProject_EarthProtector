using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class PlaceObjectOnPlane : MonoBehaviour
{
    [SerializeField]
    private ARRaycastManager raycastManager;

    [SerializeField]
    private GameObject objectToPlace;

    [SerializeField]
    private GameObject canvas;

    [SerializeField]
    private Button setPosBtn;

    [SerializeField]
    private Button resetPosBtn;

    [SerializeField]
    private VariableJoystick variableJoystick;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private Vector3 defaultPos;
    private Quaternion defaultRotate;
    public static bool isSetPos = false;

    void Start()
    {
        objectToPlace.SetActive(false);
        canvas.SetActive(false);
        variableJoystick.gameObject.SetActive(false);
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            //if(touch.phase == TouchPhase.Began)
            //{
                if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hits[0].pose;

                    if (!objectToPlace.activeInHierarchy)
                    {
                        objectToPlace.SetActive(true);
                        canvas.SetActive(true);

                        objectToPlace.transform.rotation = Quaternion.Euler(hitPose.rotation.x, hitPose.rotation.y, hitPose.rotation.z);
                        objectToPlace.transform.position = hitPose.position;
                    }
                    else
                    {
                        if (!isSetPos)
                        {
                            objectToPlace.transform.position = hitPose.position;
                            objectToPlace.transform.rotation = hitPose.rotation;
                            defaultPos = hitPose.position;
                            defaultRotate = hitPose.rotation;
                        }
                        else
                        {
                            objectToPlace.transform.position = defaultPos;
                            objectToPlace.transform.rotation = defaultRotate;
                        }
                    }
                }
            //}
        }
    }

    public void SetPositionToDefault()
    {
        isSetPos = true;
        setPosBtn.gameObject.SetActive(false);
        variableJoystick.gameObject.SetActive(true);
        SpawnAsteroid.instance.StartRandom();
    }

    public void ReSetPosition()
    {
        isSetPos = false;
        setPosBtn.gameObject.SetActive(true);
        variableJoystick.gameObject.SetActive(false);
    }
}
