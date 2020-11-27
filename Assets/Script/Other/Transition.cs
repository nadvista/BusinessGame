using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition
{
    public readonly int maxDrugsLevel1;
    public readonly int maxMoneyLevel1;

    public BaseNode sender;
    public BaseNode target;

    public int level;

    public int drugsToSend;
    public int moneyToSend;

    

    public Transition(BaseNode sender, BaseNode target)
    {
        this.sender = sender;
        this.target = target;
        level = 1;
    }
    public void Edit (int drugsToSend,int moneyToSend)
    {
        this.drugsToSend = drugsToSend;
        this.moneyToSend = moneyToSend;

        int maxm = getMaxMoney();
        int maxd = getMaxDrugs();

        if (this.moneyToSend > maxm)
            moneyToSend = maxm;
        if (this.drugsToSend > maxd)
            drugsToSend = maxd;
    }
    public void Send ()
    {
        if (sender.moneyStorage >= moneyToSend )
        {
            sender.moneyStorage -= moneyToSend;
            target.moneyStorage += moneyToSend;
        }
        if (sender.drugStorage >= drugsToSend)
        {
            sender.drugStorage -= drugsToSend;
            target.drugStorage += drugsToSend;
        }
    }

    private int getMaxMoney ()
    {
        return maxMoneyLevel1 + maxMoneyLevel1 * (level - 1) / 10;
    }
    private int getMaxDrugs()
    {
        return maxDrugsLevel1 + maxDrugsLevel1 * (level - 1) / 10;
    }
}
