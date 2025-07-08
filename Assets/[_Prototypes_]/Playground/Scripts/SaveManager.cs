using UnityEngine;
using System.Collections.Generic;
using System;

[System.Serializable] 
public class ThisGameSave
{
    public int highScore;
    public int health;
    public Vector3 lastCheckpoint;
    public Color playerColor;
    public bool soundActive;
    public List<int> leaderboard;
    //public List<LeaderboardScore> leaderboard;
    public string playerName;

    public int hrsPlayed;
    public int minsPlayed;
    public int secsPlayed;
    public float totalSeconds;
}

public class LeaderboardScore
{
    public string name;
    public int score;
    public string region = "AU";
}

public class SaveManager : SaveData
{
    #region Variables
    // Manually setting up SaveManager as a Singleton
    public static SaveManager Instance;

    // This game data
    public ThisGameSave save = new ThisGameSave();

    // Last save time
    public DateTime timeOfLastSave;
    #endregion Variables

    #region Awake() Start() Update()
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("SaveManager Instance already exists!");
            return;
        }
        Instance = this;

        // Load Save Data
        save = LoadDataObject<ThisGameSave>();
        if (save != null) return;
        CreateSaveObject();

    }
    #endregion Awake() Start() Update()

    private void CreateSaveObject()
    {
        save = new ThisGameSave();
        Debug.Log("New save file created");

        save.highScore = 69;
        save.health = 100;
        save.lastCheckpoint = Vector3.zero;
        save.playerColor = Color.magenta;
        save.soundActive = true;
        save.leaderboard = new List<int>(10);

        save.hrsPlayed = 0;
        save.minsPlayed = 0;
        save.secsPlayed = 0;

    }

    #region Get & Set

    #region Get
    public int GetHighscore => save.highScore;
    public float GetHealth => save.health;
    public Color GetPlayerColor => save.playerColor;
    #endregion Get

    #region Set
    public void SetScore(int _score)
    {
        if (_score > save.highScore) save.highScore = _score;

        int last = save.leaderboard[save.leaderboard.Count - 1];
        if (_score < last) return;

        save.leaderboard.RemoveAt(save.leaderboard.Count);
        save.leaderboard.Add(_score);
    }
    public void SetHealth(int _health) => save.health = _health;
    public void SetPlayerColor(Color _color) => save.playerColor = _color;
    public void SetPlayerName(string _name) => save.playerName = _name;
    #endregion Set

    #endregion Get & Set

    #region Game Time
    public void ElapsedTime()
    {
        DateTime now = DateTime.Now;
        int seconds = (now - timeOfLastSave).Seconds;
        save.totalSeconds += seconds;
        save.hrsPlayed = GetHours(save.totalSeconds);
        save.minsPlayed = GetMinutes(save.totalSeconds);
        save.secsPlayed = GetSeconds(save.totalSeconds);
        Debug.Log(save.hrsPlayed + " Hours, " + save.minsPlayed +
                  " Minutes, " + save.secsPlayed + " Seconds");
        timeOfLastSave = DateTime.Now;
    }
    int GetSeconds(float _seconds) => Mathf.FloorToInt(_seconds % 60);
    int GetMinutes(float _seconds) => Mathf.FloorToInt(_seconds / 60);
    int GetHours(float _seconds) => Mathf.FloorToInt(_seconds / 3600);
    #endregion


    #region Overrides
    public override void Save()
    {
        SaveDataObject(save);
    }
    public override void Delete()
    {
        DeleteDataObject();
    }
    #endregion Overrides
}
