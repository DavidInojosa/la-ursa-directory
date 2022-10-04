using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoController : MonoBehaviour
{
    private GameManagerController _GameController;
    public bool _chaoInstanciado = false;

    private void Start()
    {
        _GameController = FindObjectOfType(typeof(GameManagerController)) as GameManagerController;

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
    }
    // Update is called once per frame
    void Update()
    {

        if (_chaoInstanciado == false)
        {
            if(transform.position.x <= 0)
            {
                _chaoInstanciado = true;
                GameObject ObjetoTemporario = Instantiate(_GameController.ChaoPrefab);
                ObjetoTemporario.transform.position = new Vector3(transform.position.x - 0.5f + _GameController.ChaoTamanho, transform.position.y, 0);
            }
        }

        if(transform.position.x < _GameController.ChaoDestruido)
        {
            Destroy(this.gameObject);
        }

    }

    private void FixedUpdate()
    {
        MoveChao();

    }
    void MoveChao()
    {
        transform.Translate(Vector2.left * _GameController.ChaoVelocidade * Time.deltaTime);  // Sempre usado Time.smoothDeltaTime
    }
}
