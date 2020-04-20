using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carte5 : Cartes
{
    public void Start()
    {
        description = "Le laboratoire du CERN veut simuler un trou noir avec son accélérateur à particule. Cela permettrait de comprendre comment fonctionne l’antimatière";
        actionLeft = "Cessez vos expériences immédiatement";
        actionRight = "Je suis curieux de voir le résultat";
        action.text = "";

        descrip.text = description;
    }
    public override void switchRight()
    {
        base.switchRight();
        jauge1.move(-60);
        jauge2.move(-60);
        jauge3.move(-60);
        jauge4.move(+60);
        action.text = "La suisse est aspirée dans le trou noir avant que tout soit contrôlé, ca fonctionne l’anti-matière !!";
    }

    public override void switchLeft()
    {
        base.switchLeft();
        jauge3.move(+30);
        jauge4.move(-30);
    }
}
