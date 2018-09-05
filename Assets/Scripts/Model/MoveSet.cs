using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveSet {

    public static Dictionary<EnumMoveSet, Vector2> moves = new Dictionary<EnumMoveSet, Vector2>
    {
        {EnumMoveSet.CHIFRADA, new Vector2(20f, 1)},
        {EnumMoveSet.CHUTE, new Vector2(10f, 1)},
        {EnumMoveSet.INVESTIDA, new Vector2(20f, 1)},
        {EnumMoveSet.MORDIDA, new Vector2(40f, 0.8f) },
        {EnumMoveSet.SOCO, new Vector2(10f, 1)},
        {EnumMoveSet.BARRIGADA, new Vector2(30f, 0.9f) }
    };

}
