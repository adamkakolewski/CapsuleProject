using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    public GameObject objectToThrow;
    [SerializeField] float throwForce = 10f;
    public Transform throwPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Throw();
        }
    }

    void Throw()
    {
        if (objectToThrow != null && throwPoint != null)
        {
            GameObject thrownObject = Instantiate(objectToThrow, throwPoint.position, throwPoint.rotation);

            Rigidbody rb = thrownObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(throwPoint.forward *  throwForce, ForceMode.Impulse);
            }
            Destroy(thrownObject, 3f);
        }
    }
}
