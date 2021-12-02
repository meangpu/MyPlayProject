using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    bool firstTime = true;
    public Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            if (firstTime)
            {
                CameraShake.Instance.ShakeCamera(rb.velocity.magnitude/10, 0.15f);
                firstTime = false;
                FindObjectOfType<AudioManager>().PlayOne("waterEle", Mathf.Clamp(rb.velocity.magnitude/15, 0f, 0.85f));
            }
            else
            {
                FindObjectOfType<AudioManager>().PlayOne("waterEle", Mathf.Clamp(rb.velocity.magnitude/15, 0f, .05f));
            }
        }
    }
}
