using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //  >>>Variáveis de movimentação <<< 
    CharacterController playerCC; //variável do carater controller
    Vector3 move; //movimentação do jogador
    float moveX, moveZ;//movimentação por eixo
    [SerializeField] float speed; //mostra o speed no Inspector

    //  >>>Variáveis da Câmera <<< 
    float rotationY, rotationCamera, limitRotationCamera; //guarda inputs do mouse
    [SerializeField] float speedRotation;// velocidade de rotação
    GameObject cameraObj; //Objeto da câmera

    void Start()
    {
        //Pega o componente e guarda na variável
        playerCC = GetComponent<CharacterController>();
        //Armazena o Objeto da Câmera
        cameraObj = GameObject.Find("Main Camera");
    }


    void Update()
    {
        MovePlayer(); //chamar função 
        CameraPlayer(); //chamar função
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
        
        //Rotacionar a câmera
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
        //Movimenta na direção da câmera
        move = transform.TransformDirection(move);

        //Aplica movimentação no Character Controller
        playerCC.Move(move * Time.deltaTime * speed);
    }
}
