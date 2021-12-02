using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    // when call call bt CameraShake.Instance.ShakeCamera(.5f, 2f)
    public static CameraShake Instance {get; private set;}
    private CinemachineVirtualCamera cvc;
    float shakeTimer;
    float shakeTotal;
    float startInten;

    private void Awake() 
    {
        Instance = this;
        cvc = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float inten, float time)
    {
        CinemachineBasicMultiChannelPerlin perin = cvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        perin.m_AmplitudeGain = inten;
        startInten = inten;
        shakeTimer = time;
        shakeTotal = time;
    }

    private void Update() 
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0)
            {
                CinemachineBasicMultiChannelPerlin perin = cvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                perin.m_AmplitudeGain = Mathf.Lerp(startInten, 0f, 1-(shakeTimer/shakeTotal));
                
            }
        }
    }

}
