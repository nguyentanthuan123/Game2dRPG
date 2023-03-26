using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThuanBehaviour : MonoBehaviour
{
    protected virtual void Start()
    {
        //For Overide
    }

    protected virtual void Reset()
    {
        this.LoadComponents();
    }

    protected virtual void Awake()
    {
        this.LoadComponents();
    }

    protected virtual void LoadComponents()
    {
        //For Overide
    }
}
