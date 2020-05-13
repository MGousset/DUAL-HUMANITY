using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine.SceneManagement;

public class Jeu : MonoBehaviour
{
    public Sprite militairevert;
    public Sprite militairebeige;
    public Sprite banquier;
    public Sprite politicien;
    public Sprite etudiante;
    public Sprite scientifique;
    public Sprite religieux;

    public GameObject game, Win;
    public List<Cartes> cartes;
    public TextMeshProUGUI ansTxt;

    private List<int> indices;
    private Cartes carte;
    private string usedCards;

    private static int XMIN, XMAX;
    private int n, i, ans;
    static float rotaZ;
    private bool running, rotation;
    private static int gros_chgt =40;
    private static int petit_chgt=20;



    public static string loseMsg;
    public static bool win, lose;

    public void Restart()
    {
        PlayerPrefs.SetInt("currentCard", -1);
        PlayerPrefs.SetString("usedCards", "");
        PlayerPrefs.SetInt("ans", 0);
        Jauges.restart();
        Start();
    }

    public void menu()
    {
        //Debug.Log("menu");
        SceneManager.LoadScene(0);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void Start()
    {
        //technologie, population, nature, richesse      
        cartes[1].cartes(0, 0, 0, petit_chgt, 0, -petit_chgt, 0, gros_chgt,
        "Je viens d’avoir un super deal pour pouvoir vendre nos ressources à une planète voisine, combien devrions nous en vendre ??",
        "moitié", "tout", true, banquier);

        cartes[2].cartes(0, -petit_chgt, petit_chgt, petit_chgt, 0, 0, -petit_chgt, -petit_chgt,
        "Arrêtons de manger de la viande dans tous les pays du monde !",
        "oui", "non", true, etudiante);

        cartes[3].cartes(0, 0, 0, +petit_chgt, -petit_chgt, 0, -petit_chgt, -gros_chgt,
        "Nous avons retrouvé les vestiges de la tombe de notre prophète à Mulhouse, nous comptons érigé une jante alluminium géante en son honneur",
        "C'est une très mauvaise idée, contentez vous de prier", "Faites donc, c'est mon prophète après tout", true, religieux);

        cartes[4].cartes(0, gros_chgt, 0, 0, gros_chgt, 0, 0, -petit_chgt,
        "Jon nous rapporte que l’armée verte aurait caché des ogives nucléaires, nous ne savons pas ce qu’ils ont l’intention de faire avec, il faut intervenir !",
        "Evitez tout conflit", "Soit ne vous laissez pas distancer", true, militairevert);

        cartes[5].cartes(petit_chgt, 0, -petit_chgt, 0, gros_chgt, -gros_chgt, 0, -gros_chgt,
        "Le laboratoire du CERN veut simuler un trou noir avec son accélérateur à particule. Cela permettrait de comprendre comment fonctionne l’antimatière",
        "Cessez vos expériences immédiatement", "Je suis curieux de voir le résultat", true, scientifique);
        
        cartes[6].cartes(0, petit_chgt, gros_chgt, -gros_chgt, 0, -petit_chgt, -gros_chgt, gros_chgt,
        "Il y a eu un récent accord entre les banques et le Bresil sur la déforestation en Amazonie, il faut s'interposer !",
        "Cette accord n'a pas lieu d'être", "L'Amazonie est assez grande pour enlever 2-3 arbres", true, etudiante , 0 , 7);
        
        cartes[7].cartes(0, -petit_chgt, -petit_chgt, gros_chgt, 0, 0, petit_chgt, -petit_chgt,
        "On peut le faire de manière durable, cela impactera un peu nos résultat",
        "Au point ou on en est, autant maximiser le profit", "Respectez un peu la nature", true, banquier);

        ans = PlayerPrefs.GetInt("ans");
        ansTxt.text = "An " + ans;

        usedCards = PlayerPrefs.GetString("usedCards");
        int k = PlayerPrefs.GetInt("currentCard");

        XMIN = 30 * 1080 / 100;
        XMAX = 70 * 1080 / 100;
        loseMsg = "";
        win = false;
        lose = false;

        running = true;
        Win.SetActive(false);
        game.SetActive(true);
        n = cartes.Count-1;

        indices = new List<int>();
        for (int i = 0; i < n; ++i)
        {
            indices.Add(i);
        }
        ;
        if (usedCards != "")
        {
            string[] numbersOfUsedCards = Regex.Split(usedCards, ",");
            foreach (string c in numbersOfUsedCards)
            {
                int.TryParse(c, out i);
                //Debug.Log(i);
                indices.Remove(i);
            }
        }
        n = indices.Count;
        //Debug.Log(n);
        foreach (Cartes carte in cartes)
        {
            carte.dos.SetActive(true);
            carte.gameObject.SetActive(false);
            carte.gameObject.transform.SetPositionAndRotation(new Vector2(Screen.width / 2, Screen.height / 2), new Quaternion(0, 1, 0, 0));
        }
        
        //Debug.Log(k);
        if (k != -1)
        {
            chooseCarte(k);
        }
        else
        {
            chooseCarte();
        }
        
    }


    void Update()
    {
        if (rotation) //Si animation en cours
        {
            if (!carte.rotation){ //Detection de fin d'animation pour continuer
                rotation = false;
                if (carte.unique)
                {
                    if (usedCards != "")
                    {
                        usedCards += ",";
                    }

                    usedCards += i.ToString();
                    PlayerPrefs.SetString("usedCards", usedCards);
                }
                indices.Remove(i);
                n -= 1;
                Debug.Log("carte parties");
                if (lose)
                {
                    PlayerPrefs.SetInt("lose", 1);
                    menu();                   
                }
                else if (n <= 1 && loseMsg == "")
                {
                    ans += 10;
                    end(Win, "WIN");
                }
                
                else
                {
                    if (loseMsg != "")
                    {
                        PlayerPrefs.SetInt("currentCard", 0);
                        PlayerPrefs.SetInt("lose", 1);
                        chooseCarte(0);
                        //Debug.Log(loseMsg);
                        carte.descrip.text = loseMsg;
                        //carte.descrip.text = loseMsg;
                    }
                    else
                    {
                        if (carte.suivante == 0)
                        {
                            chooseCarte();
                        }

                        else
                        {
                            chooseCarte(carte.suivante);
                        }
                        ans += 10;
                        PlayerPrefs.SetInt("ans", ans);
                        ansTxt.text = "An " + ans;


                    }
                }
            }
        }
        if (running && !rotation)
        {
            getTactile();
        }
    }

    private void chooseCarte(int k)
    {
        i = k;
        carte = cartes[i];
        carte.retourner();

        //Debug.Log("chosing card");
        //Debug.Log(i);
    }

    private void chooseCarte()
    {
        i = Random.Range(1, n);
        i = indices[i];
        PlayerPrefs.SetInt("currentCard", i);
        chooseCarte(i);
    }

    public void left()
    {
        rotation = true;
        carte.switchLeft();
    }

    public void right()
    {
        rotation = true;
        carte.switchRight();
    }

    public void end(GameObject panel, string txt)
    {
        PlayerPrefs.SetInt("currentCard", -1);
        PlayerPrefs.SetString("usedCards", "");
        //PlayerPrefs.SetInt("annees", 0);
        Jauges.restart();

        game.SetActive(false);
        //messageLose.text = txt;
        panel.SetActive(true);
        running = false;
    }

    private void getTactile()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 posCarte = carte.gameObject.transform.position;
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    break;

                case TouchPhase.Moved:
                     
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
                    carte.gameObject.transform.position = posCarte;
                    carte.gameObject.transform.rotation = Quaternion.Euler(0, 0, (1080 / 2 - posCarte.x) / 40);
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
                        carte.gameObject.transform.SetPositionAndRotation(posCarte, new Quaternion(0, 0, 0, 0));
                    }
                    break;
            }
        }
    }
}

