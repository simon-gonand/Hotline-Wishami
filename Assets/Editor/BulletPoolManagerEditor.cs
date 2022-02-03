using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BulletPoolManager))]
public class BulletPoolManagerEditor : Editor
{
    SerializedProperty self;
    SerializedProperty bullets;
    SerializedProperty prefabReference;
    SerializedProperty poolSize;
    SerializedProperty startPoint;

    SerializedProperty foldoutBoolRef, foldoutBoolPool;

    private void OnEnable()
    {
        self = serializedObject.FindProperty("self");
        bullets = serializedObject.FindProperty("bullets");
        prefabReference = serializedObject.FindProperty("prefabReference");
        poolSize = serializedObject.FindProperty("poolSize");
        foldoutBoolRef = serializedObject.FindProperty("foldoutBoolRef");
        foldoutBoolPool = serializedObject.FindProperty("foldoutBoolPool");
        startPoint = serializedObject.FindProperty("startPoint");

        Undo.undoRedoPerformed += RebuildPool;
    }

    private void OnDisable()
    {
        Undo.undoRedoPerformed -= RebuildPool;
    }

    private void RebuildPool()
    {
        serializedObject.ApplyModifiedPropertiesWithoutUndo();
        serializedObject.Update();

        while (bullets.arraySize > 0)
        {
            SerializedProperty cur = bullets.GetArrayElementAtIndex(0);
            Object obj = cur.objectReferenceValue;

            if (obj == null) bullets.DeleteArrayElementAtIndex(0);
            else
            {
                DestroyImmediate((obj as Bullets).gameObject);
                bullets.DeleteArrayElementAtIndex(0);
            }
        }

        for (int i = 0; i < poolSize.intValue; ++i)
        {
            GameObject go = PrefabUtility.InstantiatePrefab(prefabReference.objectReferenceValue as GameObject) as GameObject;
            Transform t = go.transform;
            t.SetParent(self.objectReferenceValue as Transform);
            t.localRotation = Quaternion.identity;
            t.localPosition = Vector3.zero;
            go.SetActive(false);

            Bullets bulletScript = go.GetComponent<Bullets>();
            BulletPoolManager targetScript = target as BulletPoolManager;
            bulletScript.bulletPoolManager = targetScript;
            bulletScript.character = targetScript.self.parent;
            bullets.InsertArrayElementAtIndex(bullets.arraySize);
            bullets.GetArrayElementAtIndex(bullets.arraySize - 1).objectReferenceValue = bulletScript;
        }

        serializedObject.ApplyModifiedPropertiesWithoutUndo();
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        foldoutBoolPool.boolValue = EditorGUILayout.Foldout(foldoutBoolPool.boolValue, "Pool", true);
        if (foldoutBoolPool.boolValue)
        {
            GUILayout.BeginHorizontal();
            EditorGUI.indentLevel += 1;
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(poolSize);
            if (EditorGUI.EndChangeCheck())
            {
                if (poolSize.intValue < 0) poolSize.intValue = 0;
            }
            EditorGUI.indentLevel -= 1;

            if (GUILayout.Button("Rebuild Pool", EditorStyles.miniButton))
                RebuildPool();
            GUILayout.EndHorizontal();
        }

        EditorGUILayout.Space();

        foldoutBoolRef.boolValue = EditorGUILayout.Foldout(foldoutBoolRef.boolValue, "References", true);
        if (foldoutBoolRef.boolValue)
        {
            EditorGUI.indentLevel += 1;
            EditorGUILayout.PropertyField(self);
            EditorGUILayout.PropertyField(prefabReference);
            EditorGUILayout.PropertyField(startPoint);
            EditorGUI.indentLevel -= 1;
        }

        serializedObject.ApplyModifiedProperties();
    }
}
