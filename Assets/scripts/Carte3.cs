using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carte3 : Cartes
{
    public void Start()
    {
        description = "Nous avons retrouvé les vestiges de la tombe de notre prophète à Mulhouse, nous comptons érigé une jante alluminium géante en son honneur";
        actionLeft = "C'est une très mauvaise idée, contentez vous de prier";
        actionRight = "Faites donc, c'est mon prophète après tout";

        action.text = "";
        descrip.text = description;
    }
    public override void switchRight()
    {
        base.switchRight();
        jauge1.move(-30);
        jauge3.move(-60);
        jauge4.move(-30);
    }

    public override void switchLeft()
    {
        base.switchLeft();
        jauge3.move(30);
    }
}

