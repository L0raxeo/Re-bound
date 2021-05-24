using UnityEngine;

public class SaveManager : MonoBehaviour
{

    public static SaveManager Instance { set; get; }
    public SaveState state;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Load();
    }

    public void Save()
    {
        PlayerPrefs.SetString("save", Utils.Serialize<SaveState>(state));
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("save"))
        {
            state = Utils.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
        }
        else
        {
            state = new SaveState();
            Save();
            Debug.Log("No save file found, creating a new one");
        }
    }

}
