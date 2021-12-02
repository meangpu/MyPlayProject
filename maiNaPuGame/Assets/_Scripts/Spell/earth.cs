using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class earth : MonoBehaviour
{
    bool firstTime = true;
    public Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            if (firstTime)
            {
                CameraShake.Instance.ShakeCamera(rb.velocity.magnitude, 0.15f);
                firstTime = false;
                FindObjectOfType<AudioManager>().PlayOne("earthEle", Mathf.Clamp(rb.velocity.magnitude/4, 0f, 1f));
            }
            else
            {
                FindObjectOfType<AudioManager>().PlayOne("earthEle", Mathf.Clamp(rb.velocity.magnitude/4, 0f, 1f));
            }
        }
    }
}
