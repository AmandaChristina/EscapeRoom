using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //  >>>Vari�veis de movimenta��o <<< 
    CharacterController playerCC; //vari�vel do carater controller
    Vector3 move; //movimenta��o do jogador
    float moveX, moveZ;//movimenta��o por eixo
    [SerializeField] float speed; //mostra o speed no Inspector

    //  >>>Vari�veis da C�mera <<< 
    float rotationY, rotationCamera, limitRotationCamera; //guarda inputs do mouse
    [SerializeField] float speedRotation;// velocidade de rota��o
    GameObject cameraObj; //Objeto da c�mera

    void Start()
    {
        //Pega o componente e guarda na vari�vel
        playerCC = GetComponent<CharacterController>();
        //Armazena o Objeto da C�mera
        cameraObj = GameObject.Find("Main Camera");
    }


    void Update()
    {
        MovePlayer(); //chamar fun��o 
        CameraPlayer(); //chamar fun��o
    }

    void CameraPlayer()
    {
        //Travando o cursor no meio da tela
        Cursor.lockState = CursorLockMode.Locked;

        //Input horizontal do mouse
        rotationY = Input.GetAxis("Mouse X");
        //Input Vertical do mouse
        rotationCamera = Input.GetAxis("Mouse Y");

        //rotacionando o jogador
        transform.Rotate(Vector3.up * rotationY * speedRotation * Time.deltaTime);
        
        //Rotacionar a c�mera
        cameraObj.transform.Rotate(Vector3.right * -rotationCamera * speedRotation/2 * Time.deltaTime);

        limitRotationCamera = Mathf.Clamp(limitRotationCamera, -28, 80);
        cameraObj.transform.Rotate(Vector3.up * limitRotationCamera);
        print(rotationCamera);

    }

    void MovePlayer()
    {

        //Inputs horizontais: AD, Setas e horizontal do direcional
        moveX = Input.GetAxis("Horizontal");
        //Inputs verticais: WS, Setas e vertical do direcional
        moveZ = Input.GetAxis("Vertical");

        //Guarda os valores em um novo Vetor
        move = new Vector3(moveX, 0, moveZ);
        //Movimenta na dire��o da c�mera
        move = transform.TransformDirection(move);

        //Aplica movimenta��o no Character Controller
        playerCC.Move(move * Time.deltaTime * speed);
    }
}
