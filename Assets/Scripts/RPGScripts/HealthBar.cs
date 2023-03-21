using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : ThuanBehaviour
{
    [SerializeField] protected Slider slider;

    public void SetHealth(int health)
    {
        slider.value = health;
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    protected virtual void LoadSliderHPs()
    {
        if (this.slider != null) return;
        this.slider = transform.GetComponentInChildren<Slider>();
        Debug.LogWarning(transform.name + ": LoadHPBar", gameObject);

    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSliderHPs();
    }
}
