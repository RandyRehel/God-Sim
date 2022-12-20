using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedMove : MonoBehaviour
{
    private GameObject moveTarget;
    private Animator targetAnimator;
    public float moveSpeed;
    public float moveRotation;

    void Start()
    {
        moveTarget = gameObject;
        targetAnimator = gameObject.GetComponent<Animator>();
        
        
    }

    private void FixedUpdate()
    {
        targetAnimator.SetFloat("Speed", moveTarget.GetComponent<Rigidbody>().velocity.magnitude);
        if(gameObject.GetComponent<variables>().isSocketed == false)
        {
            StartCoroutine(MoveCD());
        }
    }

    IEnumerator MoveCD()
    {
        while (true)
        {
            //attendre 3 secondes avant chaque op�ration
            yield return new WaitForSeconds(3);
            Move();
            yield return new WaitForSeconds(1);
            //arr�ter le mouvement du personnage
            moveTarget.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    void Move()
    {
        //g�n�ration d'un angle de rotation al�atoire
        moveRotation = Random.Range(0, 180);

        //on tourne le gameobject de l'angle g�n�r�
        moveTarget.transform.Rotate(0, moveRotation, 0);

        //faire avancer le personnage
        moveTarget.GetComponent<Rigidbody>().velocity = transform.forward * moveSpeed;
    }
}
