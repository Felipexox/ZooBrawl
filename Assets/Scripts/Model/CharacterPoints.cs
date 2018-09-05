using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CharacterPoints {
    [SerializeField]
    private float hp;
    [SerializeField]
    private float strength;
    [SerializeField]
    private float defense;
    [SerializeField]
    private float luck;
    [SerializeField]
    private float speed;

    public float Hp
    {
        get
        {
            return hp;
        }

        set
        {
            hp = value;
        }
    }

    public float Strength
    {
        get
        {
            return strength;
        }

        set
        {
            strength = value;
        }
    }

    public float Defense
    {
        get
        {
            return defense;
        }

        set
        {
            defense = value;
        }
    }

    public float Luck
    {
        get
        {
            return luck;
        }

        set
        {
            luck = value;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }
}
