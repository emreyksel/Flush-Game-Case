using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GridEditor : EditorWindow
{
    private Vector3 firstGridPosition;
    private Transform parent;
    public GameObject tile;
    private Vector3 pos;
    private int hor;
    private int ver;
    private float space;

    [MenuItem("Window/Grid")]
    public static void ShowWindow()
    {
        GetWindow<GridEditor>("GridEditor");
    }

    private void OnGUI()
    {
        tile = (GameObject)EditorGUILayout.ObjectField("", tile, typeof(GameObject), true);
        //parent = (Transform)EditorGUILayout.ObjectField("", parent, typeof(Transform), true);
        parent = GameObject.FindGameObjectWithTag("Grids").transform;

        GUILayout.Label("First Tile Pos", EditorStyles.boldLabel);
        firstGridPosition = EditorGUILayout.Vector3Field("", firstGridPosition);

        GUILayout.Label("Horizontal Tile", EditorStyles.boldLabel);
        hor = EditorGUILayout.IntField(hor);

        GUILayout.Label("Vertical Tile", EditorStyles.boldLabel);
        ver = EditorGUILayout.IntField(ver);

        GUILayout.Label("Space", EditorStyles.boldLabel);
        space = EditorGUILayout.FloatField(space);       

        if (GUILayout.Button("Create"))
        {
            for (int i = 0; i < ver; i++)
            {
                GameObject g = Instantiate(tile);
                pos = firstGridPosition - new Vector3(0, 0, space) * i;
                g.transform.position = pos;
                g.transform.SetParent(parent);

                for (int j = 0; j < hor-1; j++)
                {
                    GameObject g1 = Instantiate(tile);
                    pos = g.transform.position  + new Vector3(space, 0, 0) * (j + 1);
                    g1.transform.position = pos;
                    g1.transform.SetParent(parent);
                }
            }
        }
    }
}
