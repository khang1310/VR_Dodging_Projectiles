using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class loads all the necessary game objects to a scene.
/// </summary>
public class EssentialsLoader : MonoBehaviour {
    /* Elements */
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject levelManager;

    // Start is called before the first frame update
    void Start() {
        if (LevelManager.Instance == null) {
            LevelManager.Instance = Instantiate(levelManager).GetComponent<LevelManager>();
        }

        if (BodyCollider.Instance == null) {
            BodyCollider.Instance = Instantiate(player).GetComponent<BodyCollider>();
            BodyCollider.Instance.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

        if (GameManager.Instance == null) {
            GameManager.Instance = Instantiate(gameManager).GetComponent<GameManager>();
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
