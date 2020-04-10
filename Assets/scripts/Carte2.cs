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
        jauge4.up(60);
        jauge2.down(50);
    }

    public override void switchLeft()
    {
        base.switchLeft();
        jauge2.up(50);
        jauge4.down(60);
    }
}
