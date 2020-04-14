using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject planete;
    public GameObject menu, chargement, space;
    public Slider slider;
    public TextMeshProUGUI pourcentageTxt, ansTxt, anneesPasseesTxt, dimensionTxt, clickTxt;
    public Image img;

    private float deltaT;
    private int anneesPassees, ans, dimension;

    public void placePlanete(int x, int y)
    {
        space.transform.localScale = new Vector3(1f, 1f);
        space.transform.position = new Vector2(x, y);
        planete.transform.position = new Vector2(1f * Screen.width / 2, 1f * Screen.height / 2);
        planete.transform.Rotate(0, 0, Random.value * 180);
    }

    IEnumerator texteAnimation()
    {
        dimension += 1;
        for (int i = 1; i <= ans; i++)
        {
            ansTxt.text = " + " + (ans - i).ToString();
            anneesPassees += 1;
            anneesPasseesTxt.text = "An " + anneesPassees.ToString();
            yield return new WaitForSecondsRealtime(0.05f);
        }
        dimensionTxt.text = "Dimension C " + dimension.ToString();

        ansTxt.text = "";
        PlayerPrefs.SetInt("anneesPassees", anneesPassees);
        PlayerPrefs.SetInt("dimension", dimension);
        PlayerPrefs.SetInt("ans", 0);
    }

    IEnumerator sortieDimentionAnimation(int x, int y)
    {
        x = x * Screen.width / 1080;
        y = y * Screen.width / 1080;
        PlayerPrefs.SetInt("xPlanete", x);
        PlayerPrefs.SetInt("yPlanete", y);
        //Debug.Log("zoom");

        Vector2 posSpace = space.transform.position;


        for (int i = 0; i < 150; i++)
        {
            planete.transform.localScale -= new Vector3(1f / 150, 1f / 150);
            yield return null;
        }
        dimensionTxt.gameObject.SetActive(false);
        StartCoroutine(texteAnimation());
        for (int i = 1; i < 100; i++)
        {
            space.transform.localScale += new Vector3(1f * i / 100, 1f * i / 100);
            //Debug.Log(space.transform.position);

            space.transform.Translate((x - Screen.width / 2) * space.transform.localScale.x / 100, (y - Screen.height / 2) * space.transform.localScale.y / 100, 0);

            img.color = new Color(0, 0, 0, 1f * i / 99);
            yield return null;
        }
        placePlanete(x, y);
        StartCoroutine(entreeDimentionAimation(x, y));
    }

    IEnumerator entreeDimentionAimation(int x, int y)
    {
        img.color = new Color(0, 0, 0, 1);

        planete.transform.localScale = new Vector2(0, 0);
        space.transform.localScale = new Vector3(0.3f, 0.3f);

        space.transform.position = new Vector2(Screen.width / 2, Screen.height / 2);
        Vector2 posSpace = space.transform.position;
        yield return null;

        for (int i = 0; i < 150; i++)
        {

            img.color = new Color(0, 0, 0, 1f - 1f*i / 149);
            //Debug.Log(space.transform.localScale);
            planete.transform.localScale += new Vector3(1f/150, 1f/150);
            space.transform.localScale += new Vector3(0.7f / 150, 0.7f/ 150);
            space.transform.Translate((x - posSpace.x) / 150, (y - posSpace.y) / 150, 0);
            yield return null;
        }
        dimensionTxt.gameObject.SetActive(true);
        
        Time.fixedDeltaTime = 0;
        yield return new WaitForSecondsRealtime(0.2f);
        StartCoroutine(wait());
        
    }

    IEnumerator wait()
    {
        Time.fixedDeltaTime = deltaT;
        img.gameObject.SetActive(false);
        while (true)
        {
            clickTxt.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(1f);

            clickTxt.gameObject.SetActive(false);
            yield return new WaitForSecondsRealtime(1f);
        }
    }

        public void Start()
    {
        clickTxt.gameObject.SetActive(false);
        img.gameObject.SetActive(true);
        deltaT = Time.fixedDeltaTime;
        //PlayerPrefs.SetInt("dimension", 0);
        //PlayerPrefs.SetInt("anneesPassees", 0);

        menu.SetActive(false);
        chargement.SetActive(false);
        dimensionTxt.gameObject.SetActive(false);

        placePlanete(PlayerPrefs.GetInt("xPlanete"), PlayerPrefs.GetInt("yPlanete"));

        anneesPassees = PlayerPrefs.GetInt("anneesPassees");
        dimension = PlayerPrefs.GetInt("dimension");
        anneesPasseesTxt.text = "An " + anneesPassees.ToString();
        dimensionTxt.text = "Dimension C " + dimension.ToString();
        ans = PlayerPrefs.GetInt("ans");

        Debug.Log(PlayerPrefs.GetInt("lose"));
        if (PlayerPrefs.GetInt("lose") == 1)
        {
            PlayerPrefs.SetInt("currentCard", -1);
            PlayerPrefs.SetString("usedCards", "");
            Jauges.restart();

            ansTxt.text = " + " + ans.ToString();
            StartCoroutine(sortieDimentionAnimation(Random.Range(-30, 50)*100, Random.Range(-30, 50) * 100));
            Debug.Log("changeDim");
            PlayerPrefs.SetInt("lose", 0);
        }
        else
        {
            Debug.Log("restaureDim");
            StartCoroutine(entreeDimentionAimation(PlayerPrefs.GetInt("xPlanete"), PlayerPrefs.GetInt("yPlanete")));
        }
    }

    private void Update()
    {
        planete.transform.Rotate(0, 0, Time.fixedUnscaledDeltaTime*180/60);
    }

    public void continuer()
    {
        StopCoroutine(wait());
        Time.fixedDeltaTime = deltaT;
        img.gameObject.SetActive(true);
        //menu.SetActive(false);
        clickTxt.gameObject.SetActive(false);
        anneesPasseesTxt.text = "";
        dimensionTxt.text = "";
        StartCoroutine(loading());
    }

    public void newGame()
    {
        continuer();
    }

    IEnumerator loading()
    {
        for (int i = 1; i < 100; i++)
        {
            space.transform.localScale += new Vector3(1f * i / 10, 1f * i / 10);
            planete.transform.position = new Vector2(1f * Screen.width / 2, 1f * Screen.height / 2);
            img.color = new Color(0, 0, 0, 1f * i / 99);
            yield return null;
        }
        chargement.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress/0.9f);
            slider.value = progress;
            pourcentageTxt.text = progress.ToString() + "%";
            yield return null;
        }
    }
}
