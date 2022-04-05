using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemSwitch : MonoBehaviour {
    /* Elements */
    [SerializeField] private bool enableParticleEmitters;
    [SerializeField] private ParticleSystem[] particleEmitters;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    // Play/Stop the particle emitters when the player enters.
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            // Play the particle system if want to enable particle emitters.
            if (enableParticleEmitters) {
                for (int i = 0; i < particleEmitters.Length; i++) {
                    ParticleSystem.EmissionModule emitter = particleEmitters[i].emission;

                    if (!emitter.enabled) {
                        emitter.enabled = true;
                    }
                }
            }

            // Pause the particle system if want to disable particle emitters.
            else {
                for (int i = 0; i < particleEmitters.Length; i++) {
                    ParticleSystem.EmissionModule emitter = particleEmitters[i].emission;

                    if (emitter.enabled) {
                        emitter.enabled = false;
                    }
                }
            }
        }
    }
}
