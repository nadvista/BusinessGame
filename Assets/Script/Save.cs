using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
[System.Serializable]
public class Save : MonoBehaviour
{
    public static Save game;

    public const int startMoney = 10000;
    public const int startDrugs = 100;


    public List<BaseNode> workPlace;
    public BaseNode player;
    private void Start()
    {
        game = this;
    }
}
