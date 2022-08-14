using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    SpriteRenderer SpriteRenderer;

    public char Mark { get; set; } = ' ';

    

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }



}
