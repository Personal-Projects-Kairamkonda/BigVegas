using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEditor.Rendering;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FlashScreen : MonoBehaviour
{
    public GameObject settingsPanel;

    private SceneData sceneData;
    private int score;

    public static FlashScreen instance;
    public TextMeshProUGUI playerDialougeText;

    void Awake()
    {
        if(instance==null)
            instance = this;
    }

    void Start()
    {
        SceneManager.LoadSceneAsync(SceneData.MapScene.ToString(), LoadSceneMode.Additive);
        sceneData = SceneData.MapScene;
    }

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
          EnableSoundsPanel();
    }


    public void EnableSoundsPanel()
    {
        settingsPanel.GetComponent<PanelAnimation>().OpenPanel();
        Cursor.lockState = CursorLockMode.None;
        //PauseScene.Pause();
    }

    public void DisableSoundsPanel()
    {
        settingsPanel.GetComponent<PanelAnimation>().ClosePanel();
        Cursor.lockState = CursorLockMode.Locked;
        //PauseScene.Resume();
    }

    public void UpdateDialougeText(string dialouge)
    {
        playerDialougeText.text = dialouge;
    }

    void SwitchScenes()
    {
        if (sceneData == SceneData.MiniGameOne)
            MapScene();
        else
            MiniGameOne();
    }

    public void MapScene()
    {
        SceneManager.UnloadSceneAsync(SceneData.MiniGameOne.ToString());
        SceneManager.LoadSceneAsync(SceneData.MapScene.ToString(), LoadSceneMode.Additive);
        sceneData = SceneData.MapScene;
        Debug.Log("Map Scene Loaded");
    }

    public void MiniGameOne()
    {
        SceneManager.UnloadSceneAsync(SceneData.MapScene.ToString());
        SceneManager.LoadSceneAsync(SceneData.MiniGameOne.ToString(), LoadSceneMode.Additive);
        sceneData = SceneData.MiniGameOne;
        Debug.Log("Mini Game One Loaded");
    }

    public void ClearScenes()
    {
       

    }
}
