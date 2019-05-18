using System;
using UnityEngine;

public class ValueHolder
{
    public static string[] playerNames = new string[4];
    public static int numOfPlayers = 4;
    public static void printNames() {
        //for debugging purposes
        foreach (string name in playerNames)
        {
            Debug.Log(name);
        }
    }
}