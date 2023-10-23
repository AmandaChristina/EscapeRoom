using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Biblioteca do texto

public class Player : MonoBehaviour
{
    #region Variáveis
    //  >>>Variáveis de movimentação <<< 
    CharacterController playerCC; //variável do carater controller
    Vector3 move; //movimentação do jogador
    float moveX, moveZ;//movimentação por eixo
    [SerializeField] float speed; //mostra o speed no Inspector

    //  >>>Variáveis da Câmera <<< 
    float rotationY, rotationCamera, limitRotationCamera; //guarda inputs do mouse
    [SerializeField] float speedRotation;// velocidade de rotação
    GameObject cameraObj; //Objeto da câmera

    //  >>>Variáveis do Pulo <<< 
    Vector3 velocity; //movimento y do player
    float gravity = -9.18f;
    float gravityMultiplier = 1.5f;
    [SerializeField] float forceJump; //forca de pulo
    bool isJump;

    //  >>>Variáveis da Animação <<< 
    Animator playerAnimator;
    bool isWalk;

    //  >>>Variáveis Raycast <<< 
    Ray ray;
    TextMeshProUGUI TMPROText;
    #endregion

    void Start()
    {
        //Pega o componente e guarda na variável
        playerCC = GetComponent<CharacterController>();
        //Armazena o Objeto da Câmera
        cameraObj = GameObject.Find("Main Camera");
        //Pega o componente que controla a animação
        playerAnimator = GetComponent<Animator>();

        //Uma linha só!!!!!!!!
        TMPROText = GameObject.Find("ItemText").GetComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        MovePlayer(); //chamar função 
        CameraPlayer(); //chamar função
        JumpPlayer(); //chamar Função
        AnimationPlayer(); //chamar função
        Raycast();
    }


    #region Base Jogador
    void JumpPlayer()
    {
        //Se o jogador está no chão
        if (playerCC.isGrounded)
        {
            isJump = false; //
            velocity.y = 0f; //zera a queda
        }

        //Enquanto estiver no ar: vai cair
        velocity.y += gravity * Time.deltaTime * gravityMultiplier;

        //subindo
        if (Input.GetButtonDown("Jump") && playerCC.isGrounded && !isJump)
        {
            isJump = true;
            //Retorna a raiz quadrada
            velocity.y += Mathf.Sqrt(forceJump * -3.0f * gravity);
        }
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

        //limitRotationCamera = Mathf.Clamp(limitRotationCamera, -28, 80);
        //cameraObj.transform.Rotate(Vector3.up * limitRotationCamera);
        //print(rotationCamera);

    }

    void MovePlayer()
    {

        //Inputs horizontais: AD, Setas e horizontal do direcional
        moveX = Input.GetAxis("Horizontal");
        //Inputs verticais: WS, Setas e vertical do direcional
        moveZ = Input.GetAxis("Vertical");

        //Guarda os valores em um novo Vetor
        move = new Vector3(moveX, velocity.y, moveZ);
        //Movimenta na direção da câmera
        move = transform.TransformDirection(move);

        //Aplica movimentação no Character Controller
        playerCC.Move(move * Time.deltaTime * speed);
    }

    void AnimationPlayer()
    {
        if (playerCC.velocity.x != 0 || playerCC.velocity.z != 0)
        {
            playerAnimator.SetBool("isWalk", true);
        }
        else if (playerCC.velocity.x == 0 || playerCC.velocity.z == 0)
        {
            playerAnimator.SetBool("isWalk", false);
        }

        playerAnimator.SetBool("isJump", isJump);
    }
    #endregion
    void Raycast()
    {
        
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.blue);

            if (hit.transform != null && hit.transform.CompareTag("Item"))
            {
                Item item = hit.transform.GetComponent<Item>();
                TMPROText.text = item.OnFocus();

                if (Input.GetMouseButtonDown(0))
                {
                    item.CollectMe(hit.transform.gameObject);
                    item._itemEvent.Invoke();
                }
            }
            else TMPROText.text = " "; 
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(ray.origin, ray.direction * Mathf.Infinity);
    }


}
