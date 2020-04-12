using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jauge4 : Jauges
{
    public override void Start()
    {
        base.Start();
        gameObject.transform.localPosition = new Vector2(0, y + PlayerPrefs.GetInt("jauge4"));
        float yGen = gameObject.transform.position.y;
        gameObject.transform.position = new Vector2(7f / 2 * X0, yGen);
    }

    public override void move(int y)
    {
        base.move(y);
        PlayerPrefs.SetInt("jauge4", PlayerPrefs.GetInt("jauge4") + y);
    }

    public override void full()
    {
        base.empty();
        Debug.Log("Jauge4 pleine");
    }

    public override void empty()
    {
        base.empty();
        Debug.Log("Jauge4 vide");
    }
}
