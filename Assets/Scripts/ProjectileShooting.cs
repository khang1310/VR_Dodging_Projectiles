using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 
/// This class is responsible for handling projectile shooting with a certain pattern.
/// </summary>
public class ProjectileShooting : MonoBehaviour {
    /* Elements */
    [SerializeField] private GameObject projectile;
    [SerializeField] private float speed;
    [SerializeField] private float waitingTime = 3f;

    // Acceleration factors of projectiles, cooperating with other patterns.
    [Header("Acceleration Factors")]
    [SerializeField] private bool canAccelerate;
    [SerializeField] private float accelerationCo;

    [Header("Shooting Patterns")]
    [SerializeField] private bool isRegularPattern;
    [SerializeField] private bool isDoubleProjectilesPattern;
    [SerializeField] private bool isOneTwoPattern;

    /* Getters/Setters */
    public bool IsRegularPattern { get => isRegularPattern; set => isRegularPattern = value; }
    public bool IsDoubleProjectilesPattern { get => isDoubleProjectilesPattern; set => isDoubleProjectilesPattern = value; }

    public bool CanAccelerate { get => canAccelerate; set => canAccelerate = value; }
    public float Acceleration { get => accelerationCo; set => accelerationCo = value; }
    public float Acceleration1 { get => accelerationCo; set => accelerationCo = value; }
    public float Speed { get => speed; set => speed = value; }
    public bool IsOneTwoPattern { get => isOneTwoPattern; set => isOneTwoPattern = value; }
    public float WaitingTime { get => waitingTime; set => waitingTime = value; }

    // Start is called before the first frame update
    void Start() {
        /* Shoot projectiles with a specific pattern. */
        if (isRegularPattern) {
            StartCoroutine(RegularShootingPattern());
        }

        else if (isDoubleProjectilesPattern) {
            StartCoroutine(DoubleShootingPattern());
        }

        else if (isOneTwoPattern) {
            StartCoroutine(OneTwoShootingPattern());
        }
    }

    // Update is called once per frame
    void Update() {
        // Stop shooting projectiles when the game ends.
        if (GameManager.Instance.PlayerWin || GameManager.Instance.PlayerLose) {
            StopAllCoroutines();
        }
    }

    /// <summary>
    /// Shoot a projectile repeatedly.
    /// </summary>
    public IEnumerator RegularShootingPattern() {
        while (true) {
            yield return new WaitForSeconds(waitingTime);
            ShootProjectile();
        }
    }

    /// <summary>
    /// Shoot projectiles in double-projectiles pattern. A projectile will follow the first one 
    /// after 0.5 seconds.
    /// </summary>
    public IEnumerator DoubleShootingPattern() {
        float nextProjectileTime = 0.5f;

        while (true) {
            yield return new WaitForSeconds(waitingTime);
            ShootProjectile();

            yield return new WaitForSeconds(nextProjectileTime);
            ShootProjectile();
        }
    }

    /// <summary>
    /// Shoot one projectile first, then two more projectiles will follow after 1 second. The third
    /// projectile follows the second one after 0.3 seconds.
    /// </summary>
    public IEnumerator OneTwoShootingPattern() {
        float nextTwoProjectilesTime = 1f;
        float twoProjectileTime = 0.3f;

        while (true) {
            yield return new WaitForSeconds(waitingTime);
            ShootProjectile();

            yield return new WaitForSeconds(nextTwoProjectilesTime);
            ShootProjectile();
            yield return new WaitForSeconds(twoProjectileTime);
            ShootProjectile();
        }
    }

    /// <summary>
    /// Shoot a projectile in a certain direction.
    /// </summary>
    public void ShootProjectile() {
        GameObject clone = Instantiate(projectile, transform.position, transform.rotation);
        clone.GetComponent<Projectile>().ShootPoint = transform;

        // Set the speed of the projectiles.
        if (speed > 0) {
            clone.GetComponent<Projectile>().Speed = speed;
        }

        // Applies acceleration if there is one.
        if (canAccelerate) {
            clone.GetComponent<Projectile>().CanAccelerate = true;
            clone.GetComponent<Projectile>().AccelerationCo = accelerationCo;
        }

        // Play the SFX.
        GetComponent<AudioSource>().Play();
    }
}
