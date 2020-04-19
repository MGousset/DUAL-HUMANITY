using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carte3 : Cartes
{
    public void Start()
    {
        description = "alla wakbar";
        actionLeft = "moitié";
        actionRight = "tout";

        action.text = "";
        descrip.text = description;
    }
    public override void switchRight()
    {
        base.switchRight();
        jauge2.move(30);
        jauge4.move(-110);
    }

    public override void switchLeft()
    {
        base.switchLeft();
        jauge2.move(40);
        jauge4.move(-30);
    }
}

