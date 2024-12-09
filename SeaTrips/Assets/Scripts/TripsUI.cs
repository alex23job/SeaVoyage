using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TripsUI : MonoBehaviour
{
    [SerializeField] private Text txtCountSteps;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("HarborScene");
    }

    public void ViewContSteps(int n)
    {
        txtCountSteps.text = n.ToString();
    }

}
