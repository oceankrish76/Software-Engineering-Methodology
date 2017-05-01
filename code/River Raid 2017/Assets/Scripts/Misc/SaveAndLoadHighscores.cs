using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;


//A highscore class, extendable for future purposes
[System.Serializable]
public class Highscore
{
    public string name;
    public int score;
}


public class SaveAndLoadHighscores : MonoBehaviour
{

    public List<Highscore> highscorelist = new List<Highscore>();

    private SimpleGameManager manager;

    void Awake()
    {
        if (FindObjectOfType<SimpleGameManager>())
        {
            manager = FindObjectOfType<SimpleGameManager>();
        }

    }

    public void Save()
    {
        //No need to save, if highscores we're accessed from the menu 
        if (manager.gameState != GameState.MENU)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/highscores.dat", FileMode.OpenOrCreate);
            bf.Serialize(file, highscorelist);
            Debug.Log("Highscores written to a file successfully.");
        }
    }

    public List<Highscore> Load()
    {
        Debug.Log(Application.persistentDataPath);
        if (File.Exists(Application.persistentDataPath + "/highscores.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/highscores.dat", FileMode.Open);
            highscorelist = (List<Highscore>)bf.Deserialize(file);
            Debug.Log("Highscores read successfully.");

            file.Close();
        }

        //Appends the current score to the list if game is over 
        //Afterwards, we need to sort the list again.
        if (manager.gameState == GameState.GAME_OVER)
        {
            Highscore data = new Highscore();
            data.name = FindObjectOfType<SimpleGameManager>().PlayerName;
            data.score = FindObjectOfType<SimpleGameManager>().PlayerScore;
            Debug.Log(FindObjectOfType<SimpleGameManager>().PlayerScore);

            Debug.Log(data.name);
            Debug.Log(data.score);
            highscorelist.Add(data);
            //Sorting by highscores
            highscorelist.Sort((player1, player2) => player1.score.CompareTo(player2.score));
            //If we have more than 11 entries, remove the last one
            while(highscorelist.Count > 11)
            {
                highscorelist.RemoveAt(highscorelist.Count - 1);
            }
            //Reversing, since table is created procedurally
            highscorelist.Reverse();
        }

        return highscorelist;
    }
}


