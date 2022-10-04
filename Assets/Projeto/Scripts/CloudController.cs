using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{

    private GameManagerController _GameController;
    private Rigidbody2D NuvemRB;

    // Start is called before the first frame update
    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameManagerController)) as GameManagerController;

        NuvemRB = GetComponent<Rigidbody2D>();
        NuvemRB.velocity = new Vector2(-6f,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < _GameController.ChaoDestruido)
        {
            Destroy(this.gameObject);
        }
       
    }

    private void FixedUpdate()
    {
        MoveNuvem();

    }
    void MoveNuvem()
    {
        transform.Translate(Vector2.left * _GameController.NuvemVelocidade * Time.smoothDeltaTime);
    }
}
