﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScreenFader : MonoBehaviour {

    public Image FadeImg;
    public float fadeSpeed = 1.5f;

    public float minAlpha = 0.05f;
    public float maxAlpha = 0.90f;

    public float FADEIN_TIMER = -5f;
    public float START_TIMER = 15f;
    public float timer = 5.0f;
    public bool isFading = false;

    public GameObject[] bixos;

    void Awake() {
        FadeImg.rectTransform.localScale = new Vector2(
            Screen.width,
            Screen.height
        );
    }

    void Update() {

        timer -= Time.deltaTime;
        if ((timer <= 0) && !isFading){

            FadeImg.gameObject.SetActive(true);
            isFading = true;

            // start fade
            StartCoroutine("FadeRoutine");

            SpawnBixo();
        }

        if ((timer <= -1.3f) && isFading){

            // start fade
            StartFadeOut();
        }
    }

    void SpawnBixo() {
        SpawnPoint[] spawnPoints =
            FindObjectsOfType(typeof(SpawnPoint)) as SpawnPoint[];

        if (spawnPoints.Length > 0){
            Random rnd = new Random();
            int i = (int) (Random.value * (spawnPoints.Length-1));
            SpawnPoint spawner = spawnPoints[i];
            spawner.SpawnRandomBixo();
        }
    }

    void FadeOut() {
        FadeImg.color = Color.Lerp(
            FadeImg.color,
            Color.clear,
            fadeSpeed*Time.deltaTime
        );
    }


    void FadeIn() {
        FadeImg.color = Color.Lerp(
            FadeImg.color,
            Color.black,
            fadeSpeed*Time.deltaTime
        );
    }


    void StartFadeOut() {
        
        // Fade the texture to clear
        FadeOut();
        
        if (FadeImg.color.a <= minAlpha) {
            FadeImg.color = Color.clear;
            FadeImg.enabled = false;

            isFading = false;
            timer = START_TIMER - Random.Range(0f, 3f);
        }
    }


    public IEnumerator FadeRoutine() {
        
        // Make sure the image is enabled
        FadeImg.enabled = true;

        do {
            // Start fading in
            FadeIn();

            // Let some alpha 
            if (FadeImg.color.a >= maxAlpha) {
                yield break;

            } else yield return null;

        } while (true);
    }
}
