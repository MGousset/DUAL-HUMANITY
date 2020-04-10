using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jauge3 : Jauges
{
    public override void Start()
    {
        base.Start();
        gameObject.transform.localPosition = new Vector2(0, y);
        float yGen = gameObject.transform.position.y;
        gameObject.transform.position = new Vector2(5f / 2 * X0, yGen);
    }

    public override void full()
    {
        base.empty();
        Debug.Log("Jauge3 pleine");
    }

    public override void empty()
    {
        base.empty();
        Debug.Log("Jauge3 vide");
    }
}
