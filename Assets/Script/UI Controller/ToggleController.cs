using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    public GameObject objectToControl;
    public Toggle toggle;

    // Dipanggil ketika nilai Toggle berubah
    public void OnToggleValueChanged()
    {
        if (objectToControl != null)
        {
            objectToControl.SetActive(toggle.isOn);
        }
    }
}
