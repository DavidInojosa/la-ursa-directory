using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    private GameManagerController _GameController;

    // Canvas
    [Header("Game Pausado")]
    public GameObject btnPause;
    public GameObject PanelPause;
    bool isPaused = false;

    // Canvas
    [Header("Fim do Jogo Canvas")]
    public GameObject PanelGameOver;

    private void Start()
    {
        _GameController = FindObjectOfType(typeof(GameManagerController)) as GameManagerController;
    }

    public void PauseAndPlay()
    {
        if(isPaused)
        {
            isPaused = false;
            Time.timeScale = 1;
            btnPause.SetActive(true);
            PanelPause.SetActive(false);
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0;
            btnPause.SetActive(false);
            PanelPause.SetActive(true);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Fase_1");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        if (EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
#endif
        Application.Quit();

    }

    public void GameOver()
    {
        _GameController.fxGame.mute = true;
        _GameController.fxGame.Stop();
       
        _GameController.fxGameOver.mute = false;
        _GameController.fxGameOver.Play();
        

        Time.timeScale = 0;
        _GameController.txtPontosGameOver.text = _GameController.txtPontos.text;
        _GameController.txtMetrosGameOver.text = _GameController.txtMetros.text;

        PanelGameOver.SetActive(true);
        btnPause.SetActive(false);

    }

}
