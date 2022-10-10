using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenericSceneLoader : MonoBehaviour
{
    public string nextScene;

    private LineRenderer lineRenderer;

    void Awake() => lineRenderer = GetComponent<LineRenderer>();
    void Start() => Portal(30,1.5f);

    private void Portal(int steps, float radius)
    {
        lineRenderer.positionCount = steps;

        for (int i = 0; i < steps; i++)
        {
            float circumferenceProgress = (float) i / steps;
            float currentRadian = circumferenceProgress * 2 * Mathf.PI;

            float x = (Mathf.Cos(currentRadian) *radius);
            float y = (Mathf.Sin(currentRadian)* radius);
            float z = 0;

            Vector3 currentPos= new Vector3(x, y, z);
            lineRenderer.SetPosition(i, currentPos);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        FlashScreen.instance.MiniGameOne();
    }
}
