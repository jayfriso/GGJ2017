using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float speed;

    void Start ()
    {
		GetComponent<Rigidbody2D>().velocity = new Vector3(-speed, 0, 0);
    }
}