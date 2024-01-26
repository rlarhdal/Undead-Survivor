using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiveManager : MonoBehaviour
{
    public GameObject[] lockCharacters;
    public GameObject[] unlockCharacters;

    enum Achive { UnlockPotato, UnlockBean }

    Achive[] achives;

    void Awake()
    {
        achives = (Achive[])Enum.GetValues(typeof(Achive));    
    }

    void Start()
    {
        
    }

}
