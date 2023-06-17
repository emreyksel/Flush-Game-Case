using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private int index;

    private void Start()
    {
        SpawnGem();
    }

    private void Update()
    {
        if (transform.childCount == 0)
            SpawnGem();
    }

    private void SpawnGem()
    {
        index = Random.Range(0, ObjectPool.instance.pools.Length);
        GameObject gem = ObjectPool.instance.GetPooledObject(index);
        gem.transform.position = transform.position + Vector3.up;
        gem.transform.SetParent(transform);
    }
}
