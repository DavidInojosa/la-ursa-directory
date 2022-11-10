using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    [Header("Configure o valor do jogador")]
    [Tooltip("velocidade do jogador")]
    public float speed = 0.07f;
    [Tooltip("Força de salto do jogador")]
    public float jumpForce = 391f;
    [Tooltip("Gravidade do jogador quando está saltando no ar")]
    public float gravityJump = 1.2f;
    [Tooltip("Gravidade do jogador ao deslizar")]
    public float gravitySlide = 5f;
    [Tooltip("A força da bala quando o jogador a joga")]
    public float throwForce = 300f;
    private float gravityNormal;

    private bool isGrounded = true;

    [Header("Controle de Animação")]
    [Tooltip("Parâmetros do animetor, úteis para o player personalizado")]
    public string isGroundBool = "isGround";
    private Animator anim;
    private Rigidbody2D rig;
    private bool die = false;
    public GameObject btnJump;
    public bool buttonPressed;

    [Tooltip("Check ground point, this must be under player feet ")]
    public Transform checkGround;
    [Tooltip("The layers that are considered is the ground")]
    public LayerMask LayerGround;

    private GameManagerController _GameController;
    private ButtonController _ButtonController;

    // Start is called before the first frame update
    void Start()
    {

        _GameController = FindObjectOfType(typeof(GameManagerController)) as GameManagerController;
        _ButtonController = FindObjectOfType(typeof(ButtonController)) as ButtonController;

        rig = GetComponent<Rigidbody2D>();
        gravityNormal = rig.gravityScale;       
        anim = GetComponent<Animator>();

        QualitySettings.vSyncCount = 0;
        QualitySettings.SetQualityLevel(0);
        Application.targetFrameRate = 60;

        StartCoroutine("MovimentaPlayer");
        // StartCoroutine("JumpPlayer");
    }

    // public void JumpPlayer()
    // {
    //     Debug.Log("comecou mesmo");
    //     Debug.Log(_ButtonController.buttonPressed);
        
    //     StartCoroutine("JumpPlayer");
    // }


    IEnumerator MovimentaPlayer()
    {
        speed += (0.06f + Time.deltaTime);
        transform.Translate(new Vector3(speed, 0, 0));
        yield return new WaitForSeconds(0.2f);

        if(speed <= 0.25)
        {
            StartCoroutine("MovimentaPlayer");
        }
        else
        {
            speed = 0;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if(_ButtonController.buttonPressed)
        {
            Jump();

        }
        else
        {   
            JumpOff();
        }

        anim.SetFloat("Height", rig.velocity.y);
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector3(speed, 0, 0));

        //check if the player grounded
        if (Physics2D.OverlapCircle(checkGround.transform.position, 0.2f, LayerGround))
        {
            anim.SetBool(isGroundBool, true);       //set animator
            isGrounded = true;

        }
        else
        {
            anim.SetBool(isGroundBool, false);      //set animator
            isGrounded = false;
        }
    }

    public void Jump()
    {
        if (!die)
        {  
            
            if (isGrounded)
            {
                _GameController.fxGame.PlayOneShot(_GameController.fxJump);
                rig.gravityScale = gravityJump;
                rig.velocity = Vector2.zero;
                rig.AddForce(new Vector2(0, jumpForce));
            }
        }
    }

    //Called by Controller UI and PC
    public void JumpOff()
    {
        rig.gravityScale = gravityNormal;
    }

}
