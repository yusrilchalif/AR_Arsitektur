using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceObj : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject IndicatorHolder;

    private ARRaycastManager arOrigin;
    private Pose placementPose;
    private ARPlaneManager planeManager;

    private bool placementPoseIsValid = false;
    private bool hasSpawnedObject = false;
    private GameObject spawnedObject;

    void Start()
    {
        //IndicatorHolder = GameObject.Find("IndicatorHolder");
        arOrigin = FindObjectOfType<ARRaycastManager>();
        planeManager = FindAnyObjectByType<ARPlaneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    PlaceObject();
        //    placementPoseIsValid = true;
        //}

        //if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    PlaceObject();
        //}

        if(!hasSpawnedObject && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PlaceObject();
        }

        UpdateIndicatorHolder();
        UpdatePlacementPose();
    }

    private void PlaceObject()
    {
        spawnedObject = Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
        Destroy(IndicatorHolder);
        hasSpawnedObject = true;
    }

    private void UpdateIndicatorHolder()
    {
        if (placementPoseIsValid)
        {
            IndicatorHolder.SetActive(true);
            IndicatorHolder.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            IndicatorHolder.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arOrigin.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }
}
