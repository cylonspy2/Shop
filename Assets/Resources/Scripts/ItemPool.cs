using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPool : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;
    private List<Transform> children;

    private void Awake()
    {
        GetChildren();
        SpawnItems();
    }

    private void GetChildren()
    {
        children = new List<Transform>();

        for (int i = 0; i < transform.childCount; i++)
        {
            children.Add(transform.GetChild(i));
        }
    }

    private void SpawnItems()
    {
        foreach( Transform child in children )
        {
            Instantiate(itemPrefab, child);
        }
    }

}
