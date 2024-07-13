using UnityEngine;
using System.Collections;

public class PipeThrower : MonoBehaviour
{
    public GameObject throwableObject;
    public float speed = 5f;
    public float delay = 1f;
    private float nextThrowTime;
    public float position = 0f;

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
        Vector3 vector3 = new Vector3(position, 0,0);
        GameObject thrownObject = Instantiate(throwableObject, transform.position + vector3, Quaternion.identity);
        thrownObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * transform.localScale.x, 0);
    }
}
