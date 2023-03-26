using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : ThuanBehaviour
{

    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;
    [SerializeField] protected Transform holder;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefabs();
        this.LoadHolder();
    }

    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ": LoadHolder", gameObject);
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;

        Transform preObj = transform.Find("Prefabs");
        foreach (Transform prefab in preObj)
        {
            this.prefabs.Add(prefab);
        }
        this.HidePrefabs();

        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawns(string prefabName, Vector3 spawnPos,Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        if(prefab == null)
        {
            Debug.LogWarning("Prefab not found" + prefabName);
            return null;
        }

        Transform newPrefab = this.GetObjectFormPools(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);

        newPrefab.parent = this.holder;
        return newPrefab;


    }

    public virtual Transform GetObjectFormPools(Transform prefab)
    {
        foreach (Transform poolObj in poolObjs)
        {
            if (poolObj.name == prefab.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    protected virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        gameObject.SetActive(false);
    }

    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach(Transform prefab in prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }

        return null;
    }
}
