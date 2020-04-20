using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carte4 : Cartes
{
    public void Start()
    {
        description = "On nous rapporte que l’armée verte aurait caché des ogives nucléaires, nous ne savons pas ce qu’ils ont l’intention de faire avec, il faut intervenir !";
        actionLeft = "Evitez tout conflit";
        actionRight = "Soit ne vous laissez pas distancer";

        action.text = "";
        descrip.text = description;
    }
    public override void switchRight()
    {
        base.switchRight();
        jauge1.move(-30);
        jauge2.move(-60);
    }

    public override void switchLeft()
    {
        base.switchLeft();
        jauge2.move(+60);
    }
}
