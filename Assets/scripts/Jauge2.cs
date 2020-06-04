using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jauge2 : Jauges
{

    public Sprite tropPop;
    public Sprite pasPop;
    
    public override void Start()
    {
        base.Start();
        gameObject.transform.localPosition = new Vector2(0, y + PlayerPrefs.GetInt("jauge2"));
        float yGen = gameObject.transform.position.y;
        gameObject.transform.position = new Vector2(3f / 2 * X0, yGen);
    }

    public override void move(int y)
    {
        base.move(y);
        PlayerPrefs.SetInt("jauge2", PlayerPrefs.GetInt("jauge2") + y);
    }

    public override void full()
    {
        Jeu.loseMsg = "La terre est devenue trop peuplée, une famine globale sans précédent mis fin à la société en place";
        Jeu.imageFin = tropPop;
        Debug.Log("Jauge2 pleine");
    }

    public override void empty()
    {
        Jeu.imageFin = pasPop;
                Jeu.loseMsg = "Tout le monde est mort";
        Debug.Log("Jauge2 vide");
    }
}
