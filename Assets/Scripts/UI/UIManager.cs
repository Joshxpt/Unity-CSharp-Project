using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject LevelEndScreen;
    public AudioClip gameOverSound;

    //enabling the screen
    public void EnableGameOverScreen()
    {
        GameOverScreen.SetActive(true);
    }
}
