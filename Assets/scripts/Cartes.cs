using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cartes : MonoBehaviour
{
    public TextMeshProUGUI descrip, action;
    public Animator animator;

    public Jauges jauge1, jauge2, jauge3, jauge4;
    public int vX;

    protected string description, actionRight, actionLeft;
    private bool finAnimation;

    public static bool rotation = false;

    IEnumerator Animation(int dir)
    {
        for(int x = 0; x < 1500/vX ; x++)
        {
            Vector3 posCarte = gameObject.transform.position;
            posCarte.x += dir*vX;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, (1080 / 2 - posCarte.x) / 40);
            gameObject.transform.position = posCarte;
            //Debug.Log(posCarte.x);
            yield return null;
        }
        deactiveText();
        animator.SetTrigger("reset");
        animator.ResetTrigger("selected");
        gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        gameObject.SetActive(false);
        rotation = false;
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

    public void deactiveText()
    {
        action.text = "";
    }

    public virtual void retourne()
    {
        Debug.Log("retournerment");
        gameObject.SetActive(true);
        animator.SetTrigger("selected");
        animator.ResetTrigger("reset");
    }

}
