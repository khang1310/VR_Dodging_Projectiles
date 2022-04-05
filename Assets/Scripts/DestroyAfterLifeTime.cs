using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destroy an object after an amount of time (its life time).
/// </summary>
public class DestroyAfterLifeTime : MonoBehaviour {
    /* Elements */
    [SerializeField] private float lifeTime = 5f;

    /* Getters/Setters */
    public float LifeTime { get => lifeTime; set => lifeTime = value; }

    // Start is called before the first frame update
    void Start() {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update() {

    }
}
