using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jauges : MonoBehaviour
{
    public static int HEIGHT = 200, YMAX, YMIN, X0;
    public Jeu jeu;
    protected int y;

    // Start is called before the first frame update
    public virtual void Start()
    {
        X0 = Screen.width / 4;
        YMAX = (int)(0);
        YMIN = (int)(- HEIGHT);
        y = (YMAX + YMIN) / 2; 
    }

    public void up(int y)
    {
        Vector2 pos = gameObject.transform.localPosition;
        pos.y += y;
        gameObject.transform.localPosition = pos;
        test();
    }

    public void down(int y)
    {
        Vector2 pos = gameObject.transform.localPosition;
        pos.y -= y;
        gameObject.transform.localPosition = pos;
        test();
    }

    public void test()
    {
        y = (int)gameObject.transform.localPosition.y;
        if (y <= YMIN)
        {
            empty();
        }
        else if (y >= YMAX)
        {
            full();
        }
    }

    public virtual void full()
    {
        Debug.Log("Jauge pleine");
        Jeu.lose = true;
    }

    public virtual void empty()
    {
        Debug.Log("Jauge vide");
        Jeu.lose = true;
    }
}
