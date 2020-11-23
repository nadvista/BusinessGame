using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseNode : MonoBehaviour
{
    public List<Transition> transitions;

    [SerializeField] public string uiName;
    [SerializeField] public string nodeName;

    [SerializeField] public int moneyCost;
    [SerializeField] public int authorityCondition;

    [SerializeField] public int level;
    [SerializeField] public int moneyStorageSize;
    [SerializeField] public int resStorageSize;
    [SerializeField] public int drugsStorageSize;

    public int hierarchyIndex { get; set; }

    private int moneyStorage;
    private int resStorage;
    private int drugsStorage;

    


    private void Start()
    {
        transitions = new List<Transition>();
    }

    public void MakeTransition(BaseNode target, int money,int res,int drugs)
    {
        //transitions.
    }
    public void Step ()
    {
        foreach (var t in transitions)
            t.Send();
    }
    public void AddTransition ()
    {

    }
}
