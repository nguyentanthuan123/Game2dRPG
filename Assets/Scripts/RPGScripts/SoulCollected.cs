using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulCollected : ThuanBehaviour
{

    private static SoulCollected instances;

    public static SoulCollected Instances { get => instances; }

    public int soulCollect;
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
        if (soulCollect >= soulToNeed)
        {
            SoulEnough();
            GameObject.Find("SamuraiPlayer").GetComponent<StatsPlus>().HealthPlus();
            GameObject.Find("SamuraiPlayer").GetComponent<StatsPlus>().AttackPlus();
            Debug.Log("Resoure enough");
            soulTextNotEnough.text = "";
        }
        else if(soulCollect <= 0 || soulCollect < soulToNeed)
        {
            Debug.Log("Resoure not enough");
            soulTextNotEnough.text = "Resoure not enough";
        }
    }
    public virtual void SoulEnough()
    {
        soulCollect -= soulToNeed;
        soulToNeed += 10;
        soulText.text = soulCollect.ToString();
        soulNeedToSell.text = soulToNeed.ToString();

    }

    public virtual int SoulCollect()
    {
        if (soulCollect >= 0)
        {
            soulCollect += SoulDrop();
            soulText.text = soulCollect.ToString();
        }
        return soulCollect;
    }

    public virtual int SoulDrop()
    {
        soulDrop = Random.Range(soulDropMin, soulDropMax);
        return soulDrop;
    }

}
