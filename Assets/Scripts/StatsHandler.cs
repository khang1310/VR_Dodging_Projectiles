using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class handles the stats of the player.
/// </summary>
public class StatsHandler : MonoBehaviour {
    /* Elements */
    private static StatsHandler instance;

    private int maxLives;
    private int currentLives;

    private float timeLeft;
    private bool timerIsRunning;

    [Header("Text")]
    [SerializeField] private Text livesText;
    [SerializeField] private Text timeLeftText;
    [SerializeField] private Text winLoseText;

    /* Getters/Setters */
    public static StatsHandler Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<StatsHandler>();
            }

            return instance;
        }

        set {
            instance = value;
        }
    }

    public int MaxLives { get => maxLives; set => maxLives = value; }
    public int CurrentLives { get => currentLives; set => currentLives = value; }
    public Text LivesText { get => livesText; set => livesText = value; }
    public Text TimeLeftText { get => timeLeftText; set => timeLeftText = value; }
    public float TimeLeft { get => timeLeft; set => timeLeft = value; }

    // Start is called before the first frame update
    void Start() {
        if (instance == null) {
            instance = this;
        }
    }

    // This function is called when the object becomes enabled and active.
    private void OnEnable() {
        maxLives = LevelManager.Instance.CurrentLevel.maxLives;
        currentLives = maxLives;

        // If survival mode, enable the time text.
        if (LevelManager.Instance.CurrentLevel.isSurvival) {
            timeLeft = LevelManager.Instance.CurrentLevel.timeToWin;
            timeLeftText.gameObject.SetActive(true);
            timerIsRunning = true;
        }

        // If not survival mode, hide the time text.
        else if (LevelManager.Instance.CurrentLevel.isReachingDestination) {
            timeLeftText.gameObject.SetActive(false);
            timerIsRunning = false;
        }
    }

    // Update is called once per frame
    void Update() {
        livesText.text = "Lives: " + currentLives.ToString() + "/" + maxLives.ToString();

        if (currentLives == 0) {
            winLoseText.gameObject.SetActive(true);
            winLoseText.text = "You Lost...";
        }

        // Displaying the time
        if (timerIsRunning && GameManager.Instance.PlayerLose == false) {
            if (timeLeft > 0) {
                timeLeft -= Time.deltaTime;
            }

            else {
                timeLeft = 0;
                timerIsRunning = false;

                winLoseText.gameObject.SetActive(true);
                winLoseText.text = "You Won!";
            }
        }

        if (LevelManager.Instance.CurrentLevel.isSurvival) {
            DisplayTime(timeLeft);
        }
    }

    /// <summary>
    /// Display how much time left.
    /// </summary>
    /// <param name="time"></param>
    public void DisplayTime(float time) {
        if (time != 0) {
            time += 1;
        }

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timeLeftText.text = "Time Left: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
