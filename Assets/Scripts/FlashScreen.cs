using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlashScreen : MonoBehaviour
{
    private SceneData sceneData;

    void Awake()
    {
       
        SceneManager.LoadScene(SceneData.PrototypeOldInputs.ToString(),LoadSceneMode.Additive);
        sceneData = SceneData.PrototypeOldInputs;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SwitchScenes();
    }

    void SwitchScenes()
    {
        if (sceneData == SceneData.MiniGameOne)
        {
            SceneManager.UnloadScene(SceneData.MiniGameOne.ToString());
            SceneManager.LoadScene(SceneData.PrototypeOldInputs.ToString(),LoadSceneMode.Additive);
            sceneData = SceneData.PrototypeOldInputs;
            Debug.Log("Prototyped loaded");
        }
        else
        {
            SceneManager.UnloadScene(SceneData.PrototypeOldInputs.ToString());
            SceneManager.LoadScene(SceneData.MiniGameOne.ToString(),LoadSceneMode.Additive);
            sceneData = SceneData.MiniGameOne;
            Debug.Log("mini game loaded");
        }
    }
}
