using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : BreackableObject
{
    private void OnTriggerStay2D(Collider2D hit)
    {
        if (hit.transform.CompareTag(GameManager.CONST_CLUE))
        {
            if (!hit.GetComponent<Clue>().beenTaken)
            {
                hit.transform.position = transform.position;
                SpawnController.ChangeHoleStatus(transform, false);
            }
        }
    }
}
