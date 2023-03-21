using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawn : ThuanBehaviour
{

    [SerializeField] protected List<Transform> prefabs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefabs();
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
        Transform newPrefab = Instantiate(prefab, spawnPos, rotation);

        return newPrefab;
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
