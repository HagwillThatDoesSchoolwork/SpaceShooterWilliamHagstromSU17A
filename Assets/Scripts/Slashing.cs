using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slashing : MonoBehaviour
{
    float rsXInput, rsYInput, fireBtn;
    Vector2 aimDirection;

    [Range(0.001f, 5f)]
    public float fireMinInterval = 0.1f;
    [Range(1f, 10f)]
    public float slashDistance = 5f;
    public Vector2 slashBoxSize;
    [Range(0.1f, 2f)]
    public float playerSize;

    RaycastHit2D[] hit;
    [HideInInspector]
    public Ship ship;

    bool fireBtnActive = false;
    float nextFire;

    Vector3 slashPosition;

    private void Awake()
    {
        ship = GetComponent<Ship>();
    }

    private void Update()
    {
        //Aiming by the axis input an converting it to a vector2.
        {
            rsXInput = Input.GetAxis("RS_Horizontal");
            rsYInput = Input.GetAxis("RS_Vertical");
            fireBtn = Input.GetAxisRaw("Fire1");
            aimDirection.x = rsXInput;
            aimDirection.y = rsYInput;
            aimDirection.Normalize();
        }

        //The initialization of the slash via a axis that acts as a button
        {
            if (aimDirection != Vector2.zero && !fireBtnActive && nextFire <= Time.time && fireBtn < 0f)
            {
                fireBtnActive = true;
                Slash();
                nextFire = fireMinInterval + Time.time;
            }
            else if (fireBtn == 0) { fireBtnActive = false; }
        }
    }

    private void Slash()
    {
        Debug.DrawRay(transform.position, aimDirection * (slashDistance - (playerSize / 2)), Color.green, 1f);

        hit = Physics2D.BoxCastAll(transform.position, slashBoxSize, transform.eulerAngles.z, aimDirection, slashDistance - (playerSize / 2));

        //Checks if the slash was over an enemy and if that is true it deals damage to that enemy
        for (int i = 0; i < hit.Length; i++)
        {
            if (hit.Length > 0 && hit[i].collider != null && hit[i].collider.CompareTag("Enemy"))
                ship.DealDmg(hit[i].collider.gameObject, 1f);
        }

        //Cashing the position the player wants to slash to
        slashPosition = transform.position + (Vector3)aimDirection * slashDistance;

        //Checks if the player left the play area and if that's the case then it puts the player back inside
        {
            if (slashPosition.x <= -8.9f)
                slashPosition.x += -(8.9f + slashPosition.x - (playerSize / 2));

            else if (slashPosition.x >= 8.9f)
                slashPosition.x += (8.9f - slashPosition.x - (playerSize / 2));

            if (slashPosition.y <= -5f)
                slashPosition.y += -(5f + slashPosition.y - (playerSize / 2));

            else if (slashPosition.y >= 5f)
                slashPosition.y += (5f - slashPosition.y - (playerSize / 2));
        }

        //The actual slash
        transform.position = slashPosition;
    }
}