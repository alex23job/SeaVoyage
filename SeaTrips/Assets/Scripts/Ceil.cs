using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceil : MonoBehaviour
{
    [SerializeField] private Material[] maters;

    private LevelControl lc = null;
    private MeshRenderer mr;
    private bool isFree = true;

    public bool IsFree { get { return isFree; } }
    public int ID = 0;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mr.materials = new Material[] { maters[0] };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if (mr != null)
        {
            if (isFree) mr.materials = new Material[] { maters[1] };
            else mr.materials = new Material[] { maters[2] };
            if (lc != null)
            {
                lc.TranslatePos(transform.position);
            }
        }
    }

    private void OnMouseOver()
    {
        if (mr != null)
        {
            if (isFree) mr.materials = new Material[] { maters[1] };
            else mr.materials = new Material[] { maters[2] };
        }
    }

    private void OnMouseExit()
    {
        if (mr != null)
        {
            mr.materials = new Material[] { maters[0] };
        }
    }

    public void SetFree(bool zn)
    {
        isFree = zn;
    }

    public void SetLevelControl(LevelControl l, int num)
    {
        lc = l;
        ID = num;
    }
}
