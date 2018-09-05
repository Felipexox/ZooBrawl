using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAttackManager : MonoBehaviour {
    private static UIAttackManager instance;

    [SerializeField]
    private List<UIAttackItem> attackItens = new List<UIAttackItem>();
     
    public void Awake()
    {
        Instance = this;
    }

    public static UIAttackManager Instance
    {
        get
        {
            return instance;
        }

        set
        {
            instance = value;
        }
    }
    public void SetUIAttackItens(Character player)
    {
        for(int i=0;i<attackItens.Count;i++)
        {
            if(i < player.MoveSets.Count)
            {
                attackItens[i].moveName.text = player.MoveSets[i].ToString();
                attackItens[i].moveID = (int)player.MoveSets[i];
                attackItens[i].image.color = ChooseColor(player.MoveSets[i]);
                attackItens[i].gameObject.SetActive(true);
            }
            else
            {
                attackItens[i].gameObject.SetActive(false);
            }
        }
    }
    public Color ChooseColor(EnumMoveSet move)
    {
        Color tempColor = Color.gray;
        switch(move)
        {
            case EnumMoveSet.CHUTE:
                tempColor = Color.green;
                break;
            case EnumMoveSet.INVESTIDA:
                tempColor = Color.green;
                break;
            case EnumMoveSet.CHIFRADA:
                tempColor = Color.green;
                break;
            case EnumMoveSet.BARRIGADA:
                tempColor = Color.green;
                break;
            case EnumMoveSet.MORDIDA:
                tempColor = Color.green;
                break;
            case EnumMoveSet.SOCO:
                tempColor = Color.green;
                break;

        }
        return tempColor;
    }

}
