using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarteFin : Cartes
{
    public Jeu jeu;

    public override void Start()
    {
        base.Start();
        actionLeft = "";
        actionRight = "";

        action.text = "";
    }

    public override void cartes(int j1l, int j2l, int j3l, int j4l, int j1r, int j2r, int j3r, int j4r,
        string desc, string aLeft, string aRight, bool u, Sprite perso)
    {
        Debug.Log("oui");
        base.cartes(j1l, j2l, j3l, j4l, j1r, j2r, j3r, j4r,
        desc, aLeft, aRight, u, perso);
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
