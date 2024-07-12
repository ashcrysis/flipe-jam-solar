using UnityEngine;
using System.Collections;

public class PipeThrower : MonoBehaviour
{
    public GameObject throwableObject;
    public float speed = 5f;
    public float delay = 1f;
    private float nextThrowTime;

    void Update()
    {
        if (Time.time > nextThrowTime)
        {
            ThrowObject();
            nextThrowTime = Time.time + delay;
        }
    }

    void ThrowObject()
    {
        GameObject thrownObject = Instantiate(throwableObject, transform.position, Quaternion.identity);
        thrownObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * transform.localScale.x, 0);
    }
}
