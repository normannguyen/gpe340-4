using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class WeightedItems
{
    [SerializeField, Tooltip("The object selected by this choice.")]
    private Object value;
    [SerializeField, Tooltip("The chance to select the value.")]
    private double chance = 1.0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
[CustomPropertyDrawer(typeof(WeightedItems))]
public class WeightedObjectDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        var objectRect = new Rect(position.x, position.y, position.width - 40f, position.height);
        var chanceRect = new Rect(position.x + position.width - 40f, position.y, 40f, position.height);

        EditorGUI.PropertyField(objectRect, property.FindPropertyRelative("value"), GUIContent.none);
        EditorGUI.PropertyField(chanceRect, property.FindPropertyRelative("chance"), GUIContent.none);

        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }
}