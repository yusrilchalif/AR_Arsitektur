using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToPlace : MonoBehaviour
{
    [SerializeField] GameObject arObjectToSpawn;
    [SerializeField] GameObject placementIndicator;

    private GameObject spawnObject;
    private Pose placementPose;
    private ARRaycastManager raycastManager;
    private bool placementPoseIsValid = false;

    // Start is called before the first frame update
    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ARPlaceObject();
        }
        UpdatePlacementIndicator();
        UpdatePlacementPose();
    }

    void ARPlaceObject()
    {
        spawnObject = Instantiate(arObjectToSpawn, placementPose.position, placementPose.rotation);
    }

    void UpdatePlacementIndicator()
    {
        if(spawnObject == null && placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        raycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
            placementPose = hits[0].pose;

    }
}
