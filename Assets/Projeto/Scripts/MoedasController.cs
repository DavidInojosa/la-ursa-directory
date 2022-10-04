using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoedasController : MonoBehaviour
{
    private GameManagerController _GameController;
    private CanvasController _CanvasController;
    private Rigidbody2D ObstaculoRB;

    // Start is called before the first frame update
    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameManagerController)) as GameManagerController;
        _CanvasController = FindObjectOfType(typeof(CanvasController)) as CanvasController;
        ObstaculoRB = GetComponent<Rigidbody2D>();
        ObstaculoRB.velocity = new Vector2(-6f, 0);
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
        if (collision.tag == "Player")
        {
            _GameController.Pontos(1);
            _GameController.fxGame.PlayOneShot(_GameController.fxMoedaColetada);
            Destroy(this.gameObject);
            if(_GameController.PontosPlayer >= 20){
                _CanvasController.GameOver();
            }
        }
    }
}
