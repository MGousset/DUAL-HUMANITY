using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carte2 : Cartes
{
    public void Start()
    {
        description = "Arrêtons de manger de la viande dans tous les pays du monde !";
        actionLeft = "oui";
        actionRight = "non";

        action.text = "";
        descrip.text = description;
    }
    public override void switchRight()
    {
        base.switchRight();
        jauge1.move(-30);
    }

    public override void switchLeft()
    {
        base.switchLeft();
        jauge1.move(30);
        jauge2.move(-30);
        jauge3.move(30);
    }
}
