using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenericSceneLoader : MonoBehaviour
{
    public string nextScene;

    private LineRenderer lineRenderer;

    void Awake() => lineRenderer = GetComponent<LineRenderer>();
    void Start() => Portal();

    private void Portal()
    {
        float x = Mathf.Cos(Time.time);
        float z = Mathf.Sin(Time.time);

        lineRenderer.SetPosition(0, new Vector3(x, 0, z));
    }

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(nextScene);
    }
}
