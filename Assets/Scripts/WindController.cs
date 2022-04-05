using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour {
    /* Elements */
    [SerializeField] private bool enableWind;
    private bool canChangeWind = false;

    private Terrain terrain;

    public WindZone windZone;
    public AudioSource windSound;

    // Start is called before the first frame update
    void Start() {
        terrain = FindObjectOfType<Terrain>();

        terrain.terrainData.wavingGrassSpeed = 0.5f;
        terrain.terrainData.wavingGrassAmount = 0.5f;
        terrain.terrainData.wavingGrassStrength = 0.5f;
    }

    // Update is called once per frame
    void Update() {
        if (canChangeWind) {
            // If want to enable wind, set all the values to appropriate values.
            if (enableWind) {
                if (windZone.windMain < 2f) {
                    windZone.windMain += 0.2f * Time.deltaTime;
                }

                if (windZone.windTurbulence < 0.7f) {
                    windZone.windTurbulence += 0.1f * Time.deltaTime;
                }

                if (windZone.windPulseMagnitude < 0.5f) {
                    windZone.windPulseMagnitude += 0.1f * Time.deltaTime;
                }

                if (windZone.windPulseFrequency < 0.01f) {
                    windZone.windPulseFrequency += 0.002f * Time.deltaTime;
                }

                // Change the wind settings of the terrain.
                if (terrain.terrainData.wavingGrassSpeed < 0.5f) {
                    terrain.terrainData.wavingGrassSpeed += 0.07f * Time.deltaTime;
                }

                if (terrain.terrainData.wavingGrassAmount < 0.5f) {
                    terrain.terrainData.wavingGrassAmount += 0.07f * Time.deltaTime;
                }

                if (terrain.terrainData.wavingGrassStrength < 0.5f) {
                    terrain.terrainData.wavingGrassStrength += 0.07f * Time.deltaTime;
                }

                // Increase the wind sound.
                if (windSound.volume < 0.8f) {
                    windSound.volume += 0.1f * Time.deltaTime;
                }

                // Stop the changing process.
                if (windZone.windMain >= 2f && windZone.windTurbulence >= 0.7f && windZone.windPulseMagnitude >= 0.5f
                    && windZone.windPulseFrequency >= 0.01f && windSound.volume >= 0.8f && terrain.terrainData.wavingGrassSpeed >= 0.5f
                    && terrain.terrainData.wavingGrassAmount >= 0.5f && terrain.terrainData.wavingGrassStrength >= 0.5f) {

                    canChangeWind = false;
                }
            }

            // If want to disable wind, set all the values to 0.
            else {
                if (windZone.windMain > 0f) {
                    windZone.windMain -= 0.2f * Time.deltaTime;
                }

                if (windZone.windTurbulence > 0f) {
                    windZone.windTurbulence -= 0.1f * Time.deltaTime;
                }

                if (windZone.windPulseMagnitude > 0f) {
                    windZone.windPulseMagnitude -= 0.1f * Time.deltaTime;
                }

                if (windZone.windPulseFrequency > 0f) {
                    windZone.windPulseFrequency -= 0.002f * Time.deltaTime;
                }

                // Change the wind settings of the terrain.
                if (terrain.terrainData.wavingGrassSpeed > 0f) {
                    terrain.terrainData.wavingGrassSpeed -= 0.07f * Time.deltaTime;
                }

                if (terrain.terrainData.wavingGrassAmount > 0f) {
                    terrain.terrainData.wavingGrassAmount -= 0.07f * Time.deltaTime;
                }

                if (terrain.terrainData.wavingGrassStrength > 0f) {
                    terrain.terrainData.wavingGrassStrength -= 0.07f * Time.deltaTime;
                }

                // Decrease the wind sound.
                if (windSound.volume > 0f) {
                    windSound.volume -= 0.1f * Time.deltaTime;
                }

                // Stop the changing process.
                if (windZone.windMain <= 0f && windZone.windTurbulence <= 0f && windZone.windPulseMagnitude <= 0f
                    && windZone.windPulseFrequency <= 0f && windSound.volume <= 0f && terrain.terrainData.wavingGrassSpeed <= 0f
                    && terrain.terrainData.wavingGrassAmount <= 0f && terrain.terrainData.wavingGrassStrength <= 0f) {

                    canChangeWind = false;
                }
            }
        }
    }

    // Change the wind condition upon entering the zone.
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            canChangeWind = true;
        }
    }
}
