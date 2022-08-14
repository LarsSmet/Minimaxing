using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public bool AITurn { get; set; } = false;
    public char AIMark { get; set; } = ' ';
    private char PlayerMark = ' ';


    private Board MyBoard;

    // Start is called before the first frame update
    void Start()
    {
        MyBoard = FindObjectOfType<Board>();

        //set in start because AIMark is set in awake in board class
        if(AIMark == 'X')
        {
            PlayerMark = 'O';

        }
        else if(AIMark == 'O')
        {
            PlayerMark = 'X';
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(AITurn)
        {
            MyBoard.MakeMove(FindBestMove(), AIMark);
        }

    }

    public int FindBestMove()
    {
        float bestScore = Mathf.NegativeInfinity;
        int bestMove;

        char[] gameState = MyBoard.GetGameState();

        for (int i = 0; i < gameState.Length; ++i)
        {
            if(gameState[i] == ' ') //if spot is available
            {
                
                gameState[i] = AIMark;
                float score = MiniMax(gameState);
               
                // compare score?

            }
        }

        return  Random.Range(0, 9); ;

    }
    private float MiniMax(char[] gameState)
    {
        return -1.0f; //remove later
    }


    //    public int FindBestMove()
    //{
    //    //float currentHighestScore = Mathf.NegativeInfinity;
    //    //int bestMove = 0;

    //    //foreach(Cell cell in MyBoard.Cells)
    //    //{
    //    //    if(cell.IsEmpty())
    //    //    {
    //    //        MyBoard.MakeMove(cell.Index, AIMark);
    //    //        float score = MiniMax();
    //    //        cell.ClearCell();

    //    //    }
    //    //}



    //    //Board newBoard = MyBoard.m;
    //    //newBoard.GetCells()[0].ChangeMark(AIMark);
    //    //print("newboard mark:");
    //    //print(newBoard.GetCells()[0].Mark);
    //    //print("  old board mark:");
    //    //print(MyBoard.GetCells()[0].Mark);


    //    return -1; //remove later
    //}

    //private float MiniMax()
    //{
    //    return -1.0f; //remove later
    //}

}
