using UnityEngine;
using System.Collections;

public class StraightMover : MonoBehaviour
{
    public float speed = 5.0f;

    void Start ()
    {
		GetComponent<Rigidbody2D>().velocity = new Vector3(-speed, 0, 0);
    }
}