using UnityEngine;

public class LockRotation : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
       rb = GetComponent<Rigidbody>();

        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

}
