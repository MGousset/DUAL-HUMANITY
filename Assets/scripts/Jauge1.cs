using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jauge1 : Jauges
{
    public Sprite tropTechno;
    public Sprite pasTechno;
    
    public override void Start()
    {

        base.Start();
        gameObject.transform.localPosition = new Vector2(0, y + PlayerPrefs.GetInt("jauge1"));
        float yGen = gameObject.transform.position.y;
        gameObject.transform.position = new Vector2(1f / 2 * X0, yGen);
    }

    public override void move(int y)
    {
        base.move(y);
        PlayerPrefs.SetInt("jauge1", PlayerPrefs.GetInt("jauge1") + y);
    }

    public override void full()
    {
        Jeu.imageFin = tropTechno;
        Jeu.loseMsg = "L'intelligence artificielle a pris conscience de son état de servant de l'humanité et s'est soulevé contre elle avant de la réduire en esclavage";
        Debug.Log("Jauge1 pleine");
    }

    public override void empty()
    {
        Jeu.imageFin = pasTechno;
        Jeu.loseMsg = "La science ayant été trop délaissée au profit du reste, l'humanité a commencé à régresser et sans s'en rendre compte est retournée à l'âge de pierre";
        Debug.Log("Jauge1 vide");
    }
}
