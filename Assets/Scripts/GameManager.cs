using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Transform[] levels;
    public string[] levelNames;
    public Sprite[] levelSprites;
    public int lives;
    public int score;
    public Text livesText;
    public Text scoreText;
    public Text levelText;
    public bool gameOver;
    public bool levelOver;
    public GameObject gameOverPanel;
    public GameObject levelPanel;
    public GameObject highScorePanel;
    public Text levelPanelTitle;
    public Text levelPanelName;
    public Image levelPanelImage;
    public int numberOfBricks;
    public int singleLifeValue;
    public int currentLevel;
    public Transform paddle;
    public Transform ball;
    public InputField highScoreName;
    public AudioSource soundBallBounce;
    public AudioSource soundBrickHit1;
    public AudioSource soundBrickHit2;
    public AudioSource soundBrickHitExplode;
    public AudioSource soundCaughtPowerUp;
    public AudioSource soundLossOfLife;


    // Start is called before the first frame update
    void Start()
    {
        displayLevelPanel();
        updateGameStats();
        Invoke("loadNextLevel", 4f);
        // loadNextLevel();
    }


    void countBricks(){
        numberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver){
            updateGameStats();
        }
            
    }

    void valueLeftOverLives() {
        if (lives > 0) {
            lives--;
            score += singleLifeValue;
            updateLivesText();
            updateScoreText();
        } else {
            CancelInvoke();
            checkForHighScore();
        }
    }

    private void updateScoreText() {
        scoreText.text = $"Score: {String.Format("{0:n0}", score)}";
    }

    private void updateLivesText() {
        livesText.text = $"Lives: {String.Format("{0:n0}", lives)}";
    }

    private void updateLevelText() {
        levelText.text = $"Level: {String.Format("{0:n0}", currentLevel)}";
    }
    public void updateGameStats() {
        updateScoreText();
        updateLivesText();
        updateLevelText();
    }

    public void addLife() {
        lives++;
    }
    public void loseLife() {
        lives--;
        if (lives < 1) {
            endGame();
        }
    }

    public void updateScore(int points) {
        score += points;
        if (lives < 1) {
            endGame();
        }
    }

    void checkForHighScore () {
        // PlayerPrefs.DeleteAll();
        int highScore6 = PlayerPrefs.GetInt("High_Score_6", 0);
        if (score > highScore6) {
            highScorePanel.SetActive(true);
            highScorePanel.transform.Find("InputField");
            highScoreName.Select();
        } else {
            displayGameOverPanel();
        }
    }

    public void saveHighScore () {
        int highScore1 = PlayerPrefs.GetInt("High_Score_1", 0);
        int highScore2 = PlayerPrefs.GetInt("High_Score_2", 0);
        int highScore3 = PlayerPrefs.GetInt("High_Score_3", 0);
        int highScore4 = PlayerPrefs.GetInt("High_Score_4", 0);
        int highScore5 = PlayerPrefs.GetInt("High_Score_5", 0);
        int highScore6 = PlayerPrefs.GetInt("High_Score_6", 0);
        string highScore1Player = PlayerPrefs.GetString("High_Score_1_Player");
        string highScore2Player = PlayerPrefs.GetString("High_Score_2_Player");
        string highScore3Player = PlayerPrefs.GetString("High_Score_3_Player");
        string highScore4Player = PlayerPrefs.GetString("High_Score_4_Player");
        string highScore5Player = PlayerPrefs.GetString("High_Score_5_Player");
        string highScore6Player = PlayerPrefs.GetString("High_Score_6_Player");
        string highScore1Date = PlayerPrefs.GetString("High_Score_1_Date");
        string highScore2Date = PlayerPrefs.GetString("High_Score_2_Date");
        string highScore3Date = PlayerPrefs.GetString("High_Score_3_Date");
        string highScore4Date = PlayerPrefs.GetString("High_Score_4_Date");
        string highScore5Date = PlayerPrefs.GetString("High_Score_5_Date");
        string highScore6Date = PlayerPrefs.GetString("High_Score_6_Date");

        if (score > highScore1) {
            PlayerPrefs.SetInt("High_Score_1", score);
            PlayerPrefs.SetString("High_Score_1_Player", highScoreName.text);
            PlayerPrefs.SetString("High_Score_1_Date", DateTime.Today.ToString("d"));
            PlayerPrefs.SetInt("High_Score_2", highScore1);
            PlayerPrefs.SetString("High_Score_2_Player", highScore1Player);
            PlayerPrefs.SetString("High_Score_2_Date", highScore1Date);
            PlayerPrefs.SetInt("High_Score_3", highScore2);
            PlayerPrefs.SetString("High_Score_3_Player", highScore2Player);
            PlayerPrefs.SetString("High_Score_3_Date", highScore2Date);
            PlayerPrefs.SetInt("High_Score_4", highScore3);
            PlayerPrefs.SetString("High_Score_4_Player", highScore3Player);
            PlayerPrefs.SetString("High_Score_4_Date", highScore3Date);
            PlayerPrefs.SetInt("High_Score_5", highScore4);
            PlayerPrefs.SetString("High_Score_5_Player", highScore4Player);
            PlayerPrefs.SetString("High_Score_5_Date", highScore4Date);
            PlayerPrefs.SetInt("High_Score_6", highScore5);
            PlayerPrefs.SetString("High_Score_6_Player", highScore5Player);
            PlayerPrefs.SetString("High_Score_6_Date", highScore5Date);
        } else if (score > highScore2) {
            PlayerPrefs.SetInt("High_Score_2", score);
            PlayerPrefs.SetString("High_Score_2_Player", highScoreName.text);
            PlayerPrefs.SetString("High_Score_2_Date", DateTime.Today.ToString("d"));
            PlayerPrefs.SetInt("High_Score_3", highScore2);
            PlayerPrefs.SetString("High_Score_3_Player", highScore2Player);
            PlayerPrefs.SetString("High_Score_3_Date", highScore2Date);
            PlayerPrefs.SetInt("High_Score_4", highScore3);
            PlayerPrefs.SetString("High_Score_4_Player", highScore3Player);
            PlayerPrefs.SetString("High_Score_4_Date", highScore3Date);
            PlayerPrefs.SetInt("High_Score_5", highScore4);
            PlayerPrefs.SetString("High_Score_5_Player", highScore4Player);
            PlayerPrefs.SetString("High_Score_5_Date", highScore4Date);
            PlayerPrefs.SetInt("High_Score_6", highScore5);
            PlayerPrefs.SetString("High_Score_6_Player", highScore5Player);
            PlayerPrefs.SetString("High_Score_6_Date", highScore5Date);
        } else if (score > highScore3) {
            PlayerPrefs.SetInt("High_Score_3", score);
            PlayerPrefs.SetString("High_Score_3_Player", highScoreName.text);
            PlayerPrefs.SetString("High_Score_3_Date", DateTime.Today.ToString("d"));
            PlayerPrefs.SetInt("High_Score_4", highScore3);
            PlayerPrefs.SetString("High_Score_4_Player", highScore3Player);
            PlayerPrefs.SetString("High_Score_4_Date", highScore3Date);
            PlayerPrefs.SetInt("High_Score_5", highScore4);
            PlayerPrefs.SetString("High_Score_5_Player", highScore4Player);
            PlayerPrefs.SetString("High_Score_5_Date", highScore4Date);
            PlayerPrefs.SetInt("High_Score_6", highScore5);
            PlayerPrefs.SetString("High_Score_6_Player", highScore5Player);
            PlayerPrefs.SetString("High_Score_6_Date", highScore5Date);
        } else if (score > highScore4) {
            PlayerPrefs.SetInt("High_Score_4", score);
            PlayerPrefs.SetString("High_Score_4_Player", highScoreName.text);
            PlayerPrefs.SetString("High_Score_4_Date", DateTime.Today.ToString("d"));
            PlayerPrefs.SetInt("High_Score_5", highScore4);
            PlayerPrefs.SetString("High_Score_5_Player", highScore4Player);
            PlayerPrefs.SetString("High_Score_5_Date", highScore4Date);
            PlayerPrefs.SetInt("High_Score_6", highScore5);
            PlayerPrefs.SetString("High_Score_6_Player", highScore5Player);
            PlayerPrefs.SetString("High_Score_6_Date", highScore5Date);
        } else if (score > highScore5) {
            PlayerPrefs.SetInt("High_Score_5", score);
            PlayerPrefs.SetString("High_Score_5_Player", highScoreName.text);
            PlayerPrefs.SetString("High_Score_5_Date", DateTime.Today.ToString("d"));
            PlayerPrefs.SetInt("High_Score_6", highScore5);
            PlayerPrefs.SetString("High_Score_6_Player", highScore5Player);
            PlayerPrefs.SetString("High_Score_6_Date", highScore5Date);
        } else if (score > highScore6) {
            PlayerPrefs.SetInt("High_Score_6", score);
            PlayerPrefs.SetString("High_Score_6_Player", highScoreName.text);
            PlayerPrefs.SetString("High_Score_6_Date", DateTime.Today.ToString("d"));
        }
        highScore1 = PlayerPrefs.GetInt("High_Score_1", 0);
        highScore2 = PlayerPrefs.GetInt("High_Score_2", 0);
        highScore3 = PlayerPrefs.GetInt("High_Score_3", 0);
        highScore4 = PlayerPrefs.GetInt("High_Score_4", 0);
        highScore5 = PlayerPrefs.GetInt("High_Score_5", 0);
        highScore6 = PlayerPrefs.GetInt("High_Score_6", 0);
        highScore1Player = PlayerPrefs.GetString("High_Score_1_Player");
        highScore2Player = PlayerPrefs.GetString("High_Score_2_Player");
        highScore3Player = PlayerPrefs.GetString("High_Score_3_Player");
        highScore4Player = PlayerPrefs.GetString("High_Score_4_Player");
        highScore5Player = PlayerPrefs.GetString("High_Score_5_Player");
        highScore6Player = PlayerPrefs.GetString("High_Score_6_Player");
        highScore1Date = PlayerPrefs.GetString("High_Score_1_Date");
        highScore2Date = PlayerPrefs.GetString("High_Score_2_Date");
        highScore3Date = PlayerPrefs.GetString("High_Score_3_Date");
        highScore4Date = PlayerPrefs.GetString("High_Score_4_Date");
        highScore5Date = PlayerPrefs.GetString("High_Score_5_Date");
        highScore6Date = PlayerPrefs.GetString("High_Score_6_Date");
        if (highScore1 > 0)
            gameOverPanel.transform.Find("HighScore1").GetComponent<Text>().text = $"{highScore1Player.ToUpper()} {String.Format("{0:n0}", highScore1)} {highScore1Date}";
        if (highScore2 > 0)
            gameOverPanel.transform.Find("HighScore2").GetComponent<Text>().text = $"{highScore2Player.ToUpper()} {String.Format("{0:n0}", highScore2)} {highScore2Date}";
        if (highScore3 > 0)
            gameOverPanel.transform.Find("HighScore3").GetComponent<Text>().text = $"{highScore3Player.ToUpper()} {String.Format("{0:n0}", highScore3)} {highScore3Date}";
        if (highScore4 > 0)
            gameOverPanel.transform.Find("HighScore4").GetComponent<Text>().text = $"{highScore4Player.ToUpper()} {String.Format("{0:n0}", highScore4)} {highScore4Date}";
        if (highScore5 > 0)
            gameOverPanel.transform.Find("HighScore5").GetComponent<Text>().text = $"{highScore5Player.ToUpper()} {String.Format("{0:n0}", highScore5)} {highScore5Date}";
        if (highScore6 > 0)
            gameOverPanel.transform.Find("HighScore6").GetComponent<Text>().text = $"{highScore6Player.ToUpper()} {String.Format("{0:n0}", highScore6)} {highScore6Date}";
        highScorePanel.SetActive(false);
        displayGameOverPanel();
    }

    void displayGameOverPanel() {
        gameOverPanel.SetActive(true); 
    }

    void displayLevelPanel() {
        levelPanelTitle.text = $"Level: {String.Format("{0:n0}", currentLevel)}";
        levelPanelName.text = this.levelNames[currentLevel-1];
        levelPanelImage.sprite = this.levelSprites[currentLevel-1];
        levelPanel.SetActive(true);
    }

    void hideLevelPanel() {
        levelPanel.SetActive(false);
    }

    void endGame() {
        if (numberOfBricks <= 0)
            InvokeRepeating("valueLeftOverLives", 0, 1.0F);
        else
            checkForHighScore();

        gameOver = true;

        // Destroy floating ball
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        Destroy(ball);

        // Destroy any floating extra life power-ups
        GameObject[] powerUps = GameObject.FindGameObjectsWithTag("ExtraLife");
        foreach(GameObject extraLife in powerUps){
            Destroy(extraLife);
        }

        // Destroy any bricks and paddle so they don't visually clog up the end game stuff.
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");
        foreach(GameObject brick in bricks){
            Destroy(brick);
        }

        GameObject paddle = GameObject.FindGameObjectWithTag("Paddle");
        Destroy(paddle);

    }

    public void PlayAgain () {
        SceneManager.LoadScene("Main");
    }

    public void Quit () {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void loadNextLevel () {
        hideLevelPanel();
        if (currentLevel != 99)
            Instantiate(levels[currentLevel-1], Vector2.zero, Quaternion.identity);
        // currentLevel++;
        numberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        levelOver = false;
    }

    public void updateNumberOfBricks(int num) {
        numberOfBricks += num;
        if (numberOfBricks <= 0) {
            if (currentLevel == levels.Length){
                endGame();
            } else {
                endLevel();
                currentLevel++;
                Invoke ("displayLevelPanel", 2f);
                Invoke("loadNextLevel", 4f);
            }
        }
    }

    void endLevel() {
        // Stop paddle from moving
        levelOver = true;

        // Move ball back to paddle
        var b = GameObject.FindObjectOfType<Ball>();
        b.inPlay = false;
        b.transform.position = paddle.position;
        b.rb.velocity = Vector2.zero;

        // Destroy any floating extra life power-ups
        GameObject[] powerUps = GameObject.FindGameObjectsWithTag("ExtraLife");
        foreach(GameObject extraLife in powerUps){
            Destroy(extraLife);
        }
    }
}
