using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using Jint;
using Newtonsoft.Json;
using TMPro;

public class TransformWeb
{
    private float _posX = 0; 
    private float _posY = 0;
    private float _posZ = 0;
    
    private float _rotX = 0;
    private float _rotY = 0;
    private float _rotZ = 0;
    
    private float _scaleX = 1;
    private float _scaleY = 1;
    private float _scaleZ = 1;
    
    private Transform _transform = null;
    
    public TransformWeb(){
    
    }
    
    public TransformWeb(string json){
        var values =  JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
        if(values.ContainsKey("posX")){
            SetPosX(Convert.ToSingle(values["posX"]));
        }
        if(values.ContainsKey("posY")){
            SetPosY(Convert.ToSingle(values["posY"]));
        }
        if(values.ContainsKey("posZ")){
            SetPosZ(Convert.ToSingle(values["posZ"]));
        }
        
        if(values.ContainsKey("rotX")){
            SetRotX(Convert.ToSingle(values["rotX"]));
        }
        if(values.ContainsKey("rotY")){
            SetRotY(Convert.ToSingle(values["rotY"]));
        }
        if(values.ContainsKey("rotZ")){
            SetRotZ(Convert.ToSingle(values["rotZ"]));
        }
        
        if(values.ContainsKey("scaleX")){
            SetScaleX(Convert.ToSingle(values["scaleX"]));
        }
        if(values.ContainsKey("scaleY")){
            SetScaleY(Convert.ToSingle(values["scaleY"]));
        }
        if(values.ContainsKey("scaleZ")){
            SetScaleZ(Convert.ToSingle(values["scaleZ"]));
        }
    }
    
    
    public float GetPosX(){
        return _posX;
    }
    
    public void SetPosX(float posX){
        _posX = posX;
        if (_transform != null){
            if(_transform.GetComponent<Character>()){
                _transform.GetComponent<Character>().SetPosition(new Vector3(_posX,_posY,_posZ));
            }
            _transform.localPosition = new Vector3(_posX,_posY,_posZ);
        }
    }
    
    
    public float GetPosY(){
        return _posY;
    }
    
    public void SetPosY(float posY){
        _posY = posY;
        if (_transform != null){
            if(_transform.GetComponent<Character>()){
                _transform.GetComponent<Character>().SetPosition(new Vector3(_posX,_posY,_posZ));
            }
            _transform.localPosition = new Vector3(_posX,_posY,_posZ);
        }
    }
    
    
    public float GetPosZ(){
        return _posZ;
    }
    
    public void SetPosZ(float posZ){
        _posZ = posZ;
        if (_transform != null){
            if(_transform.GetComponent<Character>()){
                _transform.GetComponent<Character>().SetPosition(new Vector3(_posX,_posY,_posZ));
            }
            _transform.localPosition = new Vector3(_posX,_posY,_posZ);
        }
    }
    
    
    public float GetRotX(){
        return _rotX;
    }
    
    public void SetRotX(float rotX){
        _rotX = rotX;
        if (_transform != null){
            if(_transform.GetComponent<Character>()){
                _transform.GetComponent<Character>().SetRotation(new Vector3(_rotX,_rotY,_rotZ));
            }
            _transform.localEulerAngles = new Vector3(_rotX,_rotY,_rotZ);
        }
    }
    
    
    public float GetRotY(){
        return _rotY;
    }
    
    public void SetRotY(float rotY){
        _rotY = rotY;
        if (_transform != null){
            if(_transform.GetComponent<Character>()){
                _transform.GetComponent<Character>().SetRotation(new Vector3(_rotX,_rotY,_rotZ));
            }
            _transform.localEulerAngles = new Vector3(_rotX,_rotY,_rotZ);
        }
    }
    
    
    public float GetRotZ(){
        return _rotZ;
    }
    
    public void SetRotZ(float rotZ){
        _rotZ = rotZ;
        if (_transform != null){
            if(_transform.GetComponent<Character>()){
                _transform.GetComponent<Character>().SetRotation(new Vector3(_rotX,_rotY,_rotZ));
            }
            _transform.localEulerAngles = new Vector3(_rotX,_rotY,_rotZ);
        }
    }
    
    
    public float GetScaleX(){
        return _scaleX;
    }
    
    public void SetScaleX(float scaleX){
        _scaleX = scaleX;
        if (_transform != null){
            _transform.localScale = new Vector3(_scaleX,_scaleY,_scaleZ);
        }
    }
    
    
    public float GetScaleY(){
        return _scaleY;
    }
    
    public void SetScaleY(float scaleY){
        _scaleY = scaleY;
        if (_transform != null){
            _transform.localScale = new Vector3(_scaleX,_scaleY,_scaleZ);
        }
    }
    
    
    public float GetScaleZ(){
        return _scaleZ;
    }
    
