using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStackSpawner : MonoBehaviour
{
    public GameObject Stack;
    private GameObject currentStack;
    // Start is called before the first frame update
    void Start()
    {
        CreateNewCrates();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Stack != null) 
            {
                DeleteOldCrates();
                CreateNewCrates();
            }
            
        }
    }

    void CreateNewCrates()
    {
        currentStack = Instantiate(Stack, new Vector3(0,0,0), Quaternion.identity);
    }
    void DeleteOldCrates() 
    {
        if (Stack != null) 
        { 
            Destroy(currentStack);
        }       
    }
}
