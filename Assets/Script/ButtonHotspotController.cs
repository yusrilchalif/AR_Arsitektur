using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG;
using DG.Tweening;

public class ButtonHotspotController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject panelInformation;
    public Transform target;

    private Quaternion initialQuaternion;
    private LineRendererController lineRendererController;

    // Start is called before the first frame update
    void Start()
    {
        panelInformation.SetActive(false);
        initialQuaternion = transform.rotation;

        lineRendererController = GetComponent<LineRendererController>();
        lineRendererController.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 dir = target.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            //update position on panel Information
            Vector3 panelInfo = target.position;
            panelInfo.y += 1.5f; //custom height if needed
            panelInfo.x += 2.0f; //custom width if needed
            panelInformation.transform.position = panelInfo;
        }
        else
        {
            //reset position
            transform.rotation = initialQuaternion;
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(0.008f, 0.008f, 0.008f), 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(0.005f, 0.005f, 0.005f), 0.3f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnPointerExit(eventData);
        ShowPopUP();

        Debug.Log("Button clicked");
    }

    private void ShowPopUP()
    {
        panelInformation.SetActive(true);
        lineRendererController.enabled = true;
    }

    
}
