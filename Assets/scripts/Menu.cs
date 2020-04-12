using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject menu, chargement;
    public Slider slider;
    public TextMeshProUGUI text;

    public void Start()
    {
        menu.SetActive(true);
        chargement.SetActive(false);
    }

    public void continuer()
    {
        menu.SetActive(false);
        chargement.SetActive(true);
        StartCoroutine(loading());
    }

    public void newGame()
    {
        PlayerPrefs.SetInt("currentCard", -1);
        PlayerPrefs.SetString("usedCards", "");
        PlayerPrefs.SetInt("annees", 0);
        Jauges.restart();
        continuer();
    }

    IEnumerator loading()
    {
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress/0.9f);
            slider.value = progress;
            text.text = progress.ToString() + "%";
            yield return null;
        }
    }
}
