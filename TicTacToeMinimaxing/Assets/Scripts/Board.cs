using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]  Cell[] Cells = new Cell[9];
    [SerializeField] Player MyPlayer;
    [SerializeField] AI MyAI;


    private void Awake()
    {
        for (int i = 0; i < Cells.Length; ++i)
        {
            Cells[i].Index = i;
        }

            MyPlayer.PlayerMark = 'X';
            MyPlayer.PlayerTurn = true;
            MyAI.AIMark = 'O';
            MyAI.AITurn = false;
       
    }

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
     
    }

    public void MakeMove(int cell, char mark)
    {

        if (Cells[cell].ChangeMark(mark))
        {

            if(MyPlayer.PlayerTurn)
            {
       

                MyPlayer.PlayerTurn = false;
                MyAI.AITurn = true;
                
            }
            else if(MyAI.AITurn)
            {
              
                MyAI.AITurn = false;
                MyPlayer.PlayerTurn = true;
                
            }

        }
       

    }


    public char[] GetGameState()
    {
        char[] gameState = new char[Cells.Length];

        for(int i = 0; i < Cells.Length; ++i)
        {
            gameState[i] = Cells[i].Mark;
        }


        return gameState;

    }

 
}
