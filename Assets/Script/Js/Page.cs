using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using Newtonsoft.Json;


public class Page{

    private Header _header;
    private List<Entity> _entity = new List<Entity>();
    private Entity _focusEntity;
    
    public Page(){
        SetHeader(new Header());
    }
    
    public Page(string json){
        Navigator._page = this;
        var values =  JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
        if(values.ContainsKey("header")){
            SetHeader(new Header(values["header"].ToString()));
        }else{
            SetHeader(new Header());
        }
        
        if(values.ContainsKey("scene")){
            List<object> entity = new List<object>((IEnumerable<object>)values["scene"]);
            for(int x = 0 ;x < entity.Count;x++){
                AddEntity(new Entity(entity[x].ToString()));
            }
        }
        
        
    }
    
    public void OnUpdate(float deltatime){
        for(int x = 0;x < _entity.Count;x++){
            _entity[x].OnUpdate(deltatime);
        }
        
        if(Input.inputString != ""){
            for(int x = 0;x < _entity.Count;x++){
                _entity[x].OnKey(Input.inputString);
            }
        }
        
        
    }
    
    //Header
    public Header GetHeader(){
        return _header;
    }
    
    public void SetHeader(Header header){
        _header = header;
    }
    
    public Entity GetFocusEntity(){
        return _focusEntity;
    }
    
    public void SetFocusEntity(Entity entity){
        if(entity != null){
            if(!entity.GetFocus()){
                if(_focusEntity != null){
                    _focusEntity.SetFocus(false);
                }
                entity.SetFocus(true);
                _focusEntity = entity;
            }
        }else{
            if(_focusEntity != null){
                _focusEntity.SetFocus(false);
            }
            _focusEntity = null;
        }
        
    }
    
    
    
    public Entity GetEntity(int id){
        return _entity[id];
    }
    
    public int CountEntity(){
        return _entity.Count;
    }
    
    //Entity
    public Entity GetEntityById(string id){
        for (int i = 0; i < _entity.Count; i++){
            if(_entity[i].GetId() == id){
                return _entity[i];
            }
        }
        return null;
    }
    
    //Entity
    public List<Entity> GetEntityByType(string type){
        List<Entity> entity = new List<Entity>();
        for (int i = 0; i < _entity.Count; i++){
            if(_entity[i].GetType() == type){
                entity.Add(_entity[i]);
            }
        }
        return entity;
    }
    
    public List<Entity> GetEntityByTag(string tag){
        List<Entity> entity = new List<Entity>();
        for (int i = 0; i < _entity.Count; i++){
            if(_entity[i].GetTag() == tag){
                entity.Add(_entity[i]);
            }
        }
        return entity;
    }
    
    
    public void AddEntity(Entity entity){
        _entity.Add(entity);
    }
    
    
    public void Destroy()
    {
        _header.Destroy();
        for (int i = 0; i < _entity.Count; i++){
            _entity[i].Destroy();
        }
        _entity.Clear();
    }
    
}