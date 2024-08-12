using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneChange : MonoBehaviour
{
    public void ChangeFullScreen()
    {
        if (Screen.fullScreen)
        {
            Screen.fullScreen = false;
            Screen.SetResolution(1600, 900, false);
        }
        else
        {
            Screen.fullScreen = true;
            Screen.SetResolution(1920, 1080, true);
        }
    }

    public void TurnMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void TurnPlatform()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void TurnSummon()
    {
        SceneManager.LoadScene(2);
    }

    public void TurnLibrary()
    {
        SceneManager.LoadScene(3);
    }

    public void TurnMathTestAdd()
    {
        SceneManager.LoadScene(4);
    }

    public void TurnMathTestMul()
    {
        SceneManager.LoadScene(5);
    }

    public void TurnBattleScene0()
    {
        SceneManager.LoadScene(6);
    }

    public void TurnBattleScene1()
    {
        SceneManager.LoadScene(7);
    }

    public void TurnBattleScene2()
    {
        SceneManager.LoadScene(8);
    }

    public void TurnBattleScene3()
    {
        SceneManager.LoadScene(9);
    }

    public void TurnBattleScene4()
    {
        SceneManager.LoadScene(10);
    }

    public void TurnBattleScene5()
    {
        SceneManager.LoadScene(11);
    }

    public void TurnBattleScene6()
    {
        SceneManager.LoadScene(12);
    }

    public void TurnBattleScene7()
    {
        SceneManager.LoadScene(13);
    }

    public void TurnBattleScene8()
    {
        SceneManager.LoadScene(14);
    }

    public void TurnBattleScene9()
    {
        SceneManager.LoadScene(15);
    }

    public void TurnKitchen()
    {
        SceneManager.LoadScene(16);
    }

    public void TurnStoryteller()
    {
        SceneManager.LoadScene(17);
    }

}
