using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects")]
public class Player_Data : ScriptableObject
{
    public int Gold;
    [SerializeField]
    List<Char_Data> Char;
    

}



[System.Serializable]
public class Char_Data
{
    public bool Have;
    public int Level;

}