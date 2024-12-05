using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    [SerializeField] private GameObject islandQwMiniPrefab;
    [SerializeField] private GameObject islandQwPrefab;
    [SerializeField] private GameObject islandRect1Prefab;
    [SerializeField] private GameObject islandRect2Prefab;
    [SerializeField] private GameObject islandQwRivPrefab;
    [SerializeField] private GameObject islandQuestPrefab;
    [SerializeField] private GameObject islandHalfPrefab;
    [SerializeField] private GameObject islandTailPrefab;
    [SerializeField] private GameObject islandTail4Prefab;
    [SerializeField] private GameObject lightHousePrefab;
    [SerializeField] private GameObject tilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TranslatePos(Vector3 pos)
    {
        //txtDebug.text = $"freeCeils x={pos.x} y={pos.z}";
    }

}
