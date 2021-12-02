using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controllerScpt;
    public Animator mainAnim;
    public float runSpeed = 30f;
    float horizontalMove = 0f;
    bool jump = false;
    bool stopjump = false;

	// player can jump before touch ground
	public float jumpBufferLength = 0.5f;
	private float jumpBufferCount;

    // emission part
    public ParticleSystem walkPar;
    public int walkParRate = 12;
    private ParticleSystem.EmissionModule walkParEmission;




    private void Start() 
    {
        walkParEmission = walkPar.emission;
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        mainAnim.SetFloat("WalkSpeed", Mathf.Abs(horizontalMove));
        
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if(horizontalMove != 0 && controllerScpt.m_Grounded)
        {
            walkParEmission.rateOverTime = walkParRate;
        }
        else
        {
            walkParEmission.rateOverTime = 0f;
        }


        if (Input.GetButtonUp("Jump"))
        {
            stopjump = true;
        }
    }

    private void FixedUpdate() 
    {
        controllerScpt.Move(horizontalMove * Time.fixedDeltaTime, false, jump, stopjump);
        jump = false;
        stopjump = false;
    }

}
