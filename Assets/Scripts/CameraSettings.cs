using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    public CursorLockMode cursor;
    void Start()=> Cursor.lockState = cursor;
}
