using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jauges : MonoBehaviour
{
    static public int HEIGHT = 200, YMAX, YMIN, X0;
    public Jeu jeu;
    protected int y;
    public Image img;
    // Start is called before the first frame update

    public static void restart()
    {
        PlayerPrefs.SetInt("jauge1", 0);
        PlayerPrefs.SetInt("jauge2", 0);
        PlayerPrefs.SetInt("jauge3", 0);
        PlayerPrefs.SetInt("jauge4", 0);
    }

    public virtual void Start()
    {
        X0 = Screen.width / 4;
        YMAX = -13;
        YMIN = - 187;
        y = (YMAX + YMIN) / 2;
        img.color = new Color(1, 1, 1, 0);
    }

    IEnumerator clignotementAnimation(bool up)
    {
        //Debug.Log("clignotement");
        if (up)
        {
            img.color = new Color(0, 1, 0, 1);
        }
        else
        {
            img.color = new Color(1, 0, 0, 1);
            
        }
        yield return new WaitForSecondsRealtime(0.1f);

        img.color = new Color(1, 1, 1, 1);
        yield return new WaitForSecondsRealtime(0.1f);

        if (up)
        {
            img.color = new Color(0, 1, 0, 1);
        }
        else
        {
            img.color = new Color(1, 0, 0, 1);

        }
        yield return new WaitForSecondsRealtime(0.1f);

        img.color = new Color(1, 1, 1, 1);
        yield return new WaitForSecondsRealtime(0.1f);

        img.color = new Color(1, 1, 1, 0);
        yield return null;
    }

    public virtual void move(int y)
    {
        Vector2 pos = gameObject.transform.localPosition;
        pos.y += y;
        gameObject.transform.localPosition = pos;
        if (y != 0)
        {
            StartCoroutine(clignotementAnimation(y > 0));
        }
        test();
    }

    public void test()
    {
        Vector2 pos = gameObject.transform.localPosition;
        if (pos.y <= YMIN)
        {
            pos.y = YMIN;
            gameObject.transform.localPosition = pos;
            empty();
        }
        else if (pos.y >= YMAX)
        {
            pos.y = YMAX;
            gameObject.transform.localPosition = pos;
            full();
        }
    }

    public virtual void full()
    {
    }

    public virtual void empty()
    {
    }
}
