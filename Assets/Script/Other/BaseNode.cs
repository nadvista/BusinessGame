using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public abstract class BaseNode : MonoBehaviour
{
    public string publicName;
    public int moneyStorage
    {
        get { return moneyStorage; }
        set
        {
            moneyStorage = value;
            if (moneyStorage >= moneyStorageSize)
                moneyStorage = moneyStorageSize;
        }
    }
    public int drugStorage
    {
        get { return drugStorage; }
        set
        {
            moneyStorage = value;
            if (drugStorage >= drugsStorageSize)
                drugStorage = drugsStorageSize;
        }
    }
    public int index
    {
        get
        {
            return _index;
        }
        set
        {
            if (value < Save.game.workPlace.Count)
            {
                BaseNode sNode = Save.game.workPlace[value];
                Save.game.workPlace[value] = this;
                Save.game.workPlace[_index] = sNode;
                _index = value;
            }
        }
    }
    public int moneyStorageSize { get; private set; }
    public int drugsStorageSize { get; private set; }



    public List<Transition> transitions;

    private string privateName;
    private int _index;


}
