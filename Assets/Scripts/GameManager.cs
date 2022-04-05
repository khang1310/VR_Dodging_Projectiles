using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class manages the how the game operates.
/// </summary>
public class GameManager : MonoBehaviour {
    /* Elements */
    private static GameManager instance;

    private bool playerLose;
    private bool playerWin;
    // This one should be private, make it public to test.
    private bool isInALevel;

    /* Getters/Setters */
    public static GameManager Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<GameManager>();
            }

            return instance;
        }

        set {
            instance = value;
        }
    }

    public bool PlayerLose { get => playerLose; set => playerLose = value; }
    public bool PlayerWin { get => playerWin; set => playerWin = value; }
    public bool IsInALevel { get => isInALevel; set => isInALevel = value; }

    // Start is called before the first frame update
    void Start() {
        if (instance == null) {
            instance = this;
        }

        isInALevel = false;

        DontDestroyOnLoad(gameObject);

        // For testing
        //Resources.FindObjectsOfTypeAll<StatsHandler>()[0].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update() {
        if (isInALevel) {
            if (StatsHandler.Instance.CurrentLives == 0) {
                playerLose = true;
            }

            if (StatsHandler.Instance.TimeLeft == 0) {
                playerWin = true;
            }
        }
    }
}
