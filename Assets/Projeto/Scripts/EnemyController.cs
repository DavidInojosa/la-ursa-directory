using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private GameManagerController _GameController;
    private CanvasController _CanvasController;
    private CameraShaker _CameraShaker;
    private Rigidbody2D EnemyRB;

    // Start is called before the first frame update
    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameManagerController)) as GameManagerController;
        _CanvasController = FindObjectOfType(typeof(CanvasController)) as CanvasController;
        _CameraShaker = FindObjectOfType(typeof(CameraShaker)) as CameraShaker;

        EnemyRB = GetComponent<Rigidbody2D>();
        Debug.Log(EnemyRB.velocity);
        // EnemyRB.velocity = new Vector2(-8f,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < _GameController.ChaoDestruido)
        {
            Destroy(this.gameObject);
        }
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _GameController.VidasPlayer--;
            if (_GameController.VidasPlayer <= 0)
            {
                _GameController.txtVidas.text = "0";
                _GameController.VidasPlayer = 0;
                //Debug.Log("Fim do Jogo");
                _CanvasController.GameOver();
            }
            else
            {
                _GameController.txtVidas.text = (_GameController.VidasPlayer).ToString();
                _CameraShaker.ShakeIt();
                //Debug.Log("Perdeu uma Vida!");
            }
        }
    }

    private void FixedUpdate()
    {
        MoveObjeto();

    }
    void MoveObjeto()
    {
        transform.Translate(Vector2.left * _GameController.EnemyVelocidade * Time.smoothDeltaTime);
    }
}
