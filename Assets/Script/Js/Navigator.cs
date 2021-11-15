using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.Linq;
using UnityEngine.Networking;
using Jint;
using System;
using UnityEngine.UI;

public class Navigator : MonoBehaviour
{
    public static string _adress = "https://hanzilink.com/static/3d/main.json";
    
    public static Material _materiel;
    public Material _materielNonStatic;
    
    public static GameObject _interface;
    public static Button _buttonPrevious;
    public static Button _buttonNext;
    public static Button _buttonSearch;
    public static InputField _textFieldAdresse;
    public static Text _textLien;
    
    public static Dictionary<string, Mesh> _meshCache = new Dictionary<string, Mesh>();
    
    public static Engine _engine;
    
    public static Page _page;
    
    public static List<string> _historicalPage = new List<string>();
    public static int _historicalId = 0;
    
    
    void Start()
    {
        _buttonPrevious = GameObject.Find("ButtonPrevious").GetComponent<Button>();
        _buttonNext = GameObject.Find("ButtonNext").GetComponent<Button>();
        _buttonSearch = GameObject.Find("ButtonSearch").GetComponent<Button>();
        _textFieldAdresse = GameObject.Find("TextFieldAdress").GetComponent<InputField>();
        _textLien = GameObject.Find("TextLien").GetComponent<Text>();
        _interface = GameObject.Find("Interface");
        
        _interface.SetActive(false);
        
        _buttonPrevious.onClick.AddListener(PreviousPage);
        _buttonNext.onClick.AddListener(NextPage);
        _buttonSearch.onClick.AddListener(delegate { RedirectPage(_textFieldAdresse.text); });
        
        
        _engine = new Engine();
        _engine.SetValue("log", new Action<object>(msg => Debug.Log(msg)));
        
        _materiel = _materielNonStatic;
        
        
        RedirectPage("https://xn--instantan-cs-jeb.com/test");
    } 
    
    
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if(_interface.activeSelf){
                _interface.SetActive(false);
            }else{
                
                _textFieldAdresse.text = _adress;
                _interface.SetActive(true);
            }
        }
    } 
    
    
    public static async void AfficherLien(string lien)
    {
        _textLien.text = lien;
        
    } 
    
    
    public static async void RedirectPage(string uri)
    {
        Debug.Log("Debut du chargement du monde : " + uri);
        
        for(int x = 0;x < _historicalId;x++){
          _historicalPage.RemoveAt(_historicalPage.Count - 1);
        }
        _historicalId = 0;
        _historicalPage.Add(uri);
        LoadPage(uri);
        
        //
        
    }
    
    public static async void PreviousPage()
    {
       
        _historicalId += 1;
        if(_historicalId >= _historicalPage.Count){
            _historicalId = _historicalPage.Count - 1;
            return;
        }else{
            LoadPage(_historicalPage[_historicalPage.Count - 1 - _historicalId]);
        
        }
    }
    
    
    public static async void NextPage()
    {
        _historicalId -= 1;
        if(_historicalId < 0){
            _historicalId = 0;
            return;
        }else{
            LoadPage(_historicalPage[_historicalPage.Count - 1 - _historicalId]);
        
        }
        
        
    }
    
    
    
    
    private static async void LoadPage(string uri)
    {
        Debug.Log("Debut du chargement du monde : " + uri);
        _adress = uri;
        _textFieldAdresse.text = _adress;
        ClearPage();
        string requete = await GetRequest(uri);
        new Page(requete);
                
        _engine.SetValue("Page", _page);
      
        for (int i = 0; i < _page.CountEntity(); i++){
            _page.GetEntity(i).StartScript();
        }
        
        Debug.Log("Fin du chargement du monde : " + uri);
        
    } 
    
    
    
    public static void ClearPage()
    {
        if(_page != null){
            _meshCache.Clear();
            
            _page.Destroy();
        }
    } 
    
    
    
    public static Page GetPage()
    {
        return _page;
    } 
    
    
    
    
    public static async Task<Mesh> LoadMesh (string path) {
        if(path == ""){
            return null;
        }
        Mesh temp;
        if(_meshCache.TryGetValue(path, out temp))
        {
            return temp;
        }
        else
        {
            string data = await GetRequest(path);
            Mesh mesh = FileReader.ReadObjFile (data);
            
            _meshCache.Add(path, mesh);
    		return mesh;
        }
    }
    
    
    public static async Task<string> GetRequest (string uri) 
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(uri);
        // Request and wait for the desired page.
        webRequest.SendWebRequest();
        string[] pages = uri.Split('/');
        int page = pages.Length - 1;
        while(webRequest.result == UnityWebRequest.Result.InProgress){
            
        }
        
        switch (webRequest.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                break;
            case UnityWebRequest.Result.ProtocolError:
                Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                break;
            case UnityWebRequest.Result.Success:
                return webRequest.downloadHandler.text;
                break;
        }
            
        return "vide";
    }
    
}
