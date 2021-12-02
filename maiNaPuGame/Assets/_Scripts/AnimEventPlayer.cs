using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEventPlayer : MonoBehaviour
{
    [SerializeField] wandAttach wandScpt;
    [Header("Fire")]
    [SerializeField] GameObject fireBall;
    [SerializeField] Vector3 offSet;
    [Header("Water")]
    [SerializeField] GameObject water;
    [SerializeField] Transform wandTransForm;
    [SerializeField] float forceAdd;
    [Header("Earth")]
    [SerializeField] GameObject earth;

    [SerializeField] Camera mainCam;
    [SerializeField] Rigidbody2D rb;

    public void callFire()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = mainCam.ScreenToWorldPoint(mousePos);
        objectPos.z = 0;
        wandScpt.PlayEffectAttach();
        GameObject newSpawn = Instantiate(fireBall, objectPos + offSet, Quaternion.identity);
        float theValue = Random.Range(0.6f, 1.1f);
        newSpawn.transform.localScale = new Vector3(theValue, theValue, theValue);
    }
    public void callWater()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = mainCam.ScreenToWorldPoint(mousePos);
        objectPos.z = 0;
        wandScpt.PlayEffectAttach();
        GameObject newSpawn = Instantiate(water, wandTransForm.position, Quaternion.identity);
        float theValue = Random.Range(0.2f, 0.3f);
        newSpawn.transform.localScale = new Vector3(theValue, theValue, theValue);
        Rigidbody2D objRb = newSpawn.GetComponent<Rigidbody2D>();
        objRb.AddForce((objectPos - newSpawn.transform.position)*forceAdd, ForceMode2D.Impulse); 

    }
    public void callEarth()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = mainCam.ScreenToWorldPoint(mousePos);
        objectPos.z = 0;
        wandScpt.PlayEffectAttach();
        GameObject newSpawn = Instantiate(earth, objectPos, Quaternion.identity);
        float theValue = Random.Range(1f, 1.8f);
        newSpawn.transform.localScale = new Vector3(theValue, theValue, theValue);
        Rigidbody2D objRb = newSpawn.GetComponent<Rigidbody2D>();
        objRb.AddForce(Vector2.up * 130, ForceMode2D.Impulse); 
   
    }





    public void DisableGravity()
    {
        rb.gravityScale = 0;
    }
    public void EnableGravity()
    {
        rb.gravityScale = 1;
    }



}
