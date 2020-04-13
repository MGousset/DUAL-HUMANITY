using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarteFin : Cartes
{
    public Jeu jeu;

    public void Start()
    {
        actionLeft = "";
        actionRight = "";

        action.text = "";
    }
    public override void switchRight()
    {
        Jeu.lose = true;
    }

    public override void switchLeft()
    {
        Jeu.lose = true;
    }
}
