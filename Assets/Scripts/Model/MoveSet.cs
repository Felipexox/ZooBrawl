using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveSet {

    private Dictionary<EnumMoveSet, float> moves = new Dictionary<EnumMoveSet, float>
    {
        {EnumMoveSet.CHIFRADA, 20f},
        {EnumMoveSet.CHUTE, 10f },
        {EnumMoveSet.INVESTIDA, 20f }
    };

    public Dictionary<EnumMoveSet, float> Moves
    {
        get
        {
            return moves;
        }

        set
        {
            moves = value;
        }
    }
}
