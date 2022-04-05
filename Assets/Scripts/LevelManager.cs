using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is responsible for managing levels to be loaded.
/// </summary>
public class LevelManager : MonoBehaviour {
    /* Elements */
    private static LevelManager instance;

    [Header("Levels")]
    [SerializeField] private LevelSpecs[] survivalLevels;
    [SerializeField] private LevelSpecs[] reachDestLevels;
    [SerializeField] private LevelSpecs[] combinationLevels;

    private LevelSpecs currentLevel;

    /* Getters/Setters */
    public static LevelManager Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<LevelManager>();
            }

            return instance;
        }

        set {
            instance = value;
        }
    }

    public LevelSpecs CurrentLevel { get => currentLevel; set => currentLevel = value; }
    public LevelSpecs[] SurvivalLevels { get => survivalLevels; set => survivalLevels = value; }
    public LevelSpecs[] ReachDestLevels { get => reachDestLevels; set => reachDestLevels = value; }

    // Start is called before the first frame update
    void Start() {
        if (instance == null) {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);

        // For testing.
        //currentLevel = survivalLevels[0];
    }

    // Update is called once per frame
    void Update() {

    }
}
