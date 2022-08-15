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
        if (AITurn)
        {
            print("update make move");

            MyBoard.MakeMove(FindBestMove(), AIMark);
        }

    }

    public int FindBestMove()
    {
        float bestScore = Mathf.NegativeInfinity;
        int bestMove = 0;

        char[] gameState = MyBoard.GetGameState();

        print("FINDBESTMOVE");

        for (int i = 0; i < gameState.Length; ++i)
        {
            print("FINDBESTMOVE FOR LOOP");

            if(gameState[i] == ' ') //if spot is available
            {
                
                gameState[i] = AIMark;
                float score = MiniMax(gameState, false);
                gameState[i] = ' ';

                if(score > bestScore)
                {
                    bestScore = score;
                    bestMove = i; 
                }

            }
        }

        Debug.Log("BEst move is: ");
        Debug.Log(bestMove);

     return bestMove;

    }

    char CheckForWin(char[] gameState)
    {
        char winner = 'N';

        for (int i = 0; i < 9; i += 3) //row match
        {


            if ((gameState[i] == gameState[i + 1]) && gameState[i] == gameState[i + 2])
            {
                //set winner by taking the character from the cell
                //if char is ' ' -> empty cell so no winner
                if (gameState[i] != ' ')
                {
                    winner = gameState[i];
                }
            }



        }

        for (int i = 0; i < 3; ++i) //row match
        {


            if ((gameState[i] == gameState[i + 3]) && gameState[i] == gameState[i + 6])
            {
                //set winner by taking the character from the cell
                //if char is ' ' -> empty cell so no winner
                if (gameState[i] != ' ')
                {
                    winner = gameState[i];
                };
            }

        }

        if ((gameState[0] == gameState[4] && gameState[0] == gameState[8]) || (gameState[2] == gameState[4] && gameState[2] == gameState[6]))
        {

            //set winner by taking the character from the cell
            //if char is ' ' -> empty cell so no winner
            if (gameState[4] != ' ')
            {
                winner = gameState[4];
            }


        }

        

        if(winner != 'X' && winner != 'O')
        {
            int emptySpots = 0;

            foreach (char cell in gameState)
            {
                if (cell == ' ')
                {
                    ++emptySpots;
                }
            }

            if (emptySpots == 0)
            {
                winner = 'T'; //T means tie
            }
            else
            {
                winner = 'N'; //N means no winner yet
            }
        }

        return winner;

    }
    private float MiniMax(char[] gameState, bool isMaximizer)
    {
        char winCheck = CheckForWin(gameState);
        Debug.Log(winCheck);

        switch (winCheck) //if winner matches AI mark return 1, if winner matches player mark return -1, In case of a tie, return 0.5. If no winner yet, continue the minimax.
        {
            case 'X':
                if(AIMark == 'X') 
                {
                    Debug.Log("X won");
                    return 1;
                }
                else
                {
                    Debug.Log("o won");
                    return -1;
                }
            case 'O':
                if (AIMark == 'O')
                {
                    Debug.Log("O won");
                    return 1;
                }
                else
                {
                    Debug.Log("X won");
                    return -1;
                }
            case 'T':
                Debug.Log("TIE");
                return 0.0f;
                
        }

        if(isMaximizer)
        {
            float bestScore = Mathf.NegativeInfinity;

            for(int i = 0; i < gameState.Length; ++i)
            {
                Debug.Log("gameState.Length");
                Debug.Log(gameState.Length);
                if(gameState[i] == ' ') //check if cell is empty
                {
                    gameState[i] = AIMark;
                    float score = MiniMax(gameState, false);
                    gameState[i] = ' ';

                    bestScore = Mathf.Max( bestScore, score);


                }
            }
            return bestScore;
        }
        else if(!isMaximizer)
        {
            float bestScore = Mathf.Infinity;

            for (int i = 0; i < gameState.Length; ++i)
            {
                if (gameState[i] == ' ') //check if cell is empty
                {
                    gameState[i] = PlayerMark;
                    float score = MiniMax(gameState, true);
                    gameState[i] = ' ';

                    bestScore = Mathf.Min(bestScore, score);


                }
            }
            return bestScore;

        }


        return 0.0f; //remove later
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
