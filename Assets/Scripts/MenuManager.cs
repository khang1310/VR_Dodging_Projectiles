using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is responsible for managing the UI Menu.
/// </summary>
public class MenuManager : MonoBehaviour {
    /* Elements */
    private static MenuManager instance;

    /* Getters/Setters */
    public static MenuManager Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<MenuManager>();
            }

            return instance;
        }

        set {
            instance = value;
        }
    }

    // Start is called before the first frame update
    void Start() {
        if (instance == null) {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update() {

    }

    /// <summary>
    /// Load a survival level when click on a survival level button.
    /// </summary>
    /// <param name="levelCode"></param>
    public void LoadSurvivalLevel(int levelCode) {
        if (LevelManager.Instance.SurvivalLevels.Length >= levelCode) {
            string sceneName = "Survival_Level_" + levelCode.ToString();

            // Set the current level to the level the player chose and load the level.
            LevelManager.Instance.CurrentLevel = LevelManager.Instance.SurvivalLevels[levelCode - 1];
            SceneManager.LoadScene(sceneName);

            // Enable the stats display and let the game manager knows the player is in a level.
            Resources.FindObjectsOfTypeAll<StatsHandler>()[0].gameObject.SetActive(true);
            GameManager.Instance.IsInALevel = true;
        }
    }
}
