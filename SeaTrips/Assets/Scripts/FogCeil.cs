using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogCeil : MonoBehaviour
{
    [SerializeField] private Material[] maters;

    private MeshRenderer mr;
    private bool isVisible = true;

    public bool IsFree { get { return isVisible; } }

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        //mr.materials = new Material[] { maters[0] };
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        if (mr != null)
        {
            if (isVisible) mr.materials = new Material[] { maters[1] };
            else mr.materials = new Material[] { maters[2] };
/*            if (lc != null)
            {
                lc.TranslatePos(transform.position);
            }
*/        }
    }

    private void OnMouseOver()
    {
        if (mr != null)
        {
            if (isVisible) mr.materials = new Material[] { maters[1] };
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
        isVisible = zn;
    }
}
