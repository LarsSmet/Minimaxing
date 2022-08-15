using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]  Cell[] Cells = new Cell[9];
    [SerializeField] Player MyPlayer;
    [SerializeField] AI MyAI;

    int Turn = 0;

    private void Awake()
    {
        for (int i = 0; i < Cells.Length; ++i)
        {
            Cells[i].Index = i;
        }

        foreach (Cell cell in Cells)
        {
            print(cell.Index);
        }

        //if result is 0 -> player starts, if result is 1 -> ai starts
 

        int startingPlayer = Random.Range(0, 2);

        if (startingPlayer == 0)
        {
            MyPlayer.PlayerMark = 'X';
            MyPlayer.PlayerTurn = true;

            MyAI.AIMark = 'O';
            MyAI.AITurn = false;

            print("Player starts first");
        }
        else if (startingPlayer == 1)
        {
            MyPlayer.PlayerMark = 'O';
            MyPlayer.PlayerTurn = false;

            MyAI.AIMark = 'X';
            MyAI.AITurn = true;

            

            print("AI starts first");
        }
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
                print("Playerturn set to false");

                MyPlayer.PlayerTurn = false;
                MyAI.AITurn = true;
                MakeMove(MyAI.FindBestMove(), MyAI.AIMark);
            }
            else if(MyAI.AITurn)
            {
                print("AIturn set to false");
                MyAI.AITurn = false;
                //MyPlayer.PlayerTurn = true;
                
            }

          


        }
        else
        {
            //remove this later, just for testing random moves
            //print("Can't make that move");
            //MyPlayer.PlayerTurn = true;
            //MyAI.AITurn = false;

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
