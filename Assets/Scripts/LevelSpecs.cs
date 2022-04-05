using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class stores the information about a certain level.
/// </summary>
[System.Serializable]
public class LevelSpecs {
    /* Elements */
    public bool isSurvival;
    public bool isReachingDestination;
    public float timeToWin;
    public int maxLives;
}
