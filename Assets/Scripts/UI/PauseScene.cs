using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PauseScene 
{
    public static void Pause()
    {
        Time.timeScale = 0f;
    }

    public static void Resume()
    {
        Time.timeScale = 1f;
    }
}
