using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public int type;
    public float price;
    private float maxScale;

    private void Start()
    {
        maxScale = Vector3.Magnitude(new Vector3(1, 10, 1));
    }

    private void OnEnable()
    {
        gameObject.tag = "Untagged";
        transform.localScale = Vector3.zero;
    }

    private void Update()
    {
        if (gameObject.tag != "Stacked")
        {
            transform.localScale += Time.deltaTime * new Vector3(1, 10, 1) * 0.2f;
            transform.localScale = Vector3.ClampMagnitude(transform.localScale, maxScale);
        }

        if (transform.localScale.x >= 0.25f && gameObject.tag != "Stacked")
        {
            gameObject.tag = "Gem";
        }
    }
}
