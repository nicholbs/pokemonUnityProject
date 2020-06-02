using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 bevegelse;
    public Animator animator;

    /**********************************************************************//**
    * Funksjon som blir kalt hver frame.
    *
    * Antall ganger kalt avhenger av frameRate. Ypperlig for å hente inn Input.
    **************************************************************************/
    void Update()
    {
        bevegelse.x = Input.GetAxisRaw("Horizontal");//Input blir -1, 0 eller 1
        bevegelse.y = Input.GetAxisRaw("Vertical");  //Input blir -1, 0 eller 1
        //>GetAxisRaw() ser ut til å hente input fra wasd, piltaster osv. 
        animator.SetFloat("Horizontal", bevegelse.x);
        animator.SetFloat("Vertical", bevegelse.y);

        animator.SetFloat("Speed", bevegelse.sqrMagnitude);

    }

    /**********************************************************************//**
    * Funksjon som blir kalt 50 ish ganger hvert sekund.
    *
    * Statisk antall ganger tilkalt. Ypperlig for bevegelse.
    **************************************************************************/
    private void FixedUpdate()
    {
    rb.MovePosition(rb.position + bevegelse * moveSpeed * Time.fixedDeltaTime);
        //>Beveger rigidBody fra nåværende pos + ny pos * hastighet * tid siden
        //>funksjonen ble sist tilkalt.

    }
}
