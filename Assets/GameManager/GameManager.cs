using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public enum colors : int { Red = 0, Yellow, Blue, Orange, Violet, Green, White };
    public static GameManager Instance { get; private set; }
    public float oil = 100;
    public string GAME_OVER_INDEX;
   // public int CORRIDOR_ID = 2;
    //public int CORRIDORFLOOR2_ID = 8;
    public string CORRIDOR_ID;
    public string CORRIDORFLOOR2_ID;
    // public const int NUMBEROFPUZZLES = 8;
    public const int NUMBEROFWHEELPUZZLE = 4;
    public const int NUMBEROFCOLORPUZZLE = 4;
    public const int NUMBEROFROOMS = 10;
    //public bool[] puzzleProgress = new bool[NUMBEROFROOMS];//number represents puzzle room

    public int[,] wheelPuzzleAnswer = new int[NUMBEROFWHEELPUZZLE, 4];//0 = answer, 1 2 3= wheel answer positon
    public colors[] colorPuzzleAnswer = new colors[NUMBEROFCOLORPUZZLE];

    public int currentRoomID = 0;
    public string currentRoomName;
    private int lastAssignedColourID;
    private int lastAssignedWheelID;
    private int lastAssignedClockID;
    public Room[] roomData = new Room[NUMBEROFROOMS];

    public Vector3 prevRoomLocation;
    public Vector3 prevCorridorLocation;
    public bool inPuzzle = false;

    public delegate void SceneChanged();
    public static event SceneChanged Changed;

   /* public string fixAnsNumber1 = "FF_StudyRoom";
    public string fixAnsNumber2 = "GF_Tearoom";
    public int fixAnsNum1 = 13;
    public int fixAnsNum2 = */

    public struct Room
    {
        public bool puzzleAssigned;
        public string puzzleType;
        public int puzzleId;
        public bool puzzleSolved;
        
    };



    private void Awake()
    {
        if (Instance == null) Instance = this;//assign self as singleton if none exists
        else if (Instance != this) Destroy(this.gameObject);//if singleton exists, kill self

        DontDestroyOnLoad(this.gameObject);
        Restart();
    }

    public void Restart()//resets manager for new game
    {
        oil = 100;
        for (int j = 0; j < wheelPuzzleAnswer.GetLength(0); j++)
        {
            randomWheelAnswer(j);
        }
        for (int k = 0; k < colorPuzzleAnswer.Length; k++)
        {
            randomColorAnswer(k);
        }
        for (int l = 0; l < roomData.Length; l++)
        {
            roomData[l].puzzleAssigned = false;
            roomData[l].puzzleType = "";
            roomData[l].puzzleId = -1;
            roomData[l].puzzleSolved = false;
        }
        lastAssignedColourID = 0;
        lastAssignedWheelID = 0;
        lastAssignedClockID = 0;
        currentRoomID = SceneManager.GetActiveScene().buildIndex;
        currentRoomName = SceneManager.GetActiveScene().name;
    }

    public void loseOil(int amount)
    {
        oil = oil - amount;
    }

    void randomWheelAnswer(int id)//distributes the generated number for answer onto the wheels randomly (possible modular candidate too)
    {
        int steps = 1;
        wheelPuzzleAnswer[id, 0] = Random.Range(3, 28);

        for (int i = wheelPuzzleAnswer[id, 0]; i > 0; i--)
        {
            if (Random.Range(0, 2) == 1 && wheelPuzzleAnswer[id, steps] < 9)
            {
                wheelPuzzleAnswer[id, steps] = wheelPuzzleAnswer[id, steps] + 1;
            }
            else
            {
                i = i + 1;
            }
            steps = WrapAroundIncrease(steps, 1, 3);

        }

    }

    int WrapAroundIncrease(int num, int min, int max)
    {
        if (num == max)
        {
            return min;
        }
        else
        {
            return num + 1;
        }
    }

    void randomColorAnswer(int id)
    {
        colorPuzzleAnswer[id] = (colors)Random.Range((int)colors.Orange, (int)colors.Green + 1);
    }

    public void givePuzzleId(string type)
    {
        if (type == "Wheel")
        {
            lastAssignedWheelID++;
            roomData[currentRoomID].puzzleAssigned = true;
            roomData[currentRoomID].puzzleType = "Wheel";
            roomData[currentRoomID].puzzleId = lastAssignedWheelID - 1;
            //  return lastAssignedWheelID - 1;
        }
        else if (type == "Color")
        {
            lastAssignedColourID++;
            roomData[currentRoomID].puzzleAssigned = true;
            roomData[currentRoomID].puzzleType = "Color";
            roomData[currentRoomID].puzzleId = lastAssignedColourID - 1;
            // return lastAssignedColourID - 1;
        }
        else if (type == "Clock")
        {
            lastAssignedClockID++;
            roomData[currentRoomID].puzzleAssigned = true;
            roomData[currentRoomID].puzzleType = "Clock";
            roomData[currentRoomID].puzzleId = lastAssignedClockID - 1;
            // return lastAssignedColourID - 1;
        }

        //   else
        //  return -1;//default 
    }

   // public void ChangeScene(int levelIndex, Vector3 playerLocation)
    public void ChangeScene(string levelIndex, Vector3 playerLocation)
    {

        if (currentRoomName == CORRIDOR_ID || currentRoomName == CORRIDORFLOOR2_ID)//going away from corridor
        {
            prevCorridorLocation = playerLocation;
        }
        currentRoomName = levelIndex;
        
        Changed();
        SceneManager.LoadScene(levelIndex);
        currentRoomID = SceneManager.GetActiveScene().buildIndex;

    }
    public void ChangeSceneForPuzzle(string levelIndex, Vector3 playerLocation)
    {
       /* if(SceneManager.GetActiveScene().name == fixAnsNumber1 || SceneManager.GetActiveScene().name == fixAnsNumber2)
        {

        }*/
        if (!roomData[currentRoomID].puzzleSolved)//dosen't enter solved puzzles
        {
            inPuzzle = true;
            prevRoomLocation = playerLocation;
            Changed();
            SceneManager.LoadScene(levelIndex);
        }
    }
    public void ChangeSceneForInspect(string levelIndex, Vector3 playerLocation)
    {
       
            inPuzzle = true;
            prevRoomLocation = playerLocation;
            Changed();
            SceneManager.LoadScene(levelIndex);

    }

    public void GameOver()
    {
        Changed();
        SceneManager.LoadScene(GAME_OVER_INDEX);
    }
    public void ReturnFromPuzzle()
    {
        SceneManager.LoadScene(currentRoomName);

    }

    public void RepositionPlayer()
    {
        if (currentRoomName == CORRIDOR_ID || currentRoomName == CORRIDORFLOOR2_ID) // going to the corridor
        {
            if (prevCorridorLocation != new Vector3(0, 0, 0))
                player.transform.position = prevCorridorLocation;
        }
        else if (inPuzzle) // from puzzle
        {
            player.transform.position = prevRoomLocation;
            inPuzzle = false;
        }
        // ADD ELSE FOR ROOM GEN
        /*else
          {
          player.transform.position =roomData doorPosition; (will not function, this is notes for update)
          }*/
    }

    public int PuzzleSolvedCount()
    {
        int count = 0;
        for (int i = 0; i > roomData.Length; i++)
        {
            if (roomData[i].puzzleSolved)
            {
                count++;
            }

        }
        return count;
    }

    public string GetPuzzleAnswer()
    {
        if (roomData[currentRoomID].puzzleAssigned)
        {
            if (roomData[currentRoomID].puzzleType == "Wheel")
            {
                return wheelPuzzleAnswer[roomData[currentRoomID].puzzleId, 0].ToString();
            }
            else if (roomData[currentRoomID].puzzleType == "Color")
            {
                return colorPuzzleAnswer[roomData[currentRoomID].puzzleId].ToString();
            }
            else
                return "error, puzzle error";
        }
        else
            return "error, puzzle assigned";
    }



    public void AddPuzzleReward()
    {
        roomData[currentRoomID].puzzleSolved = true;//marks puzzle as solved


        //Akmal add the reward for puzzles to the inventory, i'll make puzzles call this when complete, 
    }
}
