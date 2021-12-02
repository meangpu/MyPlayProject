using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    public bool canCast;
    public int spellID = 1;
    [SerializeField] Animator anim;
    [SerializeField] wandAttach wandScpt;
    private string curentState;
    
    void Update()
    {
        if(Input.GetButtonDown("E"))
        {
            if (canCast)
            {
                castSpellByID();
                // wandScpt.PlayEffectAttach();
            }
        }
    }

    void ChangeAnim(string newState)
    {
        if (curentState == newState) return;
        anim.Play(newState);
        curentState = newState;
    }
    
    
    void castSpellByID()
    {
        switch (spellID)
        {
        case 3:
            // Earth
            // anim.SetTrigger("CastEarth");
            ChangeAnim("CastEarth");
            FindObjectOfType<AudioManager>().Play("Mangon3");
            spellID = 1;
            break;
        case 2:
            // water
            ChangeAnim("CastWater");
            // anim.SetTrigger("CastWater");
            FindObjectOfType<AudioManager>().Play("Mangon2");
            spellID = 3;
            break;
        case 1:
            // Fire
            ChangeAnim("CastFire");
            // anim.SetTrigger("CastFire");
            FindObjectOfType<AudioManager>().Play("Mangon1");
            spellID = 2;
            break;
        default:
            print ("Incorrect ID.");
            break;
        }
    }

}
