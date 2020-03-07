using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreackableObject : MonoBehaviour
{
    public Transform progressBar;
    private float timeToDestroy;

    private void Start()
    {
        progressBar = transform.GetChild(0).GetChild(0);
        progressBar.parent.gameObject.SetActive(false);
        timeToDestroy = GameManager.CONST_TIMETODESTROY;
    }
    public void Breacking()
    {
        progressBar.parent.gameObject.SetActive(true);
        timeToDestroy -= Time.deltaTime;
        float barProgress = (timeToDestroy / GameManager.CONST_TIMETODESTROY);
        progressBar.localScale = new Vector3(barProgress, progressBar.localScale.y, progressBar.localScale.z);
        if (timeToDestroy < 0)
        {
            DestroyImmediate(gameObject);
        }
    }
}
