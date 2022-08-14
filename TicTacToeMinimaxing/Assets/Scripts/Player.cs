using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool PlayerTurn { get; set; } = false;

    public char PlayerMark { get; set; } = ' ';

    private Board MyBoard;

    // Start is called before the first frame update
    void Start()
    {
        MyBoard = FindObjectOfType<Board>();
    }

    // Update is called once per frame
    void Update()
    {
        print(PlayerTurn);

        if (PlayerTurn)
        {
            print("Called in player");
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;



                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Cell"))
                    {
                        int idex = hit.collider.gameObject.GetComponent<Cell>().Index;
                        MyBoard.MakeMove(idex, PlayerMark);
                        print("worked");
                    }
                }
            }
        }

    }

   


}
