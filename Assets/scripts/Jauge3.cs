using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jauge3 : Jauges
{
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
        PlayerPrefs.SetInt("jauge3", PlayerPrefs.GetInt("jauge4") + y);
    }

    public override void full()
    {
        Jeu.loseMsg = "Jauge3 pleine";
        Debug.Log("Jauge3 pleine");
    }

    public override void empty()
    {
        Jeu.loseMsg = "Jauge3 vide";
        Debug.Log("Jauge3 vide");
    }
}
