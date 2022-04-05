using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles the collisions of the player's body.
/// </summary>
public class BodyCollider : MonoBehaviour {
    /* Elements */
    private static BodyCollider instance;

    [SerializeField] private Transform cameraHead;

    /* Getters/Setters */
    public Transform Camera { get => cameraHead; set => cameraHead = value; }

    public static BodyCollider Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<BodyCollider>();
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
    /// If a projectile hits the player, his lives will reduce by 1.
    /// </summary>
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Projectile") {
            if (StatsHandler.Instance.CurrentLives > 0) {
                StatsHandler.Instance.CurrentLives -= 1;
            }
        }
    }
}
