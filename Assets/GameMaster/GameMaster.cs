using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public GameObject enemyPrefab, gameLostCanvas, gameWonCanvas, gameSaveCanvas;
    public int lvl;
    public Transform[] SpawnPos;
    private int total_Enemies, simultan_Enemies;
    public int current_Enemies;
    public string name;
    // Start is called before the first frame update
    void Start()
    {
        name = Courier.name;
        lvl = Courier.lvl;
        LvlUpload(lvl);

    }

    // Update is called once per frame
    void Update()
    {

    }
    void LvlUpload(int lvl)
    {
        total_Enemies = 5 + 2 * lvl;
        simultan_Enemies = 3 + lvl;
        current_Enemies = 0;
        EnemySpawn();
        GameObject.Find("Player").GetComponent<Player>().hp = 100;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
    void EnemySpawn()
    {

        Invoke(nameof(EnemySpawn), 4);
        if (current_Enemies < simultan_Enemies && total_Enemies > 0)
        {
            Instantiate(enemyPrefab, SpawnPos[0].position, Quaternion.Euler(0, 0, 0));
            current_Enemies++;
            total_Enemies--;
        }
    }
    public void EnemyKilled()
    {
        current_Enemies--;
        if (current_Enemies == 0 && total_Enemies == 0)
        {
            GameWon();
        }
    }
    public void GameLost()
    {
        gameLostCanvas.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("gameLost");
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void GameWon()
    {
        gameWonCanvas.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("gameWon");
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void NextLvl()
    {
        gameWonCanvas.SetActive(false);
        lvl++;
        LvlUpload(lvl);
    }
    public void ReplayLvl()
    {
        gameWonCanvas.SetActive(false);
        gameLostCanvas.SetActive(false);
        LvlUpload(lvl);
    }

    public void Exit()
    {
        gameLostCanvas.SetActive(false);
        gameWonCanvas.SetActive(false);
        gameSaveCanvas.SetActive(true);
        GameObject.Find("Save1").GetComponentInChildren<Text>().text = PlayerPrefs.GetString("Save1Str");
        GameObject.Find("Save2").GetComponentInChildren<Text>().text = PlayerPrefs.GetString("Save2Str");
        GameObject.Find("Save3").GetComponentInChildren<Text>().text = PlayerPrefs.GetString("Save3Str");

    }

    public void Save(int i)
    {
        if (i > 0)
        {
            string index = "Save" + i.ToString() + "Str";
            PlayerPrefs.SetString(index, name);
            index = "Save" + i.ToString() + "Int";
            PlayerPrefs.SetInt(index, lvl);
            SceneManager.LoadScene("SampleScene");
        }

        SceneManager.LoadScene("Menu");
    }

}
