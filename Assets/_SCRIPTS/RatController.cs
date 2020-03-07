using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : PhysicsObject
{
    public float movementSpeed;
    private GameObject target;
    
    Vector2 move = Vector2.zero;

    private void Start()
    {
        base.Start();
        target = SearchClosestTarget();
    }

    GameObject SearchClosestTarget()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(GameManager.CONST_INSUMO);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        move = Vector2.zero;

        if (gos.Length > 0)
        {
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
            if (closest)
            {
                move.x = (closest.transform.position.x - transform.position.x);
                move.y = (closest.transform.position.y - transform.position.y);
            }

            return closest;
        }
        else
        {
            print("game over");
            return null;
        }


    }

    protected override void ComputeVelocity()
    {
        if (target)
        {
            if (Vector3.Distance(target.transform.position, transform.position) >= 0.5f)
            {
                //GetComponent<NavMeshAgent2D>().destination = new Vector2(target.transform.position.x, target.transform.position.y);

                targetVelocity = move * movementSpeed;
            }
            else
            {
                BreackableObject breackable = target.GetComponent<BreackableObject>();
                breackable.Breacking();
                if (!target)
                {
                    target = SearchClosestTarget();
                }
            }
        }
        else
        {
            target = SearchClosestTarget();
        }
        
        

        //if (atStairs)
        //{
        //    move.y = Input.GetAxis("Vertical");
        //    //gravityModifier = 0;
        //}

        //bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        //if (flipSprite)
        //{
        //    spriteRenderer.flipX = !spriteRenderer.flipX;
        //}

        //animator.SetBool("grounded", grounded);
        //animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        
    }

}
