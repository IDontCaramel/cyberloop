using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public GameObject Camera;
    public float speed;
    private void FixedUpdate()
    {
        Camera.transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
    }
}
