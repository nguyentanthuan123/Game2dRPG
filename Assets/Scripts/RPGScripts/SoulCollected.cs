using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulCollected : ThuanBehaviour
{

    [SerializeField] private int soulCollected;
    [SerializeField] private Text soulText;
    [SerializeField] private Text soulTextNotEnough;
    [SerializeField] private Text soulNeedToSell;
    [SerializeField] private int soulDropMin;
    [SerializeField] private int soulDropMax;
    [SerializeField] private int soulToNeed;
    private int soulDrop;

    protected override void Awake()
    {
        soulNeedToSell.text = soulToNeed.ToString();

    }

    protected override void Start()
    {
        soulTextNotEnough.text = "";
        //soulText.text = PlayerPrefs.GetString("soulCollected");
    }

    protected void Update()
    {
        //PlayerPrefs.SetString("soulCollected", soulText.text);
    }
    public virtual void SellNeed()
    {
        if (soulCollected >= soulToNeed)
        {
            SoulEnough();
            GameObject.Find("SamuraiPlayer").GetComponent<StatsPlus>().HealthPlus();
            GameObject.Find("SamuraiPlayer").GetComponent<StatsPlus>().AttackPlus();
            Debug.Log("Resoure enough");
            soulTextNotEnough.text = "";
        }
        else if(soulCollected <= 0 || soulCollected < soulToNeed)
        {
            Debug.Log("Resoure not enough");
            soulTextNotEnough.text = "Resoure not enough";
        }
    }
    public virtual void SoulEnough()
    {
        soulCollected -= soulToNeed;
        soulToNeed += 10;
        soulText.text = soulCollected.ToString();
        soulNeedToSell.text = soulToNeed.ToString();
    }

    public virtual int SoulCollect()
    {
        if (soulCollected >= 0)
        {
            soulCollected += SoulDrop();
            soulText.text = soulCollected.ToString();
        }
        return soulCollected;
    }

    public virtual int SoulDrop()
    {
        soulDrop = Random.Range(soulDropMin, soulDropMax);
        return soulDrop;
    }
}
