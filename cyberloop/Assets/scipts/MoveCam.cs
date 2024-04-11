using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public GameObject Camera;
    public float speed;
    public GameObject eggimg;
    private void FixedUpdate()
    {
        Camera.transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
    }
    private void Update()
    {
        if (Input.anyKey)
        {
            eggimg.SetActive(false);
        }
    }
}
