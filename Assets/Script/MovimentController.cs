using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class MovimentController : NetworkBehaviour
{
    private CharacterController characterController;
    public float speed = 5f;
    public Animator animator;

    public void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    public override void FixedUpdateNetwork()
    {
        if (HasStateAuthority)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direcao = new Vector3(horizontal, 0, vertical);
            if (direcao.magnitude > 0.1f)
            {
                #region 1ª forma de movimentação
                ////movimento do personagem
                //characterController.Move(direcao * speed * Runner.DeltaTime);
                ////rotacao do personagem
                //transform.rotation = Quaternion.LookRotation(direcao);
                #endregion

                #region 2ª forma de movimentação
                //movimento do personagem
                characterController.Move(
                transform.forward * vertical * speed*Runner.DeltaTime);
                //rotação do personagem
                float velocidadeRotacao = speed * 50f;
                transform.Rotate(new Vector3(0, horizontal * velocidadeRotacao * Runner.DeltaTime, 0));
                #endregion
                //animacao do personagem
                animator.SetBool("podeandar" , true);
            }
            else 
            { 
                animator.SetBool("podeandar" , false);
            }


        
        }
    }
}
