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

    }


    IEnumerator CheckSimilarState()
    {
        yield return new WaitForSeconds(1f);

        doozyState = doozy.AnimatorInfo();
        bigVegasState = bigVegas.AnimatorInfo();

        if (doozyState == bigVegasState)
            ++score;
        else
            bigVegas.UpdateDialougeText("Try Againn");

        UpdateScore();
        doozy.RandomAnimation();

        StopCoroutine(CheckSimilarState());
    }
   
    void UpdateScore()
    {
        //Debug.Log($"Score : {score}");
        scoreText.text = score.ToString();

        Debug.Log(2);
    }

    void DebugBothCharacterStatesInfo()
    {
       Debug.Log($"Doozy state: {doozyState}");
       Debug.Log($"Big Vegas state: {bigVegasState}");
    }


}
