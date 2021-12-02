using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    bool firstTime = true;
    public Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            if (firstTime)
            {
                CameraShake.Instance.ShakeCamera(rb.velocity.magnitude/2, 0.15f);
                firstTime = false;
                FindObjectOfType<AudioManager>().PlayOne("FireBall", Mathf.Clamp(rb.velocity.magnitude/10, 0f, 0.85f));
            }
            else
            {
                FindObjectOfType<AudioManager>().PlayOne("FireBall", Mathf.Clamp(rb.velocity.magnitude/10, 0f, .05f));
            }
        }
    }

}
