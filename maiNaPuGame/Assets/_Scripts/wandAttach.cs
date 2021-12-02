using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wandAttach : MonoBehaviour
{
    [SerializeField] Transform parentTrans;
    [SerializeField] float moveSped;
    [SerializeField] Animator anim;
    [SerializeField] ParticleSystem attachPar;
    [SerializeField] SpellCaster spellScpr;
    [ColorUsage(true, true)]
    [SerializeField] Color black;
    [ColorUsage(true, true)]
    [SerializeField] Color fire;
    [ColorUsage(true, true)]
    [SerializeField] Color water;
    [ColorUsage(true, true)]
    [SerializeField] Color earth;


    public Material fireMat;

    bool isFollow;
    bool IsChild;

    private void Start() 
    {
        fireMat.SetColor("_Color", black);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            if (!isFollow && !IsChild)
            {
                FindObjectOfType<AudioManager>().Play("fpickup");
                isFollow = true;   
                anim.SetTrigger("In");      
            }
        }
    }

    private void Update() 
    {
        if (!IsChild)
        {
            if (transform.position == parentTrans.position)
            {
                IsChild = true;
                makeChild();
                return;
            }
        }

    }

    private void FixedUpdate() 
    {
        if (isFollow)
        {
            transform.position = Vector2.MoveTowards(transform.position, parentTrans.position, Time.deltaTime * moveSped);
        }     
    }

    void makeChild()
    {
        FindObjectOfType<AudioManager>().Play("pickup"); 
        anim.SetTrigger("Out");  
        transform.parent = parentTrans;
        isFollow = false;
        spellScpr.canCast = true;
    }

    public void PlayEffectAttach()
    {
        // switch(id)
        // {
        //     case 3:
        //         // Earth
        //         anim.SetTrigger("CastSpell");
        //         FindObjectOfType<AudioManager>().Play("Mangon1");
        //         spellID = 1;
        //         break;
        //     case 2:
        //         // water
        //         anim.SetTrigger("CastSpell");
        //         FindObjectOfType<AudioManager>().Play("Mangon2");
        //         spellID = 3;
        //         break;
        //      case 1:
        //         // Fire
        //         anim.SetTrigger("CastSpell");
        //         FindObjectOfType<AudioManager>().Play("Mangon1");
        //         spellID = 2;
        //         break;
        //     default:
        //         print ("Incorrect ID.");
        //         break;
        // }
        
        attachPar.Play();
        CameraShake.Instance.ShakeCamera(2f, 0.2f);
        fireMat.SetColor("_Color", fire);
        
    }


}
