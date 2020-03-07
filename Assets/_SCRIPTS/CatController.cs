using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : PhysicsObject
{
    public float movementSpeed;
    public float jumpHeight;
    [Header("Player")]
    public string horizontal = "Horizontal_P1";
    public string vertical = "Vertical_P1";
    public string jump = "Jump_P1";
    public string fire1 = "Fire1_P1";

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis(horizontal);

        if (atStairs)
        {
            move.y = Input.GetAxis(vertical);
            //gravityModifier = 0;
        }
                
        if (Input.GetButtonDown(jump) && grounded)
        {
            //velocity.y = jumpHeight;
            rb2d.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }
        //else if (Input.GetButtonUp(jump))
        //{
        //    if (velocity.y > 0)
        //    {
        //        velocity.y *= 0.5f;
        //    }
        //}

        


        //bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        //if (flipSprite)
        //{
        //    spriteRenderer.flipX = !spriteRenderer.flipX;
        //}

        //animator.SetBool("grounded", grounded);
        //animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * movementSpeed;
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.transform.CompareTag(GameManager.CONST_STAIRS))
        {
            atStairs = true;
        }
    }

    private void OnTriggerStay2D(Collider2D hit)
    {
        if (hit.GetComponent<RepairTool>())
        {
            if (Input.GetButton(fire1))
            {
                hit.transform.position = transform.position;
            }
            hit.GetComponent<RepairTool>().beenTaken = Input.GetButton(fire1);
        }
    }

    private void OnTriggerExit2D(Collider2D hit)
    {
        if (hit.transform.CompareTag(GameManager.CONST_STAIRS))
        {
            atStairs = false;
        }
    }

}
