using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public class cell
    {
        public bool visited = false;
        public bool[] status = new bool[4];
    }

    public Vector2 size;
    public int startPos = 0;
    
    List<cell> board = new List<cell>();
    
    public GameObject room;
    public GameObject PlayerPrefab;
    public GameObject floorPrefab;
    public GameObject EndPoint;
    public Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        MazeGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateDungeon()
    {
        for(int i =0; i< size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                cell currentCell = board[Mathf.FloorToInt(i + j * size.x)];
                if (currentCell.visited)
                {
                    var newRoom = Instantiate(room, new Vector3(i * offset.x, 0, -j * offset.y), Quaternion.identity, transform).GetComponent<RoomBehavious>();
                    newRoom.UpdateRoom(board[Mathf.FloorToInt(i + j * size.x)].status);

                    if(i ==0 && j==0)
                    {
                        PlayerPrefab.transform.position = new Vector3(floorPrefab.GetComponent<Collider>().bounds.center.x, floorPrefab.GetComponent<Collider>().bounds.center.y+2, floorPrefab.GetComponent<Collider>().bounds.center.z);
                    }

                    newRoom.name += " " + i + "x" + j;

                    //if (board[board.Count-2] == currentCell)
                    //{
                    //    Instantiate(EndPoint, new Vector3(newRoom.transform.Find("Floor (4)").GetComponent<Collider>().bounds.center.x, newRoom.transform.Find("Floor (4)").GetComponent<Collider>().bounds.center.y, newRoom.transform.Find("Floor (4)").GetComponent<Collider>().bounds.center.z), Quaternion.identity);
                    //}
                }
            }
        }
    }

    void MazeGenerator()
    {
        board = new List<cell>();
        for(int i = 0; i < size.x; i++)
        {
            for(int j = 0; j < size.y; j++)
            {
                board.Add(new cell());
            }
        }

        int currentCell = startPos;
        Stack<int> Path = new Stack<int>();

        int k = 0;
        while(k<1000)
        {
            k++;
            board[currentCell].visited = true;

            if(currentCell == board.Count-1)
            {
                break;
            }

            //check the cell's neighbour
            List<int> neighbours = CheckNeighbour(currentCell);

            if (neighbours.Count == 0)
            {
                if (Path.Count == 0)
                {
                    break;
                }
                else
                {
                    currentCell = Path.Pop();
                }
            }
            else
            {
                Path.Push(currentCell);

                int newCell = neighbours[Random.Range(0, neighbours.Count)];

                if(newCell > currentCell)
                {
                    //down or right
                    if (newCell - 1 == currentCell)
                    {
                        board[currentCell].status[2] = true;
                        currentCell= newCell;
                        board[currentCell].status[3] = true;
                    }
                    else
                    {
                        board[currentCell].status[1] = true;
                        currentCell = newCell;
                        board[currentCell].status[0] = true;
                    }
                }
                else
                {
                    //up or left
                    if (newCell + 1 == currentCell)
                    {
                        board[currentCell].status[3] = true;
                        currentCell = newCell;
                        board[currentCell].status[2] = true;
                    }
                    else
                    {
                        board[currentCell].status[0] = true;
                        currentCell = newCell;
                        board[currentCell].status[1] = true;
                    }
                }
            }
        }
        Debug.Log("Generated maze");
        GenerateDungeon();
    }

    List<int> CheckNeighbour(int cell)
    {
        List<int> neighbours = new List<int>();

        //Check up neighbour
        if(cell - size.x >= 0 && !board[Mathf.FloorToInt(cell-size.x)].visited)
        {
            neighbours.Add(Mathf.FloorToInt(cell-size.x));
        }

        //Check Down neighbour
        if (cell + size.x < board.Count && !board[Mathf.FloorToInt(cell + size.x)].visited)
        {
            neighbours.Add(Mathf.FloorToInt(cell + size.x));
        }

        //check right neighbour
        if ((cell+1) % size.x != 0  && !board[Mathf.FloorToInt(cell + 1)].visited)
        {
            neighbours.Add(Mathf.FloorToInt(cell + 1));
        }

        //check left nieghbour
        if (cell % size.x != 0 && !board[Mathf.FloorToInt(cell - 1)].visited)
        {
            neighbours.Add(Mathf.FloorToInt(cell - 1));
        }

        return neighbours;
    }
}
