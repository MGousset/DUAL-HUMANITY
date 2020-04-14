using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cartes : MonoBehaviour
{
    public TextMeshProUGUI descrip, action;

    public Jauges jauge1, jauge2, jauge3, jauge4;
    public GameObject dos;

    protected string description, actionRight, actionLeft;
    private bool finAnimation;

    public bool rotation = false;
    public bool unique = true;

    IEnumerator switchAnimation(int dir)
    {
        desactiveText();
        Vector3 posCarte = gameObject.transform.position;
        int l = Screen.width;
        while (-l/2 < posCarte.x && posCarte.x < 3*l/2)
        {
            posCarte.x += 2500*dir* Time.fixedDeltaTime;

            gameObject.transform.position = posCarte;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, (1080/2 - posCarte.x) / 40);
            yield return null;
        }
        gameObject.SetActive(false);
        rotation = false;
        yield return null;
    }

    public virtual void switchRight()
    {
        rotation = true;
        StartCoroutine(switchAnimation(1));
    }

    public virtual void switchLeft()
    {
        rotation = true;
        StartCoroutine(switchAnimation(-1));
    }


    IEnumerator returnAnimation()
    {
        //Debug.Log("retournement");
        for (int i= 180; i >= 0; i -= 5)
        {
            //Debug.Log(Time.deltaTime);
            gameObject.transform.rotation = Quaternion.Euler(0, i, 0);

            if (gameObject.transform.rotation.y < 0.725)
            {
                dos.SetActive(false);
            }
            yield return null;
        }
        gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        yield return null;
    }

    public void retourner()
    {
        gameObject.SetActive(true);
        StartCoroutine(returnAnimation());
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
