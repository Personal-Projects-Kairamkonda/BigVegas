using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAnimation : MonoBehaviour
{
    private Animator animator;

    void OnEnable()
    {
        ClosePanel();
    }

    public void OpenPanel()
    {
        this.GetComponent<Animator>().Play("Open");
    }

    public void ClosePanel()
    {
        this.GetComponent<Animator>().Play("Close");
    }

}
