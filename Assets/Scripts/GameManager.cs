using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameOneDoozy doozy;
    public GameOneBigVegas bigVegas;
    public Button[] playerButtons;
    public TextMeshProUGUI scoreText;

    private string doozyState;
    private string bigVegasState;
    private int score;

    void Awake()
    {
        playerButtons[0].onClick.AddListener(Style1);
        playerButtons[1].onClick.AddListener(Style2);
        playerButtons[2].onClick.AddListener(Style3);
        playerButtons[3].onClick.AddListener(Style4);

        DisableButtons();
        StartCoroutine(PlayState());
    }

    IEnumerator CheckSimilarState()
    {
        DisableButtons();
        yield return new WaitForSeconds(1f);

        doozyState = doozy.AnimatorInfo();
        bigVegasState = bigVegas.AnimatorInfo();

        if (doozyState == bigVegasState)
            score++;
        else
            bigVegas.UpdateDialougeText("Try Again");

        UpdateScore();

        yield return new WaitForSeconds(3f);
        EnableButtons();

        doozy.RandomAnimation();

        StopCoroutine(CheckSimilarState());
    }

     void UpdateScore() 
     {
        scoreText.text = score.ToString();
    }

    IEnumerator PlayState()
    {
        yield return new WaitForSeconds(14f);
        EnableButtons();
        StopCoroutine(PlayState());
    }

    public void Style1()
    {
        bigVegas.PlayHipHopDancing();
        StartCoroutine(CheckSimilarState());
    }

    public void Style2()
    {
        bigVegas.PlayGangnamStyle();
        StartCoroutine(CheckSimilarState());
    }

    public void Style3()
    {
        bigVegas.PlayChickenDance();
        StartCoroutine(CheckSimilarState());
    }

    public void Style4()
    {
        bigVegas.PlayRobotHipHopDance();
        StartCoroutine(CheckSimilarState());
    }

    void DisableButtons()
    {
        for (int i = 0; i < playerButtons.Length; i++)
            playerButtons[i].interactable = false;
    }

    void EnableButtons()
    {
        for (int i = 0; i < playerButtons.Length; i++)
            playerButtons[i].interactable = true;
    }
 
    void DebugBothCharacterStatesInfo()
    {
       Debug.Log($"Doozy state: {doozyState}");
       Debug.Log($"Big Vegas state: {bigVegasState}");
    }
}
