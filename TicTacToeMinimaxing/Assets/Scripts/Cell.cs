using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    SpriteRenderer SpriteRenderer;
    [SerializeField] Sprite SpriteX;
    [SerializeField] Sprite SpriteO;

    public char Mark { get; set; } = ' ';

    public int Index { get; set; }
    

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public bool ChangeMark(char newMark)
    {

        if(IsEmpty())
        {
            if(newMark == 'X')
            {
                Mark = 'X';
                
                SpriteRenderer.sprite = SpriteX;
                return true;
            }
            else if(newMark == 'O')
            {
                Mark = 'O';
                SpriteRenderer.sprite = SpriteO;
                return true;
            }
        }
       
        return false; 
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

    public void ClearCell()
    {
        Mark = ' ';
    }

}
