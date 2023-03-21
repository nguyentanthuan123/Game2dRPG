using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowEnenmy : MonoBehaviour
{
    public Transform objectFollow;
    RectTransform rectTransform;
    // Start is called before the first frame update
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(objectFollow != null)
        {
            rectTransform.anchoredPosition = objectFollow.localPosition;
        }
    }
}
