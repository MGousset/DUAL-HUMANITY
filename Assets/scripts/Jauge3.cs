using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jauge3 : Jauges
{
    public Sprite tropNature;
    public Sprite pasNature;
    
    public override void Start()
    {
        base.Start();
        gameObject.transform.localPosition = new Vector2(0, y + PlayerPrefs.GetInt("jauge3"));
        float yGen = gameObject.transform.position.y;
        gameObject.transform.position = new Vector2(5f / 2 * X0, yGen);
    }

    public override void move(int y)
    {
        base.move(y);
        PlayerPrefs.SetInt("jauge3", PlayerPrefs.GetInt("jauge3") + y);
    }

    public override void full()
    {
        Jeu.imageFin = tropNature;
        Jeu.loseMsg = "La nature a repris ses droits partout sur terre, les hommes se sont vu dépassés par les animaux qui ont pris le contrôle des villes et obligé les hommes à vivre reclus";
        Debug.Log("Jauge3 pleine");
    }

    public override void empty()
    {
        Jeu.imageFin = pasNature;
        Jeu.loseMsg = "L'homme a du quitter la planète car elle était devenue trop polluée pour être cultivée";
        Debug.Log("Jauge3 vide");
    }
}
