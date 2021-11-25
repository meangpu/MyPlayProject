using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitSound : MonoBehaviour
{
    public Rigidbody2D rb;
    private void OnCollisionEnter2D(Collision2D other) 
    {
        FindObjectOfType<AudioManager>().PlayOne("hit2", rb.velocity.magnitude/5);
    }

}
