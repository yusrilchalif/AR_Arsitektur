using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject panelViewer;
    public bool isActive = false;

    public RotateObject rotateObject;

    // Start is called before the first frame update
    void Start()
    {
        panelViewer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveDeactiveButton()
    {
        bool isActive = panelViewer.activeSelf;
        if (isActive)
        {
            panelViewer.transform.DOScaleY(0f, 0.3f).SetEase(Ease.OutSine).OnComplete(() => panelViewer.SetActive(false));
            rotateObject.enabled = true;
        }
        else
        {
            panelViewer.SetActive(true);
            panelViewer.transform.localScale = new Vector3(1f, 0f, 1f);
            panelViewer.transform.DOScaleY(1f, 0.3f).SetEase(Ease.OutSine);
            rotateObject.enabled = false;
        }
            
    }
}
