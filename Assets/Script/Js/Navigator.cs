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
using Newtonsoft.Json;
using System.Runtime.CompilerServices; 
using System.Threading.Tasks;

public static class ExtensionMethods
{
    public static TaskAwaiter GetAwaiter(this AsyncOperation asyncOp)
    {
        var tcs = new TaskCompletionSource<object>();
        asyncOp.completed += obj => { tcs.SetResult(null); };
        return ((Task)tcs.Task).GetAwaiter();
    }
}

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
    public static Dictionary<string, Texture2D> _textureCache = new Dictionary<string, Texture2D>();
    
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
        _engine.SetValue("RedirectPage", new Action<string>(RedirectPage));
        //_engine.SetValue("GetRequest", new Func<string,string>(GetRequest));
        _engine.SetValue("RedirectPagePost", new Action<string,string>(RedirectPagePost));
        //_engine.SetValue("GetRequestPost", new Func<string,string,string>(GetRequestPost));
        
        
        _engine.SetValue("Entity", Jint.Runtime.Interop.TypeReference.CreateTypeReference(_engine, typeof(Entity)));
        _engine.SetValue("TransformWeb", Jint.Runtime.Interop.TypeReference.CreateTypeReference(_engine, typeof(TransformWeb)));
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
        if(_page != null){
            _page.OnUpdate(Time.deltaTime);
        
        }
    } 
    
    
    public static async void AfficherLien(string lien)
    {
        _textLien.text = lien;
        
    } 
    
    
    public static async void RedirectPage(string uri)
    {
        
        for(int x = 0;x < _historicalId;x++){
          _historicalPage.RemoveAt(_historicalPage.Count - 1);
        }
        _historicalId = 0;
        _historicalPage.Add(uri);
        LoadPage(uri);
        
        //
        
    }
    
    public static async void RedirectPagePost(string uri, string json)
    {
        RedirectPagePost(uri,JsonConvert.DeserializeObject<Dictionary<string, string>>(json));
        
        //
        
    }
    
    public static async void RedirectPagePost(string uri, Dictionary<string, string> form)
    {
        
        
        for(int x = 0;x < _historicalId;x++){
          _historicalPage.RemoveAt(_historicalPage.Count - 1);
        }
        _historicalId = 0;
        _historicalPage.Add(uri);
        LoadPage(uri,form);
        
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
    
    
    
    private static async void LoadPage(string uri,Dictionary<string, string> form = null)
    {
        Debug.Log("Debut du chargement du monde : " + uri);
        _adress = uri;
        _textFieldAdresse.text = _adress;
        ClearPage();
       
        
        UnityWebRequest webRequest = await GetRequest(uri);
        if(webRequest .result == UnityWebRequest.Result.Success){
            new Page(webRequest.downloadHandler.text);
                    
            _engine.SetValue("Page", _page);
          
            for (int i = 0; i < _page.CountEntity(); i++){
                _page.GetEntity(i).StartScript();
            }
            
            Debug.Log("Fin du chargement du monde : " + uri);
        }
    } 
    
    
    public static async Task<Mesh> LoadMesh (string path) {
    
        if(path == ""){
            return null;
        }else if(path.Substring(0, 6) == "local:"){
            return Resources.Load<Mesh>("Mesh/" + path.Substring(6));
        }
        Mesh temp;
        if(_meshCache.TryGetValue(path, out temp))
        {
            return temp;
        }
        else
        {
            UnityWebRequest webRequest = await GetRequest(path);
            if(webRequest .result == UnityWebRequest.Result.Success){
                Mesh mesh = await FileReader.ReadObjFile (webRequest.downloadHandler.text);
                if(!_meshCache.TryGetValue(path, out temp))
                {
                    _meshCache.Add(path, mesh);
                }else{
                    _meshCache[path] = mesh;
                }
                
        		return mesh;
            }
            return null;
        }
    }
    
    public static async Task<Texture2D> LoadTexture (string path) {
    
        if(path == ""){
            return null;
        }else if(path.Substring(0, 6) == "local:"){
            return Resources.Load<Texture2D>("Texture/" + path.Substring(6));
        }
        Texture2D temp;
        if(_textureCache.TryGetValue(path, out temp))
        {
            return temp;
        }
        else
        {   
           
            UnityWebRequest webRequest = await GetRequest(path);
            if(webRequest.result == UnityWebRequest.Result.Success){
                Texture2D texture = new Texture2D(2, 2);
                texture.LoadImage(webRequest.downloadHandler.data);
                
                if(!_textureCache.TryGetValue(path, out temp))
                {
                    _textureCache.Add(path, texture);
                }else{
                    _textureCache[path] = texture;
                }
        		return texture;
            }
            return null;
        }
    }
    
    public static async Task<UnityWebRequest> GetRequest(string uri,string json)
    {
        return await GetRequest(uri,JsonConvert.DeserializeObject<Dictionary<string, string>>(json));
    }
    
    public static async Task<UnityWebRequest> GetRequest (string uri,Dictionary<string, string> form = null) 
    {
        
        UnityWebRequest webRequest;
        if(form != null){
        
            WWWForm wwwForm = new WWWForm();
            
            foreach(KeyValuePair<string, string> entry in form)
            {
                wwwForm.AddField( entry.Key, entry.Value );
            }
            webRequest = UnityWebRequest.Post(uri,wwwForm);
            
        }else{
            webRequest = UnityWebRequest.Get(uri);
        }
        
        
        // Request and wait for the desired page.
        await webRequest.SendWebRequest();
        
        return webRequest;
        
        /*switch (webRequest.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                return "Error : " + webRequest.error;
                break;
            case UnityWebRequest.Result.ProtocolError:
                Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                return "Error : " + webRequest.error;
                break;
            case UnityWebRequest.Result.Success:
                return webRequest.downloadHandler.text;
                break;
        }*/
            
    }
    
    
    
    
    
}