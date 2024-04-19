
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(Shop))]
public class ShopEditor : Editor
{
    private SerializedProperty itemsProperty;

    private void OnEnable()
    {
        itemsProperty = serializedObject.FindProperty("items");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(itemsProperty, true);

        if (GUILayout.Button("Add Item"))
        {
            AddNewItem();
        }

        serializedObject.ApplyModifiedProperties();
    }

    private void AddNewItem()
    {
        Shop shop = (Shop)target;
        if (shop != null)
        {
            shop.items.Add(new ShopManager());
        }
    }
}
#endif
