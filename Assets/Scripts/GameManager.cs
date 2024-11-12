
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    //Referencing scripts
    public Guard[] guards;
    public Prisoner prisoner;
    public GameObject p;
    public Transform pellets;
    public Transform heart;
    public TMP_Text ScoreCounter;
    public TMP_Text LivesCounter;
    public TMP_Text ScoreLevelEnd;
    public TMP_Text LivesLevelEnd;
    public TMP_Text HighScoreCounter;
    private int GeneratedVal;
    [SerializeField] public GameObject GameOverScreen;
    [SerializeField] public GameObject LevelEndScreen;
    [SerializeField] public GameObject NoPelletsLeft;
    [SerializeField] public GameObject MobilisedWarning;

    //Other scripts can access/read these but can't edit 
    public int guardMultiplier { get; private set; } = 1;
    public int score { get; private set; }
    public int lives { get; private set; }

    public int powerupscore { get; private set; }

    private void Start()
    { 
        NewGame();
        HighScoreCounter.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    private void Update()
    {
        if (this.lives <= 0 && Input.GetKeyDown(KeyCode.Space))
        {
            NewGame();
        }
    }

    //When player first starts game
    public void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
        //GenerateNewPowerUpScore();
    }

    private void NewRound()
    {
        //Resetting pellets
        foreach (Transform pellet in this.pellets)
        {
            pellet.gameObject.SetActive(true);
        }

        ResetRound();
    }


    private void ResetRound()
    {
        //Resetting guards and prisoner.
        for (int i = 0; i < this.guards.Length; i++)
        {
            this.guards[i].ResetState();
        }

        this.prisoner.ResetState();
    }

    public void EndGame()
    {
        for (int i = 0; i < this.guards.Length; i++)
        {
            guards[i].gameObject.SetActive(false);
        }

        prisoner.gameObject.SetActive(false);
        DeactivateMobilisedWarning();
        EnableGameOverScreen();
    }
    private void SetScore(int score)
    {
        this.score = score;
        //Debug.Log(score);
        ScoreCounter.text = score.ToString();
        ScoreLevelEnd.text = score.ToString();

        if (score > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            HighScoreCounter.text = score.ToString();
        }
        //if (score == powerupscore)
        //{
        //EnableHeart();
        //}
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        LivesLevelEnd.text = lives.ToString();
        LivesCounter.text = lives.ToString();
    }

    public void PrisonerCaptured()
    {
        SetLives(lives - 1);
        if (this.lives > 0)
        {
            ResetRound();
            //Invoke(nameof(ResetRound), 3.0f);
        }
        else
        {
            EndGame();
        }
    }

    public void PelletCollected(Pellet pellet)
    {
        pellet.gameObject.SetActive(false);
        SetScore(this.score + pellet.points);

        if (!PelletsRemaining())
        {
            NoPelletsLeft.SetActive(true);
        }
    }

    public void KeyCollected(Pellet pellet)
    {
        //looping through all guards
        for (int i = 0; i < this.guards.Length; i++)
        {
            this.guards[i].mobilised.Enable(8.0f);
        }
        MobilisedWarning.SetActive(true);
        PelletCollected(pellet);
    }
    public void EnableHeart()
    {
        heart.gameObject.SetActive(true);
    }
    public void HeartPowerup(HeartPowerup heart)
    {
        heart.gameObject.SetActive(false);
        AddLife();
    }

    private bool PelletsRemaining()
    {
        //looping through all pellets
        foreach (Transform pellet in this.pellets)
        {
            if (pellet.gameObject.activeSelf)
            {
                return true;
            }
        }

        return false;
    }

    //private void GenerateNewPowerUpScore()
    //{
        //GeneratedVal = UnityEngine.Random.Range(10, 100);

        //SetPowerupScore();
    //}
    //private void SetPowerupScore()
    //{
        //if (GeneratedVal % 10 == 0)
        //{
            //powerupscore = GeneratedVal;
        //}
        //else
        //{
            //GenerateNewPowerUpScore();
        //}

        //Debug.Log(powerupscore);
    //}

    public void EnableGameOverScreen()
    {
        p.gameObject.SetActive(false);
        GameOverScreen.SetActive(true);
    }

    public void EnableLevelEndScreen()
    {
        LevelEndScreen.SetActive(true);
    }

    public void DeactivateMobilisedWarning()
    {
        MobilisedWarning.SetActive(false);
    }

    public void RemoveAllLives()
    {
        //set to one as the set lives method subtracts one. So if it was set to 0, the lives would be -1 which doesn't work.
        lives = 1;
    }

    public void AddLife()
    {
        SetLives(lives + 1);
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteAll();
        HighScoreCounter.text = "0";
    }
}