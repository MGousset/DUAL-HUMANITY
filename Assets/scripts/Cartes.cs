using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Cartes : MonoBehaviour
{
    public TextMeshProUGUI descrip, action;

    public Jauges jauge1, jauge2, jauge3, jauge4;
    public GameObject dos;
    public Image personnage;
    public bool rotation = false;
    public bool unique = true;

    protected string description, actionRight, actionLeft;
    private bool finAnimation;
    private int jauge1left, jauge2left, jauge3left, jauge4left,
        jauge1right, jauge2right, jauge3right, jauge4right;

    public virtual void Start()
    {
        Vector2 scal = personnage.transform.localScale;
        scal.y *= (Screen.height * 1440f) / (2960f * Screen.width);
        descrip.transform.Translate(0, (1 - scal.y) * 340f, 0);
        if (scal.y < 0.87)
        {
            scal.y = 0.835f;
        }
        personnage.transform.localScale = scal;
        descrip.transform.localScale = scal;

    }

    public virtual void cartes(int j1l, int j2l, int j3l, int j4l, int j1r, int j2r, int j3r, int j4r,
        string desc, string aLeft, string aRight, bool u, Sprite perso)
    {
        jauge1left = j1l;
        jauge2left = j2l;
        jauge3left = j3l;
        jauge4left = j4l;
        jauge1right = j1r;
        jauge2right = j2r;
        jauge3right = j3r;
        jauge4right = j4r;
        actionRight = aRight;
        actionLeft = aLeft;
        unique = u;
        personnage.sprite = perso;
        descrip.text = desc;
    }

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
        jauge1.move(jauge1right);
        jauge2.move(jauge2right);
        jauge3.move(jauge3right);
        jauge4.move(jauge4right);
        rotation = true;
        StartCoroutine(switchAnimation(1));
    }

    public virtual void switchLeft()
    {
        jauge1.move(jauge1left);
        jauge2.move(jauge2left);
        jauge3.move(jauge3left);
        jauge4.move(jauge4left);
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
