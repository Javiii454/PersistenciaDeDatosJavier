using UnityEngine;

public class PlayerData : MonoBehaviour
{

    //public static PlayerData Instanciate;
    public string playerName;

    public Vector3 playerPosition;
    public int playerMaxHealth;

    public int playerMaxMana;

    public int playerExp;

    /*void Awake()
    {
        if (Instanciate != null != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instanciate = this;
        }
        DontDestroyOnLoad(gameObject);
    }*/

    public void SaveData()
    {
        /*UserData.playerName = playerName;
        UserData.playerMaxHealth = playerMaxHealth;
        UserData.playerMaxMana = playerMaxMana;
        UserData.playerExp = playerExp;
        UserData.playerPosition = playerPosition;*/

        Stats.userStats.playerName = playerName;
        Stats.userStats.playerExp = playerExp;
        Stats.userStats.playerPosition = playerPosition;
        Stats.userStats.playerMaxHealth = playerMaxHealth;
        Stats.userStats.playerMaxMana = playerMaxMana;

        SavingData.Save();
        Debug.Log("Datos Guardados");
    }

    public void LoadData()
    {
        /*playerName = UserData.playerName;
        playerMaxHealth = UserData.playerMaxHealth;
        playerMaxMana = UserData.playerMaxMana;
        playerExp = UserData.playerExp;
        playerPosition = UserData.playerPosition;*/
        SavingData.Load();
        playerName = Stats.userStats.playerName;
        playerExp = Stats.userStats.playerExp;
        playerPosition = Stats.userStats.playerPosition;
        playerMaxHealth = Stats.userStats.playerMaxHealth;
        playerMaxMana = Stats.userStats.playerMaxMana;

        Debug.Log("Datos Cargados");

    }

    public void SavePrefs()
    {
        PlayerPrefs.SetString("Player Name", playerName);
        PlayerPrefs.SetInt("Player Health", playerMaxHealth);
        PlayerPrefs.SetInt("Player Mana", playerMaxMana);
        PlayerPrefs.SetInt("Player Exp", playerExp);
        PlayerPrefs.SetFloat("Position z", playerPosition.z);
        PlayerPrefs.SetFloat("Position x", playerPosition.x);
        PlayerPrefs.SetFloat("Position y", playerPosition.y);
    }
    
    public void LoadPrefs()
    {

        playerPosition.z = PlayerPrefs.GetFloat("Position z"); // (❁´◡`❁)
        playerPosition.x = PlayerPrefs.GetFloat("Position x"); // (┬┬﹏┬┬)
        playerPosition.y = PlayerPrefs.GetFloat("Position y"); // ಥ_ಥ
        playerName = PlayerPrefs.GetString("Player Name", "No Name");
        playerMaxHealth = PlayerPrefs.GetInt("Player Health", 1);
        playerMaxMana = PlayerPrefs.GetInt("Player Mana)", 1);
        playerExp = PlayerPrefs.GetInt("Player Exp", 1);
    }
}