    public void SetScaleZ(float scaleZ){
        _scaleZ = scaleZ;
        if (_transform != null){
            _transform.localScale = new Vector3(_scaleX,_scaleY,_scaleZ);
        }
    }
    
    
    public void SetTransform(Transform transform){
        _transform = transform;
        if (_transform != null){
            if(_transform.GetComponent<Character>()){
                _transform.GetComponent<Character>().SetPosition(new Vector3(_posX,_posY,_posZ));
                _transform.GetComponent<Character>().SetRotation(new Vector3(_rotX,_rotY,_rotZ));
            }
            _transform.localPosition = new Vector3(_posX,_posY,_posZ);
            _transform.localEulerAngles = new Vector3(_rotX,_rotY,_rotZ);
            _transform.localScale = new Vector3(_scaleX,_scaleY,_scaleZ);
        }
    }
    
    public void Destroy()
    {
        GameObject.Destroy(_transform);
    }
}


public class Entity
{
    

    private string _tag;
    private string _id;
    private string _type;
    private string _href;
    private string _text;
    private float _textSize;
    private string _textColor;
    
    private string _mesh;
    private string _meshCollider;
    private string _texture;
    
    private string _script;
    
    private string _onClick;
    private string _onMouseOver;
    private string _onMouseOut;
    
    
    private TransformWeb _transform;
    
    private List<Entity> _children = new List<Entity>();
    
    private GameObject _gameObject;
    
    
    public Entity()
    {   
        Navigator.GetPage().AddEntity(this);
        SetGameObject(new GameObject("Name"));
        
        SetTag("");
        SetId("");
        SetType("");
        SetHref("");
        SetText("");
        
        SetMesh("");
        SetMeshCollider("");
        
        
        SetScript("");
        SetOnClick("");
        SetOnMouseOver("");
        SetOnMouseOut("");
        
        SetTransform(new TransformWeb());
        _transform.SetTransform(_gameObject.transform);
    }
    
    public Entity(string json):this()
    {
        var values =  JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
        
        if(values.ContainsKey("tag")){
            SetTag(values["tag"].ToString());
        }
        
        if(values.ContainsKey("id")){
            SetId(values["id"].ToString());
        }
        
        if(values.ContainsKey("type")){
            SetType(values["type"].ToString());
        }
        
        if(values.ContainsKey("href")){
            SetHref(values["href"].ToString());
        }
        
        if(values.ContainsKey("text")){
            SetText(values["text"].ToString());
        }
        
        if(values.ContainsKey("textSize")){
            SetTextSize(Convert.ToSingle(values["textSize"]));
        }
        
        if(values.ContainsKey("textColor")){
            SetTextColor(values["textColor"].ToString());
        }
        
        
        if(values.ContainsKey("mesh")){
            SetMesh(values["mesh"].ToString());
        }
        
        if(values.ContainsKey("meshCollider")){
            SetMeshCollider(values["meshCollider"].ToString());
        }
        
        
        if(values.ContainsKey("script")){
            SetScript(values["script"].ToString());
        }
        
        if(values.ContainsKey("onClick")){
            SetOnClick(values["onClick"].ToString());
        }
        
        if(values.ContainsKey("onMouseOver")){
            SetOnMouseOver(values["onMouseOver"].ToString());
        }
        
        
        if(values.ContainsKey("onMouseOut")){
            SetOnMouseOut(values["onMouseOut"].ToString());
        }
        
        
        
        if(values.ContainsKey("transform")){
            SetTransform(new TransformWeb(values["transform"].ToString()));
            _transform.SetTransform(_gameObject.transform);
        }
        
        
        if(values.ContainsKey("children")){
            List<object> children = new List<object>((IEnumerable<object>)values["children"]);
            for(int x = 0 ;x < children.Count;x++){
                AddChildren(new Entity(children[x].ToString()));
            }
        }
        
        
    }
    
    
    
    public void StartScript()
    {
        if(_script != ""){
            Navigator._engine.Execute(_script);
        }
    }
    
    
    public void SetTag(string tag){
        _tag = tag;
    }
    
    public string GetTag(){
        return _tag;
    }
    
    public void SetHref(string href){
        _href = href;
    }
    
    public string GetHref(){
        return _href;
    }
    
    
    public void SetText(string text){
        _text = text;
        if (_text == ""){
            TextMesh textMesh = _gameObject.GetComponent<TextMesh>(); 
            if(textMesh != null){
                GameObject.Destroy (textMesh);
            }
            
            MeshFilter filter = _gameObject.GetComponent<MeshFilter>();   
            if(filter == null){
                MeshRenderer renderer = _gameObject.GetComponent<MeshRenderer>(); 
                if(renderer != null){
                    GameObject.Destroy (renderer);
                }
            }
        }else{
            
		    MeshRenderer renderer = _gameObject.GetComponent<MeshRenderer>(); 
            if(renderer == null){
                renderer = _gameObject.AddComponent<MeshRenderer> ();
            }
            
            MeshFilter filter = _gameObject.GetComponent<MeshFilter>();   
            if(filter != null){
                GameObject.Destroy (filter);
            }
            
            TextMesh textMesh = _gameObject.GetComponent<TextMesh>(); 
            if(textMesh == null){
                textMesh = _gameObject.AddComponent<TextMesh> ();
            }
            
            textMesh.text = _text;
            textMesh.characterSize = _textSize;
            Color color;
            ColorUtility.TryParseHtmlString(_textColor, out color);
            textMesh.color = color;
        } 
    }
    
