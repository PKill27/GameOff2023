using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leopard : Player
{
    private bool isAttacking;
    public GameObject attackOrigin;

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    private void OnCollisionExit2D(Collision2D collision)
    {

    }

    new public void Move(Vector2 movement)
    {
        if (!isAttacking)
        {
            base.Move(movement);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && !isAttacking)
        {
            Attack();
        }
    }

    private void Attack()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(attackOrigin.transform.position, .1f, Vector2.zero);
        isAttacking = true;
        // Process the hits
        foreach (var hit in hits)
        {
            if (hit.collider.CompareTag("Breakable"))
            {
                IceWall wall = hit.collider.gameObject.GetComponent<IceWall>();
                wall.takeDamage(1);
                Debug.Log("Hit object: " + hit.collider.gameObject.name);
            }
        }
       StartCoroutine( WaitForEndOfAttack());
    }

    IEnumerator WaitForEndOfAttack()
    {
        //animator attack
        yield return new WaitForSeconds(2f);
        isAttacking = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackOrigin.transform.position, .1f);
    }
}
