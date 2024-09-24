using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public TMP_InputField text;
    public TMP_Text magic;
    
    private void Start()
    {
        LoadLastName();
        MenuBest();
    }

    //按钮Start
    public void StartNew()
    {
        SceneManager.LoadScene(1);
       // DataManager.Instance.SaveName();  //在OnEndEdit事件中调用
    }

    //按钮Quit
    public void Quit()
    {
#if  UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else 
        Application.Quit();
#endif
    }
    
    //触发save name
    public void SaveNameClicked()
    {
        DataManager.Instance.playerName = text.text;
        DataManager.Instance.SaveAllData();
    }

    //加载name
    public void LoadLastName()
    {
        text.text = DataManager.Instance.playerName;
    }
    
    //Menu界面bestScore
    void MenuBest()
    {
        magic.text = $"Magic : {DataManager.Instance.bestPlayer} : {DataManager.Instance.bestScore}";
    }
}
