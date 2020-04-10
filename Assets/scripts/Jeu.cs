using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using TMPro;

public class Jeu : MonoBehaviour
{
    public GameObject game, Win, Lose;
    public List<Cartes> cartes;
    public TextMeshProUGUI messageWin, messageLose, messageAnnees;
    private List<int> indices = new List<int>();
    private Cartes carte;
    
    private static int XMIN, XMAX;
    private int n, i, ans;
    
    private bool running, rotation;

    public static bool lose, win;

    public void Start()
    {
        XMIN = 30 * 1080 / 100;
        XMAX = 70 * 1080 / 100;
        ans = 0;
        win = false;
        lose = false;

        running = true;
        Win.SetActive(false);
        Lose.SetActive(false);
        game.SetActive(true);

        n = cartes.Count;
        for (int i = 0; i < n; ++i)
        {
            indices.Add(i);
        }
        
        foreach (Cartes carte in cartes)
        {
            carte.gameObject.SetActive(false);
            Vector2 posCarte = carte.gameObject.transform.position;
            posCarte.x = Screen.width / 2;
            carte.gameObject.transform.position = posCarte;
            //carte.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        chooseCarte();
        /*
        string str = "";
        str += 1.ToString();
        PlayerPrefs.SetString("codeCarte", str);
        string txt = PlayerPrefs.GetString("codeCarte");
        Debug.Log(txt);
        string[] numbers = Regex.Split(txt," ");
        foreach (string c in numbers)
        {
            int i;
            int.TryParse(c, out i);
            Debug.Log(i);
            cartes[i].gameObject.SetActive(true);
        }
        */
    }

    void Update()
    {
        if (rotation)
        {
            if (!Cartes.rotation){
                rotation = false;
                Debug.Log("carte parties");
                if (!lose && !win)
                {
                    chooseCarte();
                }
                else if (lose)
                {
                    end();
                }
                else if (win)
                {
                    victory();
                }
            }
        }
        if (running && !rotation)
        {
            getTactile();
        }
    }


    private void chooseCarte()
    {
        i = Random.Range(0, n);
        i = indices[i];

        carte = cartes[i];
        carte.gameObject.SetActive(true);

        ans += 10;
        messageAnnees.text = "An " + ans;
    }

    public void left()
    {
        rotation = true;
        carte.switchLeft();
        indices.Remove(i);
        n -= 1;

        if (n <= 0)
        {
            win = true;
        }
    }

    public void right()
    {
        rotation = true;
        carte.switchRight();
        indices.Remove(i);
        n -= 1;

        if (n <= 0)
        {
            win = true;
        }
    }

    public void end()
    {
        Debug.Log("LOSE");
        game.SetActive(false);
        messageLose.text = "Tu as tenu " + ans + " annnées";
        Lose.SetActive(true);
        running = false;
    }

    public void victory()
    {
        ans += 10;
        Debug.Log("WIN");
        game.SetActive(false);
        messageWin.text = "Tu as tenu " + ans + " annnées";
        Win.SetActive(true);
        running = false;
    }

    private void getTactile()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 posCarte;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    break;

                case TouchPhase.Moved:
                    posCarte = carte.gameObject.transform.position;
                    posCarte.x += touch.deltaPosition.x;

                    if (posCarte.x <= XMIN)
                    {
                        carte.activeTextLeft();
                    }

                    else if (posCarte.x >= XMAX)
                    {
                        carte.activeTextRight();
                    }

                    else
                    {
                        carte.desactiveText();
                    }

                    carte.gameObject.transform.rotation = Quaternion.Euler(0, 0, (1080 / 2 - posCarte.x) / 40);
                    carte.gameObject.transform.position = posCarte;
                    break;

                case TouchPhase.Ended:
                    posCarte = carte.gameObject.transform.position;
                    if (posCarte.x <= XMIN)
                    {
                        left();
                    }
                    else if (posCarte.x >= XMAX)
                    {
                        right();
                    }
                    else
                    {
                        posCarte.x = 1080 / 2;
                        carte.gameObject.transform.position = posCarte;
                        carte.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    break;
            }
        }
    }
}

