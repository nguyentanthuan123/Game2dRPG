using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : ThuanBehaviour
{
    public float followSpeed;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, 0f);
        transform.position = Vector3.Lerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }

    //protected override void LoadComponents()
    //{
    //    base.LoadComponents();
    //    this.LoadTarget();
    //}

    //protected virtual void LoadTarget()
    //{
    //    if (this.target != null) return;
    //    this.target = transform.Find("SamuraiPlayer");
    //    Debug.Log(transform.name + ": LoadSamuraiPlayer", gameObject);
    //}
}
