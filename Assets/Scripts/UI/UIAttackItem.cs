using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIAttackItem : MonoBehaviour {

    public Text moveName;
    public int moveID;
    public Image image;

    public void ChooseAttack()
    {
        Battle.Instance.Hit(moveID);
    }
}
