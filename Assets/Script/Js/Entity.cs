using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using Jint;
using Newtonsoft.Json;
using TMPro;
using System.Text.RegularExpressions;
 
 
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
    private string _value;
    private bool _focus;
    
    private string _text;
    private float  _textSize;
    private string _textColor;
    private string _textAlignment;
    private float _textWidth;
    private float _textHeight;
    
    private string _lightType;
    private string _lightColor;
    private float _lightRange;
    private float _lightAngle;
    private float _lightIntensity;
    
    private string _mesh;
    private string _meshCollider;
    private string _texture;
    
    private string _script;
    
    private string _onClick;
    private string _onMouseOver;
    private string _onMouseOut;
    private string _onUpdate;
    private string _onChangeValue;
    private string _onKey;
    private string _onFocus;
    private string _onBlur;
    
    
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
        SetTextSize(1);
        SetTextColor("#000000");
        SetTextAlignment("Middle-Right");
        SetTextWidth(20);
        SetTextHeight(5);
        
        SetValue("");
        SetFocus(false);
        
        SetLightType("");
        SetLightColor("#ffffff");
        SetLightRange(10);
        SetLightAngle(30);
        SetLightIntensity(1);
        
        SetMesh("");
        SetMeshCollider("");
        SetTexture("");
        
        
        SetScript("");
        SetOnClick("");
        SetOnMouseOver("");
        SetOnMouseOut("");
        SetOnUpdate("");
        SetOnChangeValue("");
        SetOnKey("");
        SetOnFocus("");
        SetOnBlur("");
        
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
        
        if(values.ContainsKey("textAlignment")){
            SetTextAlignment(values["textAlignment"].ToString());
        }
        
        if(values.ContainsKey("textWidth")){
            SetTextWidth(Convert.ToSingle(values["textWidth"]));
        }
        
        if(values.ContainsKey("textHeight")){
            SetTextHeight(Convert.ToSingle(values["textHeight"]));
        }        
        
        if(values.ContainsKey("value")){
            SetValue(values["value"].ToString());
        }
        
        if(values.ContainsKey("lightType")){
            SetLightType(values["lightType"].ToString());
        }
        
        if(values.ContainsKey("lightColor")){
            SetLightColor(values["lightColor"].ToString());
        }
        
        if(values.ContainsKey("lightRange")){
            SetLightRange(Convert.ToSingle(values["lightRange"]));
        }
        
        if(values.ContainsKey("lightAngle")){
            SetLightAngle(Convert.ToSingle(values["lightAngle"]));
        }
        
        if(values.ContainsKey("lightIntensity")){
            SetLightIntensity(Convert.ToSingle(values["lightIntensity"]));
        }
        
        
        
        
        if(values.ContainsKey("mesh")){
            SetMesh(values["mesh"].ToString());
        }
        
        if(values.ContainsKey("meshCollider")){
            SetMeshCollider(values["meshCollider"].ToString());
        }
        
        if(values.ContainsKey("texture")){
            SetTexture(values["texture"].ToString());
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
        
        if(values.ContainsKey("onUpdate")){
            SetOnUpdate(values["onUpdate"].ToString());
        }
        
        if(values.ContainsKey("onChangeValue")){
            SetOnChangeValue(values["onChangeValue"].ToString());
        }
        
        
        if(values.ContainsKey("onKey")){
            SetOnKey(values["onKey"].ToString());
        }
        
        if(values.ContainsKey("onFocus")){
            SetOnFocus(values["onFocus"].ToString());
        }
        
        if(values.ContainsKey("onBlur")){
            SetOnBlur(values["onBlur"].ToString());
        }
        
        
        
        if(values.ContainsKey("children")){
            List<object> children = new List<object>((IEnumerable<object>)values["children"]);
            for(int x = 0 ;x < children.Count;x++){
                AddChildren(new Entity(children[x].ToString()));
            }
        }
        
        if(values.ContainsKey("transform")){
            SetTransform(new TransformWeb(values["transform"].ToString()));
            _transform.SetTransform(_gameObject.transform);
        }
        
        
        
        
        
        
        
    }
    
    
    
    public async void StartScript()
    {
        if(_script != ""){
            Regex rgx = new Regex(@"^(https?|ftp|ssh|mailto):\/\/[a-z0-9\/:%_+.,#?!@&=-]+$");
            Match match = rgx.Match(_script);
            if(match.Success){
                string script = await Navigator.LoadScript(_script);
                Navigator._engine.Execute(script);
            }else {
                Navigator._engine.SetValue("entityParent", this);
                Navigator._engine.Execute(_script);
            }
            
            
            
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
            TextMeshPro textMesh = _gameObject.GetComponent<TextMeshPro>(); 
            if(textMesh != null){
                GameObject.DestroyImmediate (textMesh);
            }
            
            MeshFilter filter = _gameObject.GetComponent<MeshFilter>();   
            if(filter == null){
                MeshRenderer renderer = _gameObject.GetComponent<MeshRenderer>(); 
                if(renderer != null){
                    GameObject.DestroyImmediate (renderer);
                }
            }
        }else{
            TextMeshPro textMesh = _gameObject.GetComponent<TextMeshPro>(); 
            if(textMesh == null){
                textMesh = _gameObject.AddComponent<TextMeshPro> ();
            }
            
            // Set the text
            textMesh.text = _text;

            
            
            textMesh.fontSize  = _textSize;
            Color color;
            ColorUtility.TryParseHtmlString(_textColor, out color);
            textMesh.color = color;
            if(_textAlignment == "Upper-Left"){
                textMesh.alignment = TextAlignmentOptions.TopLeft;
            }else if(_textAlignment == "Upper-Center"){
                textMesh.alignment = TextAlignmentOptions.Top;
            }else if(_textAlignment == "Upper-Right"){
                textMesh.alignment = TextAlignmentOptions.TopRight;
            }else if(_textAlignment == "Middle-Left"){
                textMesh.alignment = TextAlignmentOptions.Left;
            }else if(_textAlignment == "Middle-Center"){
                textMesh.alignment = TextAlignmentOptions.Center;
            }else if(_textAlignment == "Middle-Right"){
                textMesh.alignment = TextAlignmentOptions.Right;
            }else if(_textAlignment == "Lower-Left"){
                textMesh.alignment = TextAlignmentOptions.BottomLeft;
            }else if(_textAlignment == "Lower-Center"){
                textMesh.alignment = TextAlignmentOptions.Bottom;
            }else if(_textAlignment == "Lower-Right"){
                textMesh.alignment = TextAlignmentOptions.BottomRight;
            }
            textMesh.ForceMeshUpdate();
            
            if(_meshCollider == "local:text"){
                
                SetMeshCollider("local:text");
            }
        } 
    }
    
    
    public string GetText(){
        return _text;
    }
    
    
    public void SetTextWidth(float textWidth){
        _textWidth = textWidth;
        RectTransform rectTransform = _gameObject.GetComponent<RectTransform>();
        if(rectTransform != null){
            Debug.Log("qzdqzdqzdqzd");
            rectTransform.sizeDelta = new Vector2(_textWidth,_textHeight);
        }
    }
    
    public float GetTextWidth(){
        return _textWidth;
    }
    
    public void SetTextHeight(float textHeight){
        _textHeight = textHeight;
        RectTransform rectTransform = _gameObject.GetComponent<RectTransform>();
        if(rectTransform != null){
            rectTransform.sizeDelta = new Vector2(_textWidth,_textHeight);
        }
    }
    
    public float GetTextHeight(){
        return _textHeight;
    }
    
    
    public void SetTextSize(float textSize){
        _textSize = textSize;
        SetText(_text); 
    }
    
    public float GetTextSize(){
        return _textSize;
    }
    
    
    public void SetTextAlignment(string textAlignment){
        _textAlignment = textAlignment;
        SetText(_text); 
    }
    
    public string GetTextAlignment(){
        return _textAlignment;
    }
    
    
    
    public void SetTextColor(string textColor){
        _textColor = textColor;
        SetText(_text); 
    }
    
    public string GetTextColor(){
        return _textColor;
    }
    
    public void SetValue(string value){
        if(value != _value){
            _value = value;
            OnChangeValue();
        }
    }
    
    public string GetValue(){
        return _value;
    }
    
    
        
        
    
    
    public void SetLightType(string lightType){
        _lightType = lightType;
        if (_lightType == ""){
            Light light = _gameObject.GetComponent<Light>(); 
            if(light != null){
                GameObject.Destroy (light);
            }
        }else{
		    Light light = _gameObject.GetComponent<Light>(); 
            if(light == null){
                light = _gameObject.AddComponent<Light> ();
            }
            
            if(_lightType == "spot"){
                light.type = LightType.Spot;
                
                light.spotAngle = _lightAngle;
                Color color;
                ColorUtility.TryParseHtmlString(_lightColor, out color);
                light.color = color;
                light.intensity = _lightIntensity;
                light.range = _lightRange;
            }else if (_lightType == "point"){
                light.type = LightType.Point;
                
                Color color;
                ColorUtility.TryParseHtmlString(_lightColor, out color);
                light.color = color;
                light.intensity = _lightIntensity;
                light.range = _lightRange;
            }else{
                light.type = LightType.Directional;
                
                Color color;
                ColorUtility.TryParseHtmlString(_lightColor, out color);
                light.color = color;
                light.intensity = _lightIntensity;
            }
        } 
    }
    
    public string GetLightType(){
        return _lightType;
    }
    
    
    public void SetLightColor(string lightColor){
        _lightColor = lightColor;
        Light light = _gameObject.GetComponent<Light>(); 
        if(light != null){
            Color color;
            ColorUtility.TryParseHtmlString(_lightColor, out color);
            light.color = color;
        }
            
    }
    
    public string GetLightColor(){
        return _lightColor;
    }
    
    
    public void SetLightRange(float lightRange){
        _lightRange = lightRange;
        
        Light light = _gameObject.GetComponent<Light>(); 
        if(light != null){
            light.range = _lightRange;
        }
    }
    
    public float GetLightRange(){
        return _lightRange;
    }
    
    
    public void SetLightAngle(float lightAngle){
        _lightAngle = lightAngle;
        
        Light light = _gameObject.GetComponent<Light>(); 
        if(light != null){
            light.spotAngle = _lightAngle;
        }
    }
    
    public float GetLightAngle(){
        return _lightAngle;
    }
    
    
    public void SetLightIntensity(float lightIntensity){
        _lightIntensity = lightIntensity;
        
        Light light = _gameObject.GetComponent<Light>(); 
        if(light != null){
            light.intensity = _lightIntensity;
        }
    }
    
    public float GetLightIntensity(){
        return _lightIntensity;
    }
    
    
    
    
    
    
    
    
    
    
    
    
    public void SetId(string id){
        _id = id;
    }
    
    public string GetId(){
        return _id;
    }
    
    
    public void SetType(string type){
        _type = type;
        
        if(_type == "InputText"){
            SetText("...");
            SetOnMouseOver("entityParent.SetTextColor(\"#FFFFFF\");");
            SetOnMouseOut("if(entityParent.GetFocus()){entityParent.SetTextColor(\"#D5D5D5\");}else{entityParent.SetTextColor(\"#000000\");}");
            SetOnFocus("entityParent.SetTextColor(\"#D5D5D5\");entityParent.SetText(entityParent.GetValue() + \"|\");");
            SetOnBlur("entityParent.SetTextColor(\"#000000\");if(entityParent.GetValue() == \"\"){entityParent.SetText(\"...\");}else{entityParent.SetText(entityParent.GetValue());}");
            SetOnKey("if(entityParent.GetFocus()){var text = entityParent.GetValue(); if(key != \"\\b\" && key != \"\\n\" && key != \"\\r\"){text += key;}else if(key == \"\\b\"){text = text.slice(0, -1);}entityParent.SetValue(text);}");
            SetMeshCollider("local:text");
            SetOnChangeValue("if(entityParent.GetFocus()){entityParent.SetText(entityParent.GetValue() + \"|\");}else{entityParent.SetText(entityParent.GetValue());}");
        }
    }
    
    public string GetType(){
        return _type;
    }
    
    
    public void SetFocus(bool focus){
        
        if(focus){
            if(!_focus){
                _focus = true;
                Navigator.GetPage().SetFocusEntity(this);
                OnFocus();
            }
        }else{
            if(_focus){
                _focus = false;
                Navigator.GetPage().SetFocusEntity(null);
                OnBlur();
            }
        }
    }
    
    public bool GetFocus(){
        return _focus;
    }
    
    
    
    
    public async void SetMesh(string path)
    {
        _mesh = path;
        if (path == ""){
            MeshFilter filter = _gameObject.GetComponent<MeshFilter>();   
            if(filter != null){
                GameObject.DestroyImmediate (filter);
            }
            
            TextMeshPro textMesh = _gameObject.GetComponent<TextMeshPro>(); 
            if(textMesh == null){
    		    MeshRenderer renderer = _gameObject.GetComponent<MeshRenderer>(); 
                if(renderer != null){
                    GameObject.DestroyImmediate (renderer);
                }
            }
        }else{
		    MeshRenderer renderer = _gameObject.GetComponent<MeshRenderer>(); 
            if(renderer == null){
                renderer = _gameObject.AddComponent<MeshRenderer> ();
            }
            
            TextMeshPro textMesh = _gameObject.GetComponent<TextMeshPro>(); 
            if(textMesh != null){
                GameObject.DestroyImmediate (textMesh);
            }
            
            MeshFilter filter = _gameObject.GetComponent<MeshFilter>(); 
            if(filter == null){
                filter = _gameObject.AddComponent<MeshFilter> ();
            }
            
            renderer.material = Navigator._materiel;
            Mesh mesh = await Navigator.LoadMesh(path);
            filter.mesh = mesh;
            SetTexture(_texture);
        }        
    }   
    
    public string GetMesh(){
        return _mesh;
    }
    
    
    public async void SetMeshCollider(string path)
    {
        _meshCollider = path;
        if (path == ""){
            BoxCollider boxCollider = _gameObject.GetComponent<BoxCollider>(); 
            if(boxCollider != null){
                GameObject.DestroyImmediate (boxCollider);
            }
            
            MeshCollider collider = _gameObject.GetComponent<MeshCollider>();   
            if(collider != null){
                GameObject.DestroyImmediate (collider);
            }
            
        }else{
        
            MeshCollider collider = _gameObject.GetComponent<MeshCollider>();
            GameObject.DestroyImmediate (collider);
            collider = _gameObject.AddComponent<MeshCollider> ();
            
                
                
            if(_meshCollider == "local:text"){
                collider.convex = true;
            }else{
                Mesh mesh = await Navigator.LoadMesh(path);
                collider.sharedMesh = mesh;
                collider.convex = false;
            }
            
            
            
            
        }
    }  
    
    public string GetMeshCollider(){
        return _meshCollider;
    }
    
    
    public async void SetTexture(string path)
    {
        _texture = path;
        if (path == ""){
            MeshRenderer renderer = _gameObject.GetComponent<MeshRenderer>(); 
            if(renderer != null){
                renderer.material.mainTexture = null;
            }
            
            
        }else{
            MeshRenderer renderer = _gameObject.GetComponent<MeshRenderer>(); 
            if(renderer != null){
                renderer.material.mainTexture = await Navigator.LoadTexture(path);
            }
            
        }
    }  
    
    public string GetTexure(){
        return _texture;
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
            Navigator._engine.SetValue("entityParent", this);
            Navigator._engine.Execute(_onClick);
            
        }
    } 
    
    public void SetOnClick(string onClick){
        _onClick = onClick;
    }
    
    public string GetOnClick(){
        return _onClick;
    }
    
    
    
    public void OnUpdate(float deltatime)
    {   
        
        if(_onUpdate != ""){
            Navigator._engine.SetValue("deltaTime", deltatime);
            Navigator._engine.SetValue("entityParent", this);
            Navigator._engine.Execute(_onUpdate);
            
        }
    } 
    
    public void SetOnUpdate(string onUpdate){
        _onUpdate = onUpdate;
    }
    
    public string GetOnUpdate(){
        return _onUpdate;
    }
    
    
    
    
    
    
    public void OnMouseOver()
    {   
        
            
        Navigator.AfficherLien(_href);
        if(_onMouseOver != ""){
            Navigator._engine.SetValue("entityParent", this);
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
            Navigator._engine.SetValue("entityParent", this);
            Navigator._engine.Execute(_onMouseOut);
            
        }
        
    } 
    
    public void SetOnMouseOut(string onMouseOut){
        _onMouseOut = onMouseOut;
    }
    
    public string GetOnMouseOut(){
        return _onMouseOut;
    }
    
    public void OnChangeValue()
    {   
        if(_onChangeValue != "" && _onChangeValue != null){
            Navigator._engine.SetValue("entityParent", this);
            Navigator._engine.Execute(_onChangeValue);
            
        }
    } 
    
    public void SetOnChangeValue(string onChangeValue){
        _onChangeValue = onChangeValue;
    }

    public string GetOnChangeValue(){
        return _onChangeValue;
    }
    
    
    
    
    
    public void OnKey(string key)
    {   
        
        if(_onKey != ""){
            Navigator._engine.SetValue("entityParent", this);
            Navigator._engine.SetValue("key", key);
            Navigator._engine.Execute(_onKey);
            
        }
    } 
    
    public void SetOnKey(string onKey){
        _onKey = onKey;
    }
    
    public string GetOnKey(){
        return _onKey;
    }
    
    
    
    public void OnFocus()
    {   
        
        if(_onFocus != ""){
            Navigator._engine.SetValue("entityParent", this);
            Navigator._engine.Execute(_onFocus);
            
        }
    } 
    
    public void SetOnFocus(string onFocus){
        _onFocus = onFocus;
    }
    
    public string GetOnFocus(){
        return _onFocus;
    }
    
    
    
    
    public void OnBlur()
    {   
        
        if(_onBlur != ""){
            Navigator._engine.SetValue("entityParent", this);
            Navigator._engine.Execute(_onBlur);
            
        }
    } 
    
    public void SetOnBlur(string onBlur){
        _onBlur = onBlur;
    }
    
    public string GetOnBlur(){
        return _onBlur;
    }
    
    
    
    
    
    



    
    
    public void Destroy()
    {
        GameObject.Destroy(_gameObject);
        _transform.Destroy();
    }
    
    
}