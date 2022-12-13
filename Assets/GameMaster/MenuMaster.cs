using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuMaster : MonoBehaviour
{
    public string name;
    public int lvl;
    public GameObject newGame,loadGame,howToPlay;
    public InputField nameInput;
   
   void Start(){
    
    GameObject.Find("load1").GetComponentInChildren<Text>().text = PlayerPrefs.GetString("Save1Str");
    GameObject.Find("load1").gameObject.transform.GetChild(1).GetComponent<Text>().text=": "+PlayerPrefs.GetInt("Save1Int");

    GameObject.Find("load2").GetComponentInChildren<Text>().text = PlayerPrefs.GetString("Save2Str");
    GameObject.Find("load2").gameObject.transform.GetChild(1).GetComponent<Text>().text=": "+PlayerPrefs.GetInt("Save2Int");

    GameObject.Find("load3").GetComponentInChildren<Text>().text = PlayerPrefs.GetString("Save3Str");
    GameObject.Find("load3").gameObject.transform.GetChild(1).GetComponent<Text>().text=": "+PlayerPrefs.GetInt("Save3Int");
    loadGame.SetActive(false);
   }
    public void NewGameMenu(){
        newGame.SetActive(true);
        loadGame.SetActive(false);
        howToPlay.SetActive(false);
    }

    public void LoadGameMenu(){
        newGame.SetActive(false);
        loadGame.SetActive(true);
        howToPlay.SetActive(false);
    }
    public void HowToPlay(){
        newGame.SetActive(false);
        loadGame.SetActive(false);
        howToPlay.SetActive(true);
    }
    public void StartNewgame(){
        if(nameInput.text != ""){
            Debug.Log(nameInput.text);
            Courier.name=nameInput.text;
            Courier.lvl=0;
            SceneManager.LoadScene("SampleScene");
        }else{
            Debug.Log("gimme ur name idiot");
        }
    }
     public void LoadGame(int i){
        string index = "Save"+i.ToString()+"Str";
        Courier.name = PlayerPrefs.GetString(index);
        index = "Save"+i.ToString()+"Int";
        Courier.lvl = PlayerPrefs.GetInt(index);
        SceneManager.LoadScene("SampleScene");
    }
}
