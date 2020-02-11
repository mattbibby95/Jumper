using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{

    CinemachineVirtualCamera virtualCamera;
    CinemachineBasicMultiChannelPerlin noise;

    private IEnumerator shaker;

    // Start is called before the first frame update
    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Shake(float amp, float freq, float shaketime)
    {
        noise.m_AmplitudeGain = amp;
        noise.m_FrequencyGain = freq;
        yield return new WaitForSeconds(shaketime);
        noise.m_AmplitudeGain = 0;
        noise.m_FrequencyGain = 0;
    }

    public void DoShake(float amp, float freq, float shaketime)
    {
        shaker = Shake(amp, freq, shaketime);
        StartCoroutine(shaker);
    }
}
