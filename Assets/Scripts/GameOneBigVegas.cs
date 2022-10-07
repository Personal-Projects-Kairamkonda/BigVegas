using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOneBigVegas : MonoBehaviour
{
    public GameOneDoozy doozy;

    private string style1="Chicken Dance";
    private string style2= "Gangnam Style";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            PlayChickenDance();
    }

    public void PlayChickenDance()
    {
        this.transform.GetChild(0).GetComponent<Animator>().Play(style1);
    }

    public void PlayWarriorIdle()
    {
        this.transform.GetChild(0).GetComponent<Animator>().Play(style2);
    }

}
