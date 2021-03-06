using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

[CustomEditor(typeof(testwork))]
public class testInspector : Editor
{
    private testwork _testwork;
    private VisualElement _root;
    private VisualTreeAsset _visualTree;
    
    
    
    private void OnEnable()
    {
        _testwork = (testwork) target; //as casting target as script
        _root = new VisualElement();
        _visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/testcustominspector/UITK/custominspector.uxml");
        
        //load style
        StyleSheet styleSheet =
            AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/testcustominspector/UITK/styleinspector.uss");
        _root.styleSheets.Add(styleSheet);
    }

    public override VisualElement CreateInspectorGUI()
    {
        _root = _visualTree.Instantiate();

        var testval2 = _root.Q<IntegerField>("test2");
        var testval = _root.Q<FloatField>("test1");
        
        //var testval2 = _root.Q<DebugUI.IntField>("test2");
        
        /*
        var testval2 = _root.Q<FloatField>("test2");
        var progbar = _root.Q<ProgressBar>("progress");
        */

        //progbar.value = _testwork.TestFloat1 / _testwork.TestFloat2;
        
        //SerializedProperty objectName = _testwork.
        //SerializedObject so = new SerializedObject()
        //GameObject selectedObj = Selection.activeObject as GameObject;
        
        //SerializedObject so = new SerializedObject(selectedObj);
        //_root.Bind(so);
        
        
        
        testval.BindProperty(serializedObject.FindProperty("testFloat1"));
        testval2.BindProperty(serializedObject.FindProperty("testFloat2"));

        serializedObject.ApplyModifiedProperties();
        
        return _root;
    }
}
