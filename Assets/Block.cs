using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float minHeight;
    public float maxHeight;
    public GameObject root;

    private void Start()
    {
        ChangeHeight();
    }
    void ChangeHeight()
    {
        float height = Random.Range(minHeight, maxHeight);
        root.transform.localPosition = new Vector3(0f, height, 0f);
    }
    void ScrollEnd()
    {
        ChangeHeight();
    }
}