    public string GetText(){
        return _text;
    }
    
    public void SetTextSize(float textSize){
        _textSize = textSize;
        SetText(_text); 
    }
    
    public float GetTextSize(){
        return _textSize;
    }
    
    public void SetTextColor(string textColor){
        _textColor = textColor;
        SetText(_text); 
    }
    
    public string GetTextColor(){
        return _textColor;
    }
    
    
    
    public void SetId(string id){
        _id = id;
    }
    
    public string GetId(){
        return _id;
    }
    
    
    public void SetType(string type){
        _type = type;
    }
    
    public string GetType(){
        return _type;
    }
    
    
    public async void SetMesh(string path)
    {
        _mesh = path;
        if (path == ""){
            MeshFilter filter = _gameObject.GetComponent<MeshFilter>();   
            if(filter != null){
                GameObject.Destroy (filter);
            }
            
            TextMesh textMesh = _gameObject.GetComponent<TextMesh>(); 
            if(textMesh == null){
    		    MeshRenderer renderer = _gameObject.GetComponent<MeshRenderer>(); 
                if(renderer != null){
                    GameObject.Destroy (renderer);
                }
            }
        }else{
		    MeshRenderer renderer = _gameObject.GetComponent<MeshRenderer>(); 
            if(renderer == null){
                renderer = _gameObject.AddComponent<MeshRenderer> ();
            }
            
            TextMesh textMesh = _gameObject.GetComponent<TextMesh>(); 
            if(textMesh != null){
                GameObject.Destroy (textMesh);
            }
            
            MeshFilter filter = _gameObject.GetComponent<MeshFilter>(); 
            if(filter == null){
                filter = _gameObject.AddComponent<MeshFilter> ();
            }
            
            renderer.material = Navigator._materiel;
            Mesh mesh = await Navigator.LoadMesh(path);
            filter.mesh = mesh;
        }        
    }   
    
    public string GetMesh(){
        return _mesh;
    }
    
    
    public async void SetMeshCollider(string path)
    {
        _meshCollider = path;
        if (path == ""){
            MeshCollider collider = _gameObject.GetComponent<MeshCollider>();   
            if(collider != null){
                GameObject.Destroy (collider);
            }
            
        }else{
            MeshCollider collider = _gameObject.GetComponent<MeshCollider>();
            if(collider == null){
                collider = _gameObject.AddComponent<MeshCollider> ();
            }
            
            Mesh mesh = await Navigator.LoadMesh(path);
            collider.sharedMesh = mesh;
        }
    }  
    
    public string GetMeshCollider(){
        return _meshCollider;
    }
    
    
    public void SetScript(string script)
    {
        _script = script;
    }  
    
    public string GetScript()
    {
        return _script;
    } 
    
    
    public void SetTransform(TransformWeb transform)
    {
        _transform = transform;
        if(_gameObject != null){
            _transform.SetTransform(_gameObject.transform);
        }
    }  
    
    public TransformWeb GetTransform()
    {
        return _transform;
    } 
    
    
    
    public void AddChildren(Entity entity)
    {
        _children.Add(entity);
        entity._gameObject.transform.parent = _gameObject.transform;
    } 
    
    
    public void SetGameObject(GameObject gameObject)
    {   
        _gameObject = gameObject;
        
        if (_transform != null){
            _transform.SetTransform(_gameObject.transform);
        }
        
        EntityComponent entityComponent = _gameObject.GetComponent<EntityComponent>();
        if(entityComponent == null){
            entityComponent = _gameObject.AddComponent<EntityComponent> ();
        }
        
        entityComponent._entity = this;
        
    } 
    
    
    public void OnClick()
    {   
        if(_href != ""){
            Navigator.RedirectPage(_href);
            
        }
        
        if(_onClick != ""){
            Navigator._engine.Execute(_onClick);
        }
    } 
    
    public void SetOnClick(string onClick){
        _onClick = onClick;
    }
    
    public string GetOnClick(){
        return _onClick;
    }
    
    
    
    
    
    public void OnMouseOver()
    {   
        
            
        Navigator.AfficherLien(_href);
        if(_onMouseOver != ""){
            Navigator._engine.Execute(_onMouseOver);
        }
        
    } 
    
    public void SetOnMouseOver(string onMouseOver){
        _onMouseOver = onMouseOver;
    }
    
    public string GetOnMouseOver(){
        return _onMouseOver;
    }
    
    
    
    
    
    public void OnMouseOut()
    {   
        Navigator.AfficherLien("");
        if(_onMouseOut != ""){
            Navigator._engine.Execute(_onMouseOut);
        }
        
    } 
    
    public void SetOnMouseOut(string onMouseOut){
        _onMouseOut = onMouseOut;
    }
    
    public string GetOnMouseOut(){
        return _onMouseOut;
    }
    
    
    
    

    
    
    public void Destroy()
    {
        GameObject.Destroy(_gameObject);
        _transform.Destroy();
    }
    
    
}