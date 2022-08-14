using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    SpriteRenderer SpriteRenderer;
    [SerializeField] Sprite SpriteX;
    [SerializeField] Sprite SpriteO;

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

    public void ChangeMark(char newMark)
    {

        if(IsEmpty())
        {
            if(newMark == 'X')
            {
                Mark = 'X';
                print("Called");
                SpriteRenderer.sprite = SpriteX;
            }
            else if(newMark == 'O')
            {
                Mark = 'O';
                SpriteRenderer.sprite = SpriteO;
            }
        }
       

    }

    public bool IsEmpty()
    {
        if (Mark == ' ')
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
