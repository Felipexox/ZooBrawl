using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    [SerializeField]
    private CharacterPoints basePoints;
    private CharacterPoints currentPoints;

    [SerializeField]
    private List<EnumSpecialAbilities> specialAbilities = new List<EnumSpecialAbilities>();

    [SerializeField]
    private List<EnumMoveSet> moveSets = new List<EnumMoveSet>();

    private bool isHuman;

    public void InviteToBattle(Character inviter)
    {
        Battle.Instance.StartBattle(this, inviter);
    }

    public CharacterPoints BasePoints
    {
        get
        {
            return basePoints;
        }

        set
        {
            basePoints = value;
        }
    }

    public List<EnumSpecialAbilities> SpecialAbilities
    {
        get
        {
            return specialAbilities;
        }

        set
        {
            specialAbilities = value;
        }
    }

    public List<EnumMoveSet> MoveSets
    {
        get
        {
            return moveSets;
        }

        set
        {
            moveSets = value;
        }
    }

    public CharacterPoints CurrentPoints
    {
        get
        {
            return currentPoints;
        }

        set
        {
            currentPoints = value;
        }
    }

    public bool IsHuman
    {
        get
        {
            return isHuman;
        }

        set
        {
            isHuman = value;
        }
    }

    private void Start()
    {
       
    }
}
