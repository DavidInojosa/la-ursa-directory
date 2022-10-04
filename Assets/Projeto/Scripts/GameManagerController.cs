using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameManagerController : MonoBehaviour
{

    // Propriedade do Chão
    [Header("Configuração do Chão")]
    public float        ChaoDestruido;
    public float        ChaoTamanho;
    public GameObject   ChaoPrefab;
    public float        ChaoVelocidade;

    [Header("Configuração da Nuvem")]
    public float        NuvemTempo;
    public GameObject   NuvemPrefab;
    public bool         NuvemGerada = false;
    public float        NuvemVelocidade;

    [Header("Configuração da Nuvem2")]
    public float        Nuvem2Tempo;
    public GameObject   Nuvem2Prefab;
    public bool         Nuvem2Gerada = false;
    public float        Nuvem2Velocidade;

    [Header("Configuração dos Obstaculos")]
    public float        ObstaculoTempo;
    public GameObject   ObstaculoPrefab;
    public bool         ObstaculoGerado = false;
    public float        ObjetoVelocidade;

    [Header("Controles do Player")]
    public int VidasPlayer = 3;
    public float MoedasTempo;
    public GameObject MoedasPrefab;
    
    [SerializeField]
    public int PontosPlayer;
    public Text txtPontos;
    public Text txtVidas;
    public Text txtMetros;
    public Text txtPontosGameOver;
    public Text txtMetrosGameOver;
    

    [Header("Controle de Distância")]
    public int BaseMetrosPoint = 1;
    public int MetrosMutiplicador = 1;
    public int MetrosAtual = 0;

    // Controle de Audios e Efeitos
    [Header("Sons e Efeitos")]
    public AudioSource fxGame;
    public AudioSource fxGameOver;
    public AudioClip fxMoedaColetada;
    public AudioClip fxJump;

    
    private void Start()
    {
        StartCoroutine("SpawnNuvem");
        StartCoroutine("SpawnNuvem2");
        StartCoroutine("SpawnObstaculo");
        StartCoroutine("SpawnMoedas");
        StartCoroutine("MetrosPercorrido");
    }

    IEnumerator SpawnObstaculo()
    {
        
        if(ObstaculoGerado == false)
        {
            StartCoroutine("SpawnMoedas");
        }
        yield return new WaitForSeconds(ObstaculoTempo);

        GameObject ObjetoSpaw = Instantiate(ObstaculoPrefab);
        StartCoroutine("SpawnObstaculo");
        ObstaculoGerado = false;

    }

    IEnumerator SpawnNuvem()
    {        
        yield return new WaitForSeconds(NuvemTempo);
        GameObject NuvemSpawn = Instantiate(NuvemPrefab);
        StartCoroutine("SpawnNuvem");
    }

    IEnumerator SpawnNuvem2()
    {        
        yield return new WaitForSeconds(Nuvem2Tempo);
        GameObject Nuvem2Spawn = Instantiate(Nuvem2Prefab);
        StartCoroutine("SpawnNuvem2");
    }

    IEnumerator SpawnMoedas()
    {
        int moedasaleatorias = Random.Range(0, 1);
        for (int conta =0 ;  conta <= moedasaleatorias; conta++)
        {
            yield return new WaitForSeconds(MoedasTempo);
            GameObject ObjetoSpaw = Instantiate(MoedasPrefab);
            ObjetoSpaw.transform.position = new Vector3(transform.position.x + 10f, transform.position.y + 0.5f, 0);
        }
        //Debug.Log(moedasaleatorias.ToString());
        

        if (ObstaculoGerado == false)
        {
            StartCoroutine("SpawnMoedas");
            ObstaculoGerado = true;
        }

    }

    public void Pontos(int qtdPontos)
    {
        PontosPlayer += qtdPontos;
        txtPontos.text = PontosPlayer.ToString();
    }

    void AtualizaMetros(int metrosAdicionado)
    {
        MetrosAtual += metrosAdicionado * 1;
        txtMetros.text = MetrosAtual.ToString() + " m";
    }

    private IEnumerator MetrosPercorrido()
    {
        while(true)
        {
            AtualizaMetros(BaseMetrosPoint);

            if((MetrosAtual % 100) == 0)
            {
               ChaoVelocidade++;

                if ((MetrosAtual % 200) == 0)
                {
                    ObstaculoTempo -= 0.30f;
                }

            }
            
            yield return new WaitForSeconds(0.1f);
        }
    }
   
}
