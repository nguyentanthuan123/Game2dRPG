using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    //public Transform player;
    //public bool isFlip = false;

    //[Header("Attack")]
    //public int attackDamage;
    //public Vector3 attackOffset;
    //public float attackRange;
    //public LayerMask layerMask;
    //public Transform attackPoint;

    //public void Attack()
    //{
    //    Vector3 pos = transform.position;
    //    pos += transform.right * attackOffset.x;
    //    pos += transform.up * attackOffset.y;

    //    Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, layerMask);
    //    if (colInfo == null) return;
    //    colInfo.GetComponent<CharacterController>().TakeDamage(attackDamage);
    //}

    //public void LookAtPlayer()
    //{
    //    Vector3 flip = transform.localScale;
    //    flip.z *= -1f;

    //    if(transform.position.x > player.position.x && isFlip)
    //    {
    //        transform.localScale = flip;
    //        transform.Rotate(0f, 180f, 0f);
    //        isFlip = false;
    //    }
    //    else if(transform.position.x < player.position.x && !isFlip)
    //    {
    //        transform.localScale = flip;
    //        transform.Rotate(0f, 180f, 0f);
    //        isFlip = true;
    //    }
    //}

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    if (attackPoint == null) return;

    //    Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    //}
}
