using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour {

    private static Battle instance;
    Character player1=null;
    Character player2=null;
    UnityEngine.UI.Button button;

    private void Awake()
    {
        Instance = this;
    }
    public void Hit(int id)
    {

    }
    public void StartBattle(Character p1,Character p2)
    {
        Character human = p1.IsHuman ? p1 : p2;
        UIAttackManager.Instance.SetUIAttackItens(human);
    }
    IEnumerator Fight(Character first, Character second)
    {

        // essa pika aqui e pro eu do futuro
        yield return new WaitUntil(() => true);
    }
    IEnumerator TurnBased(Character p1, Character p2)
    {
        while(p1.CurrentPoints.Hp != 0 && p2.CurrentPoints.Hp != 0)
        {
            Character first = p1.CurrentPoints.Speed > p2.CurrentPoints.Speed ? p1 : p2;
            Character second = p1.CurrentPoints.Speed < p2.CurrentPoints.Speed ? p1 : p2;

            yield return Fight(first, second);
        }
    }
    public static Battle Instance
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

}
