using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public UnityEngine.UI.Button[] btnLevels;
    public GameObject[] imgLevels;
    public GameObject[] triangleLevels;

    public Sprite imgLock, imgEmpty, imgTriangleFase1, imgTriangleFase2, imgTriangleBlocked;

    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0; i < btnLevels.Length; i++)
        {
            int index = i;
            btnLevels[i] = GetComponentsInChildren<UnityEngine.UI.Button>()[i];
            btnLevels[i].onClick.AddListener(() => LoadLevelByIndex((i - i) + (index + 1)));
        }
        imgLevels = GameObject.FindGameObjectsWithTag("ImageLock");
        triangleLevels = GameObject.FindGameObjectsWithTag("TriangleLevel");
    }

    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 1);

        for(int i = 0; i < btnLevels.Length; i++)
        {
            if(i + 1 > levelAt)
            {
                btnLevels[i].interactable = false;
                imgLevels[i].GetComponent<UnityEngine.UI.Image>().sprite = imgLock;
                triangleLevels[i].GetComponent<UnityEngine.UI.Image>().sprite = imgTriangleBlocked;
            }else
            {
                imgLevels[i].GetComponent<UnityEngine.UI.Image>().sprite = imgEmpty;
                if( i == 0){
                    triangleLevels[i].GetComponent<UnityEngine.UI.Image>().sprite = imgTriangleFase1;
                }
                if( i == 1){
                    triangleLevels[i].GetComponent<UnityEngine.UI.Image>().sprite = imgTriangleFase2;
                }
                if( i > 1){
                    triangleLevels[i].GetComponent<UnityEngine.UI.Image>().sprite = imgTriangleBlocked;
                }
            }
        }
    }

    void LoadLevelByIndex(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1;
    }
}
