using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    [SerializeField]
    protected CharacterPoints points;

    protected MoveSet moveSet = new MoveSet();

    [SerializeField]
    protected List<EnumSpecialAbilities> specialAbilities;

    private void Start()
    {
        Debug.Log(moveSet.Moves[EnumMoveSet.CHIFRADA]);
    }
}
