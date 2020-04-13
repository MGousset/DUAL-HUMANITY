using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jauge1 : Jauges
{
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
        Jeu.loseMsg = "Jauge1 pleine";
        Debug.Log("Jauge1 pleine");
    }

    public override void empty()
    {
        Jeu.loseMsg = "Jauge1 pleine";
        Debug.Log("Jauge1 vide");
    }
}
