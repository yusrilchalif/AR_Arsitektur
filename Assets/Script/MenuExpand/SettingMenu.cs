using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    [SerializeField] Vector2 spacing;

    Button mainButton;
    SettingMenuItem[] menuItems;
    bool isExpanded = false;

    Vector2 mainButtonPosition;
    int itemsCount;

    // Start is called before the first frame update
    void Start()
    {
        itemsCount = transform.childCount - 1;
        menuItems = new SettingMenuItem[itemsCount];

        for (int i = 0; i < itemsCount; i++)
        {
            menuItems[i] = transform.GetChild(i + 1).GetComponent<SettingMenuItem>();
        }

        mainButton = transform.GetChild(0).GetComponent<Button>();
        mainButton.onClick.AddListener(ToggleMenu);
        mainButton.transform.SetAsLastSibling();
        mainButtonPosition = mainButton.transform.position;

        ResetPosition();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ResetPosition()
    {
        for (int i = 0; i < itemsCount; i++)
        {
            menuItems[i].trans.position = mainButtonPosition;
        }
    }

    void ToggleMenu()
    {
        isExpanded = !isExpanded;

        if(isExpanded)
        {
            for (int i = 0; i < itemsCount; i++)
            {
                menuItems[i].trans.position = mainButtonPosition + spacing * (i + 1);
            }
        }
        else
        {
            for (int i = 0; i < itemsCount; i++)
            {
                menuItems[i].trans.position = mainButtonPosition;
            }
        }
    }

    private void OnDestroy()
    {
        mainButton.onClick.RemoveListener(ToggleMenu);
    }
}
