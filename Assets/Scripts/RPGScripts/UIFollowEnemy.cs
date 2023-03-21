using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowEnemy : MonoBehaviour
{
    public Transform objectToFollow;
    RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        ObjectFollow();
    }
    protected virtual void ObjectFollow()
    {
        if (objectToFollow == null) return;

        rectTransform.anchoredPosition = objectToFollow.localPosition;
    }
}
