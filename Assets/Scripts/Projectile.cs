using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for making a projectile move.
/// </summary>
public class Projectile : MonoBehaviour {
    /* Elements */
    private float speed;

    // Acceleration factors
    private bool canAccelerate;
    private float acceleration = 1f;
    private float accelerationCo;

    private Transform shootPoint;

    /* Getters/Setters */
    public float Speed { get => speed; set => speed = value; }
    public bool CanAccelerate { get => canAccelerate; set => canAccelerate = value; }
    public float Acceleration { get => acceleration; set => acceleration = value; }
    public float AccelerationCo { get => accelerationCo; set => accelerationCo = value; }
    public Transform ShootPoint { get => shootPoint; set => shootPoint = value; }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        GetComponent<Rigidbody>().velocity = (-1.0f) * shootPoint.right * speed * acceleration * Time.deltaTime;

        // If the projectile is allowed to accelerate, increase the acceleration.
        if (canAccelerate == true) {
            acceleration += accelerationCo;
        }

        // Destroy all the projectiles when the game ends.
        if (GameManager.Instance.PlayerWin || GameManager.Instance.PlayerLose) {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Destroy the projectile on collisions.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Object") {
            Destroy(gameObject);
        }
    }
}
