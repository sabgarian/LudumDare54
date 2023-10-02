using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ObjectPickup : MonoBehaviour
{
    Vector3 pos;

    protected bool floating = true;

    protected virtual void Start()
    {
        pos = transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Effect();
            Destroy(gameObject);
        }
    }

    public virtual void Effect()
    {
        Debug.Log("Effect not implemented");
    }

    protected virtual void Update()
    {
        if (!floating)
        {
            return;
        }

        float time = Time.time;
        float offset = Mathf.Sin(5 * time);
        offset /= 10f;

        gameObject.transform.position = pos + Vector3.up * offset;
    }
}
