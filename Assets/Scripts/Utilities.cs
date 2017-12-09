﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Utilities : MonoBehaviour {


    public IEnumerator FadeOut(GameObject screen, float fadeDelay=0.8f, float alphaMax=1.0f)
    {
        if (alphaMax > 1) alphaMax = 1;
        if (alphaMax < 0) alphaMax = 0;

        Color c = screen.GetComponent<Image>().color;
        c.a = alphaMax;
        screen.GetComponent<Image>().color = c;

        screen.gameObject.SetActive(true);

        float time = 0;

        while (time < fadeDelay)
        {
            c.a = Mathf.Lerp(alphaMax, 0f, time / fadeDelay);

            screen.GetComponent<Image>().color = c;
            yield return null;
            time += Time.deltaTime;
        }
        screen.gameObject.SetActive(false);
    }

    public IEnumerator FadeIn(GameObject screen, string scene ,float fadeDelay=0.8f, float alphaMax=1.0f)
    {
        if (alphaMax > 1) alphaMax = 1;
        if (alphaMax < 0) alphaMax = 0;

        Color c = screen.GetComponent<Image>().color;
        c.a = 0;
        screen.GetComponent<Image>().color = c;

        screen.gameObject.SetActive(true);

        float time = 0;

        while (time < fadeDelay)
        {
            c.a = Mathf.Lerp(0f, alphaMax, time / fadeDelay);

            screen.GetComponent<Image>().color = c;
            yield return null;
            time += Time.deltaTime;
        }
        SceneManager.LoadScene(scene);
    }
}
