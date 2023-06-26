using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Placement : MonoBehaviour
{
    [SerializeField] GameObject planeMarkerPrefab;

    private ARRaycastManager raycastManager;
    private Vector2 touchPosition;
    private bool isSpawn = false;

    public GameObject objectToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
        planeMarkerPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawn)
            ShowMarker();
    }

    void ShowMarker()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        if(hits.Count > 0)
        {
            planeMarkerPrefab.transform.position = hits[0].pose.position;
            planeMarkerPrefab.SetActive(true);
        }

        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Instantiate(objectToSpawn, hits[0].pose.position, objectToSpawn.transform.rotation);
            isSpawn = true;
        }
    }

}
