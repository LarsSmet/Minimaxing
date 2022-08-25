using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public bool AITurn { get; set; } = false;
    public char AIMark { get; set; } = 'O';
    private char PlayerMark = 'X';



    private Board MyBoard;

    // Start is called before the first frame update
    void Start()
    {
        MyBoard = FindObjectOfType<Board>();

    }

    // Update is called once per frame
    void Update()
    {
       HandleAI();
    }

    void HandleAI()
    {
        HandleTurn();
    }

    void HandleTurn()
    {
        if (AITurn)
        {
            MyBoard.MakeMove(FindBestMove(), AIMark);
        }
    }

    public int FindBestMove()
    {
        float bestScore = Mathf.NegativeInfinity;
        int bestMove = 0;

        char[] gameState = MyBoard.GetGameState();


        for (int i = 0; i < gameState.Length; ++i)
        {
           

            if(gameState[i] == ' ') //if spot is available
            {
                
                gameState[i] = AIMark;
                float score = MiniMax(gameState, false);
                gameState[i] = ' '; //undo move

                if(score > bestScore)
                {
                    bestScore = score;
                    bestMove = i;

                }

            }
        }

       
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

        for (int i = 0; i < 3; ++i) //col match
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

        switch (winCheck) //if winner matches AI mark return 1, if winner matches player mark return -1, In case of a tie, return 0. If no winner yet, continue the minimax.
        {
            case 'X':
                if(AIMark == 'X') 
                {
 
                    return 1;
                    
                }
                else
                {
     
                    return -1;
                }
            case 'O':
                if (AIMark == 'O')
                {
                   
                    return 1;
                }
                else
                {
              
                    return -1;
                }
            case 'T':
           
                return 0;
            case 'N':
                break;
                
        }

        if(isMaximizer)
        {
            float bestScore = Mathf.NegativeInfinity;

            for(int i = 0; i < gameState.Length; ++i)
            {
               
                if(gameState[i] == ' ') //check if cell is empty
                {
                    gameState[i] = AIMark;
                    float score = MiniMax(gameState, false); //do minimax again
                    gameState[i] = ' '; //undo move

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
                    float score = MiniMax(gameState, true); //do minimax again
                    gameState[i] = ' '; //undo move

                    bestScore = Mathf.Min(bestScore, score);


                }
            }
            return bestScore;

        }


        return 0.0f; 
    }



}
