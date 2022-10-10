using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAnimation : MonoBehaviour
{
    void OnEnable()
    {
        ClosePanel();
    }

    public void ClosePanel()
    {
        transform.position = (Vector3.right +Vector3.up)* 500*Time.deltaTime;
    }
}
