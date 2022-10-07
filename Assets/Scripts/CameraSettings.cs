using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    public CursorLockMode cursor;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = cursor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
