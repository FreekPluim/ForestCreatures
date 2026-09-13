using UnityEngine;

public interface ISaveLoad
{
    void LoadData(GameData data);
    void SaveData(ref GameData data);
}
