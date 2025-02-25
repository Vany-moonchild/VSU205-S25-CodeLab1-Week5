using UnityEngine;
using System.IO;

public class ASCIILevelLoader : MonoBehaviour
{
    public GameObject prefabPlayer;
    public GameObject prefabWall;
    public GameObject prefabObstacle;
    public GameObject prefabGoal;

    int currentLevel = 0;

    //property for currentLevel so it does this when currentLevel is given a value 
    public int CurrentLevel
    {
        set
        {
            currentLevel = value;
            LoadLevel();
        }
        get
        {
            return currentLevel;
        }
    }
    
    string filePath;
    public string fileName;

    public float offsetX = 3; 
    public float offsetY = -3;

    private GameObject levelHolder;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //LoadLevel();
        CurrentLevel = 0;
    }
    
    
    public void LoadLevel()
    {
        if (levelHolder != null)
        {
            Destroy(levelHolder);
        }
        
        levelHolder = new GameObject("Level Holder");
        
        filePath = Application.dataPath;
        
        //string fileContents = File.ReadAllText (filePath + fileName);
        //Debug.Log (fileContents);
        
        string[] lines = File.ReadAllLines(filePath + fileName.Replace("<num>", currentLevel.ToString()));

        //looping through each line of the file 
        for (int y = 0; y < lines.Length; y++)
        {
            Debug.Log(lines[y]);
            
            string line = lines[y]; //getting the string for this line
            
            char[] charArray = lines[y].ToCharArray(); //turn that string into a char array (character array)
            
            //loop through each character on this line 
            for (int x = 0; x < charArray.Length; x++)
            {
                char c = charArray[x];

                GameObject newObj = null;

                switch (c)
                {
                    case 'P' :
                        newObj = Instantiate<GameObject>(prefabPlayer);
                        break;
                    case 'W' :
                        newObj = Instantiate<GameObject>(prefabWall);
                        break;
                    case '*' :
                        newObj = Instantiate<GameObject>(prefabObstacle);
                        break;
                    case 'G':
                        newObj = Instantiate<GameObject>(prefabGoal);
                        break;
                }

                if (newObj != null)
                {
                    newObj.transform.parent = levelHolder.transform;
                    newObj.transform.position = new Vector3(x + offsetX, -y + offsetY, 0);
                }
                
                // if (c == 'P') //"for string" 'for character'
                // {
                //     newObj = Instantiate<GameObject>(prefabPlayer);
                //     newObj.transform.position = new Vector3(x + offsetX, -y + offsetY, 0);
                // }
                //
                // if (c == 'W')
                // {
                //     newObj = Instantiate<GameObject>(prefabWall);
                //     newObj.transform.position = new Vector3(x + offsetX, -y + offsetY, 0);
                // }
                
            }
            
            // if (lines[y].Equals("P"))
            // {
            //     Instantiate<GameObject>(prefabPlayer);
            // }
            //
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
