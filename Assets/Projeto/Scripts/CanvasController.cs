using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    private GameManagerController _GameController;
    public int nextSceneLoad;

    // Canvas
    [Header("Game Pausado")]
    public GameObject btnPause;
    public GameObject PanelPause;
    bool isPaused = false;
   
    // Canvas
    [Header("Fim do Jogo Canvas")]
    public GameObject PanelGameOver;

    [Header("Ganhou o Jogo Canvas")]
    public GameObject PanelGameWin;

    private void Start()
    {
        _GameController = FindObjectOfType(typeof(GameManagerController)) as GameManagerController;
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(0);
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

    public void GameWin()
    {
        _GameController.fxGame.mute = true;
        _GameController.fxGame.Stop();
       
        _GameController.fxGameOver.mute = false;
        _GameController.fxGameOver.Play();
        

        Time.timeScale = 0;
        _GameController.txtPontosGameWin.text = _GameController.txtPontos.text;
        _GameController.txtMetrosGameWin.text = _GameController.txtMetros.text;

        PanelGameWin.SetActive(true);
        btnPause.SetActive(false);

        if(nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextSceneLoad);
        }

    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextSceneLoad);
        Time.timeScale = 1;
    }

}
