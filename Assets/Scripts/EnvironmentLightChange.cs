using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentLightChange : MonoBehaviour {
    /* Elements */
    [Range(0.000f, 1.000f)] private float blend = 0f;
    private bool canChangeToNight = false;
    private bool canChangeToDay = false;

    public Material skyboxMaterial;
    public Light lightSource;

    // Start is called before the first frame update
    void Start() {
        skyboxMaterial.SetFloat("_Blend", 0f);
    }

    // Update is called once per frame
    void Update() {
        // Change from day to night.
        if (canChangeToNight) {
            // Slowly change the skybox.
            blend += 0.1f * Time.deltaTime;
            skyboxMaterial.SetFloat("_Blend", blend);

            // Slowly change the light.
            if (lightSource.intensity > 0.4f) {
                lightSource.intensity -= 0.1f * Time.deltaTime;
            }

            if (blend >= 1f) {
                canChangeToNight = false;
            }
        }

        // Change from night to day.
        else if (canChangeToDay) {
            // Slowly change the skybox.
            blend -= 0.1f * Time.deltaTime;
            skyboxMaterial.SetFloat("_Blend", blend);

            // Slowly change the light.
            if (lightSource.intensity < 1f) {
                lightSource.intensity += 0.1f * Time.deltaTime;
            }

            if (blend <= 0f) {
                canChangeToDay = false;
            }
        }
    }

    // Change the light and the color of the skybox upon entering the change zone.
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            if (blend <= 0f) {
                canChangeToNight = true;
                canChangeToDay = false;
            }

            else if (blend >= 1f) {
                canChangeToDay = true;
                canChangeToNight = false;
            }
        }
    }
}
