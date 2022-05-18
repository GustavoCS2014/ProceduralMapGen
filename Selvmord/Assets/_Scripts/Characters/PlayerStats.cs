using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private void Start()
    {
        LifePoints = 10f;
        AttackEnergy = 5;
        GeneralEnergy = 3;
    }
    public float LifePoints { set; get; }
    public int AttackEnergy { set; get; }
    public int GeneralEnergy { set; get; }
}
