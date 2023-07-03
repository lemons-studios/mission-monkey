using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;

public class Shob3rsToolsGUI : EditorWindow
{
    public Font TitleFont;
    public Texture LemonLogo;


    [MenuItem("Window/Shob3r's Editor Tools")]
    static void ShowWindow()
    {
        GetWindow<Shob3rsToolsGUI>("Shob3r's Editor Tools");
    }

    private void OnEnable()
    {
     //   LemonLogo = AssetDatabase.LoadAssetAtPath<Texture2D>("./Resources/LemonLogo.png");
    }


    void OnGUI()
    {
        if(!LemonLogo)
        {
            Debug.LogError("Assign Any Missing Assets to the script before running again");
            return;
        }

        GUIStyle MainHeaderStyle = new GUIStyle()
        {
            alignment = TextAnchor.MiddleCenter,
            normal = new GUIStyleState { textColor = new Color(255, 255, 255) }, //Placeholder Colour until i find a good one
            //font = TitleFont, //This is for later when i find a good font for the editor tools
            fontSize = (int)(position.width / 20),
            
        };
        GUIStyle FeatureLabelStyle = new GUIStyle()
        {
            alignment = TextAnchor.MiddleLeft,
            fontSize = (int)(position.width / 30),
            normal = new GUIStyleState { textColor = new Color(255,255,255)}, //Another Placeholder colour for laater

        };
        GUIStyle CreditsStyle = new GUIStyle()
        {
            normal = new GUIStyleState { textColor = new Color(55,55,55)},
            fontSize = (int)(position.width / 50),
            alignment = TextAnchor.LowerCenter,
        };

        GUIStyle MenuButtonStyle = new GUIStyle()
        {
            fontSize = (int)(position.width / 50),
            normal = new GUIStyleState { textColor = new Color(255,255,255)},
            alignment = TextAnchor.MiddleRight,
        };
        GUILayout.BeginHorizontal();
        GUI.DrawTexture(new Rect(0, 0, 0, 0), LemonLogo, ScaleMode.ScaleToFit);
        GUILayout.Label("Shob3r's Editor Tools", MainHeaderStyle);
        GUILayout.EndHorizontal();

        // Material mass assign column
        GUILayout.BeginHorizontal();
        GUILayout.Label("Material Mass Assign", FeatureLabelStyle);
        if(GUILayout.Button(">"))
        {
            Debug.Log("Clicked");
        }
        GUILayout.EndHorizontal();
        
        GUILayout.Label("v0.0.1. © 2023 Lemon Studios. Licensed under the MIT License", CreditsStyle);
    }
}
