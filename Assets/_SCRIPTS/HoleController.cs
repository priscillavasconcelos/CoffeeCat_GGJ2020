using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleController : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D hit)
    {
        if (hit.transform.CompareTag(GameManager.CONST_NOVELO))
        {
            if (!hit.GetComponent<WoolBall>().beenTaken)
            {
                hit.transform.position = transform.position;
                SpawnController.ChangeHoleStatus(transform, false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D hit)
    {
        if (hit.transform.CompareTag(GameManager.CONST_NOVELO))
        {
            SpawnController.ChangeHoleStatus(transform, true);
            //if (!Input.GetButton("Fire1"))
            //{
                
            //}
        }
    }
}
