﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jauge2 : Jauges
{
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
        Jeu.loseMsg = "Jauge2 pleine";
        Debug.Log("Jauge2 pleine");
    }

    public override void empty()
    {
        Jeu.loseMsg = "Jauge2 vide";
        Debug.Log("Jauge2 vide");
    }
}
