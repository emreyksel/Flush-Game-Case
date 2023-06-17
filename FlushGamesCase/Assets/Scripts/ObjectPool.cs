using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class ObjectPool : MonoBehaviour
{
    [Serializable]
    public class Pool
    {
        public Queue<GameObject> pooledObjects;
        public string gemName;
        public float price;
        public Sprite ýcon; 
        public GameObject objectPrefab;
        public int poolSize;
        [HideInInspector] public  int collectedGem;      
    }

    public static ObjectPool instance;

    public Pool[] pools = null;

    private void Awake()
    {
        instance = this;

        for (int j = 0; j < pools.Length; j++)
        {
            pools[j].pooledObjects = new Queue<GameObject>();

            GameObject UIgem = Instantiate(UIManager.instance.gemUI, UIManager.instance.canvas);
            UIgem.transform.GetChild(0).GetComponent<Image>().sprite = pools[j].ýcon;
            UIgem.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Gem Type: " + pools[j].gemName;

            for (int i = 0; i < pools[j].poolSize; i++)
            {
                GameObject obj = Instantiate(pools[j].objectPrefab, transform);
                obj.GetComponent<Gem>().type = j;
                obj.GetComponent<Gem>().price = pools[j].price;
                obj.SetActive(false);
                pools[j].pooledObjects.Enqueue(obj);
            }
        }
    }

    public GameObject GetPooledObject(int objectType)
    {
        if (objectType >= pools.Length)
            return null;

        GameObject obj = pools[objectType].pooledObjects.Dequeue();
        obj.SetActive(true);
        return obj;
    }

    public void SendPooledObject(int objectType, GameObject obj)
    {
        if (objectType >= pools.Length)
            return;

        obj.SetActive(false);
        pools[objectType].pooledObjects.Enqueue(obj);
        obj.transform.SetParent(transform);
    }
}
