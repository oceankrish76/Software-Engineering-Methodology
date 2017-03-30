using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveAndLoadHighscores : MonoBehaviour {

    public List<Highscore> highscorelist = new List<Highscore>();

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/highscores.dat", FileMode.OpenOrCreate);

        Highscore data = new Highscore();
        data.name = FindObjectOfType<SimpleGameManager>().PlayerName;
        data.score = FindObjectOfType<SimpleGameManager>().PlayerScore;
        Debug.Log(FindObjectOfType<SimpleGameManager>().PlayerScore);
        /* if(highscorelist.Count > 50)
         {
             highscorelist.RemoveAt(highscorelist.Count-1);
         }*/
        Debug.Log(data.name);
        Debug.Log(data.score);
        highscorelist.Add(data);
        //Sorting by highscores
        highscorelist.Sort((player1, player2) => player1.score.CompareTo(player2.score));
        //Reversing, since table is created procedurally
        highscorelist.Reverse();
        
        bf.Serialize(file,highscorelist);
        Debug.Log("Highscores written to a file successfully.");
    }

    public List<Highscore> Load()
    {
        Debug.Log(Application.persistentDataPath);
        if(File.Exists(Application.persistentDataPath + "/highscores.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/highscores.dat", FileMode.Open);
            highscorelist = (List<Highscore>)bf.Deserialize(file);
            Debug.Log("Highscores read successfully.");

            file.Close();
        }

        return highscorelist;
    }
}


[System.Serializable]
public class Highscore
{
    public string name;
    public int score;
}