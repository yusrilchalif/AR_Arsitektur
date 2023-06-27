using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BottomSheetDialog : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform upMenuRectTransform;

    private float height;
    private float starPositionY;
    private float startingAnchoredPositionY;

    public enum Side { down, up }
    public Side side;

    void Start()
    {
        height = Screen.height;
    }

    public void OnDrag(PointerEventData eventData)
    {
        upMenuRectTransform.anchoredPosition = new Vector2(Mathf.Clamp(startingAnchoredPositionY - (starPositionY - eventData.position.y), GetMinPosition(), GetMaxPosition()), 0);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StopAllCoroutines();
        starPositionY = eventData.position.y;
        startingAnchoredPositionY = upMenuRectTransform.anchoredPosition.y;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StartCoroutine(HandleMenuSlide(.25f, upMenuRectTransform.anchoredPosition.y, isAfterHalfPoint() ? GetMinPosition() : GetMaxPosition()));
    }

    private bool isAfterHalfPoint()
    {
        if (side == Side.up)
            return upMenuRectTransform.anchoredPosition.y < height;
        else
            return upMenuRectTransform.anchoredPosition.y < 0;
    }

    private float GetMinPosition()
    {
        if (side == Side.up)
            return height/2f;
        return -height * .4f;
    }

    private float GetMaxPosition()
    {
        if (side == Side.up)
            return height * 1.4f;
        return height / 2;
    }

    private IEnumerator HandleMenuSlide(float slideTime, float startingY, float targetY)
    {
        for (float i = 0; i < slideTime; i+= .025f)
        {
            upMenuRectTransform.anchoredPosition = new Vector2(Mathf.Lerp(startingY, targetY, i / slideTime), 0);
            yield return new WaitForSecondsRealtime(.025f);
        }
    }
}
