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
    private float velocity;

    protected float Hp
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

    protected float Strength
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

    protected float Defense
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

    protected float Luck
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

    protected float Velocity
    {
        get
        {
            return velocity;
        }

        set
        {
            velocity = value;
        }
    }
}
