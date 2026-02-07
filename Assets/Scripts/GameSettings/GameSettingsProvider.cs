using UnityEngine;

public static class GameSettingsProvider
{
    private static GameSettings _instance;

    public static GameSettings Instance
    {
        get
        {
            if (_instance == null)
                _instance = Resources.Load<GameSettings>("GameSettings");

            return _instance;
        }
    }
}
