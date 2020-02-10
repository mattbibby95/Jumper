using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackground : MonoBehaviour
{

    private Camera cam;
    public Color[] colors;
    private Color bgcol;

    public Color color1 = Color.red;
    public Color color2 = Color.blue;
    public float duration = 3.0F;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        bgcol = cam.backgroundColor;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        cam.backgroundColor = Color.Lerp(color1, color2, t);
    }
}
