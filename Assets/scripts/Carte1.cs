using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carte1 : Cartes
{
    public void Start()
    {
        description = "je viens d’avoir un super deal pour pouvoir vendre nos ressources à une planète voisine, combien devrions nous en vendre ??";
        actionLeft = "moitié";
        actionRight = "tout";
        
        action.text = "";
        descrip.text = description;
    }
    public override void switchRight()
    {
        base.switchRight();
        jauge1.move(30);
        jauge3.move(-40);
    }

    public override void switchLeft()
    {
        base.switchLeft();
        jauge3.move(40);
        jauge1.move(-30);
    }
}


