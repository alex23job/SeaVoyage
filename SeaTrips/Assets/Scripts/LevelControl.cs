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
    [SerializeField] private GameObject fogPrefab;

    [SerializeField] private DiceControl diceControl;

    private GameObject[] arrTile;
    private GameObject[] arrFog;
    // Start is called before the first frame update
    void Start()
    {
        GenerateBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateBoard()
    {
        int i;
        Vector3 pos = Vector3.zero;
        pos.y = 0.55f;
        //pos.y = 3.55f;
        arrTile = new GameObject[143];
        for (i = 0; i < 143; i++)
        {
            pos.x = -12 + 2 * (i % 13);
            pos.z = 14 - 2 * (i / 13);
            arrTile[i] = Instantiate(tilePrefab, pos, Quaternion.identity);
            arrTile[i].GetComponent<Ceil>().ID = i;
        }
        /*arrFog = new GameObject[143];
        pos.y = 2.55f;
        for (i = 0; i < 143; i++)
        {
            pos.x = -12 + 2 * (i % 13);
            pos.z = 12 - 2 * (i / 13);
            arrFog[i] = Instantiate(fogPrefab, pos, Quaternion.identity);
            //arrFog[i].GetComponent<Ceil>().ID = i;
        }*/
    }


    public void TranslatePos(Vector3 pos)
    {
        //txtDebug.text = $"freeCeils x={pos.x} y={pos.z}";
    }

    public void TurnDice()
    {
        diceControl.TurnDice();
    }

}
