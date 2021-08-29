using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameDatabase
{
    public static GameObject GetPlayer { get { return GameObject.FindGameObjectWithTag("Player"); } }
}
