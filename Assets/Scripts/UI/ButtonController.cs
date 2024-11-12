using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void ClickToPlay()
    {
        SceneManager.LoadScene("PrisonEscapeGame");
    }

    public void Settings()
    {
        SceneManager.LoadScene("SettingsScreen");
    }

    public void SettingsBackButton()
    {
        SceneManager.LoadScene("InitialScreen");
    }

    public void Quit()
    {
        Application.Quit(); //only works in actual game
        UnityEditor.EditorApplication.isPlaying = false; //takes you out of play mode in editor
    }

    //GameEndScreen
    public void PlayAgain()
    {
        SceneManager.LoadScene("PrisonEscapeGame");
    }
    public void Menu()
    {
        SceneManager.LoadScene("InitialScreen");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlayScreen");
    }
    public void BackToSettings()
    {
        SceneManager.LoadScene("SettingsScreen");
    }
}
