using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cartes : MonoBehaviour
{
    public TextMeshProUGUI descrip, action;
    public Animator animator;

    public Jauges jauge1, jauge2, jauge3, jauge4;
    public GameObject dos;
    public int vX;

    protected string description, actionRight, actionLeft;
    private bool finAnimation;

    public static bool rotation = false;

    IEnumerator Animation(int dir)
    {
        desactiveText();
        for (int x = 0; x < 1500/vX ; x++)
        {
            Vector3 posCarte = gameObject.transform.position;
            posCarte.x += dir*vX;
            gameObject.transform.position = posCarte;
            gameObject.transform.Rotate(0, 0, dir*vX / 40);
            //Debug.Log(posCarte.x);
            yield return null;
        }
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        rotation = false;
        gameObject.SetActive(false);
        yield return null;
    }

    public virtual void switchRight()
    {
        rotation = true;
        StartCoroutine(Animation(1));
    }

    public virtual void switchLeft()
    {
        rotation = true;
        StartCoroutine(Animation(-1));
    }

    public void activeTextRight()
    {
        action.text = actionRight;
        action.alignment = TextAlignmentOptions.Left;
        action.transform.rotation = Quaternion.Euler(0, 0, 0);
        action.transform.position = new Vector2(540, 860);
    }

    public void activeTextLeft()
    {
        action.text = actionLeft;
        action.alignment = TextAlignmentOptions.Right;
        action.transform.rotation = Quaternion.Euler(0, 0, 0);
        action.transform.position = new Vector2(540, 860);
    }

    public void desactiveText()
    {
        action.text = "";
    }

}
