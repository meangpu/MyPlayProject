using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imgPointShow : MonoBehaviour
{
    [SerializeField] GameObject img1;
    [SerializeField] GameObject img2;
    [SerializeField] GameObject img3;

    public void set(int howMuch)
    {
        if (howMuch == 1)
        {
            img1.SetActive(true);
            img2.SetActive(false);
            img3.SetActive(false);
        }
        else if(howMuch == 2)
        {
            img1.SetActive(true);
            img2.SetActive(true);
            img3.SetActive(false);
        }
        else if(howMuch == 3)
        {
            img1.SetActive(true);
            img2.SetActive(true);
            img3.SetActive(true);
        }

    }


}
