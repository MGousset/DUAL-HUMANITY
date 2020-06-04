using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jauge4 : Jauges
{
    public Sprite tropSous;
    public Sprite pasSous;

    public override void Start()
    {
        base.Start();
        gameObject.transform.localPosition = new Vector2(0, y + PlayerPrefs.GetInt("jauge4"));
        float yGen = gameObject.transform.position.y;
        gameObject.transform.position = new Vector2(7f / 2 * X0, yGen);
    }

    public override void move(int y)
    {
        base.move(y);
        PlayerPrefs.SetInt("jauge4", PlayerPrefs.GetInt("jauge4") + y);
    }

    public override void full()
    {
        Jeu.imageFin = tropSous;
        Jeu.loseMsg = "L'hypercapitalisme a creusé les inégalités à un point tel qu'on soulèvement populaire a détruit quasiment toute forme de civilisation";
        Debug.Log("Jauge4 pleine");
    }

    public override void empty()
    {
        Jeu.imageFin = pasSous;
        Jeu.loseMsg = "Le manque d'argent a forcé les pays à s'attaquer pour se disputer les ressources essentielles entrainant le déclin de l'humanité";
        Debug.Log("Jauge4 vide");
    }
}
