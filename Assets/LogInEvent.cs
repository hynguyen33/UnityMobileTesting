using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;

public class LogInEvent : MonoBehaviour
{
    private UIDocument logInDocument;
    
    private TextField userName;
    private TextField password;
    private TextField confirmPassword;
    private Label checkUsername;
    
    private Button loginButton;
    private Button exitButton;
    public string localPassword;
    public string localConfirmPassword;
    public string[] userNameList = {"h","son","alex","dario","anya","Karl","Youfei"};
    
    void OnEnable()
    {
        logInDocument = GetComponent<UIDocument>();
        if (logInDocument == null)
        {
            Debug.LogError("no log in document found");
        }
        checkUsername =logInDocument.rootVisualElement.Q("CheckUserName") as Label;

        userName = logInDocument.rootVisualElement.Q("UserName") as TextField;
        password = logInDocument.rootVisualElement.Q("Password") as TextField;
        confirmPassword = logInDocument.rootVisualElement.Q("ConfirmPassword") as TextField;
        
        loginButton = logInDocument.rootVisualElement.Q("LogInButton") as Button;
        exitButton = logInDocument.rootVisualElement.Q("ExitButton") as Button;
        // userName.RegisterValueChangedCallback(evt =>
        // {
        //     Debug.Log(userName.text);
        //     foreach (string item in userNameList)
        //     {
        //         if (item == )
        //         {
        //             Debug.Log("correct username");
        //             checkUsername.text = "Correct User Name";
        //         }
        //         else
        //         {
        //             Debug.Log("incorrect username");
        //             checkUsername.text = "Incorrect User Name";
        //             loginButton.SetEnabled(false);
        //         }
        //     }
        //     
        // });
        password.RegisterValueChangedCallback(evt =>
        {
            if (evt.target is Label)
            {
                localPassword = password.text;
            }
        });
        confirmPassword.RegisterValueChangedCallback(evt =>
        {
            if (evt.target is Label)
            {
                localConfirmPassword = confirmPassword.text;
            }
        });
        if (loginButton != null)
        {
            Debug.Log("Log in Button found");
            loginButton.clickable.clicked += () =>
            {
                if (localPassword == localConfirmPassword)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
                }
                Debug.Log("Clicked");
            };
        }
        if (exitButton != null)
        {
            Debug.Log("exit Button found");
            loginButton.clickable.clicked += () =>
            {
                Application.Quit();
            };
        }
        // loginButton.RegisterCallback<ClickEvent>(OnButtonClick);
    }

    // public void OnButtonClick(ClickEvent evt)
    // {
    //     
    // }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
