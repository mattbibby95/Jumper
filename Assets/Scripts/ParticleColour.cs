using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColour : MonoBehaviour
{

    private ColourHandler ch;

    // Start is called before the first frame update
    void Awake()
    {
        ch = GameObject.FindGameObjectWithTag("GameController").GetComponent<ColourHandler>();
        ParticleSystem.MainModule ps = GetComponent<ParticleSystem>().main;
        Color tmpCol = ch.altEnemy[ch.currentIndex];
        tmpCol.a = 1.0f;
        Debug.Log(tmpCol);
        ps.startColor = new ParticleSystem.MinMaxGradient(tmpCol);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
