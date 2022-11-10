using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RenameLevelsByNumber : MonoBehaviour
{
    [SerializeField] private TMP_Text[] txtLevels;

    // Start is called before the first frame update
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 1);
        for(int i = 0; i < txtLevels.Length; i++)
        {
            txtLevels[i] = GetComponentsInChildren<TMP_Text>()[i];
            if(i + 1 > levelAt)
            {
                txtLevels[i].text = "Bloqueado";
            }else
            {
                txtLevels[i].text = "Nível " + (i + 1).ToString();
            }
        }
    }
}

