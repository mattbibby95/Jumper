using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourHandler : MonoBehaviour
{

    public Color[] primary, complimentary, mainEnemy, altEnemy;
    public Camera backgroundCam;
    public Material playerMaterial, bulletMaterial, mainEnemyMaterial, altEnemyMaterial;
    public float changeTime = 2.0f;
    public int currentIndex;
    private IEnumerator bgChange, playerChange, bulletChange, enemyChange, altEnemyChange;

    // Start is called before the first frame update
    void Start()
    {
        currentIndex = 0;
        playerMaterial.SetColor("_Color", complimentary[0]);
        bulletMaterial.SetColor("_Color", complimentary[0]);
        mainEnemyMaterial.SetColor("_Color", mainEnemy[0]);
        altEnemyMaterial.SetColor("_Color", altEnemy[0]);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void nextColour()
    {
        currentIndex++;
        currentIndex %= primary.Length;
        bgChange = changeBGColour(backgroundCam, backgroundCam.backgroundColor, primary[currentIndex], changeTime);
        StartCoroutine(bgChange);
        playerChange = changeMaterialColour(playerMaterial, playerMaterial.GetColor("_Color"), complimentary[currentIndex], changeTime);
        StartCoroutine(playerChange);
        bulletChange = changeMaterialColour(bulletMaterial, bulletMaterial.GetColor("_Color"), complimentary[currentIndex], changeTime);
        StartCoroutine(bulletChange);
        enemyChange = changeMaterialColour(mainEnemyMaterial, mainEnemyMaterial.GetColor("_Color"), mainEnemy[currentIndex], changeTime);
        StartCoroutine(enemyChange);
        altEnemyChange = changeMaterialColour(altEnemyMaterial, altEnemyMaterial.GetColor("_Color"), altEnemy[currentIndex], changeTime);
        StartCoroutine(altEnemyChange);
    }

    private IEnumerator changeMaterialColour(Material material, Color startcol, Color endcol, float time)
    {

        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            material.SetColor("_Color", Color.Lerp(startcol, endcol, (elapsedTime / time)));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

    }

    private IEnumerator changeBGColour(Camera cam, Color startcol, Color endcol, float time)
    {

        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            cam.backgroundColor = Color.Lerp(startcol, endcol, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

    }
}
