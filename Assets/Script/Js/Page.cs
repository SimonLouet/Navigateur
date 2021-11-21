using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using Newtonsoft.Json;


public class Page{

    private Header _header;
    private List<Entity> _entity = new List<Entity>();
    
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
    
    public void OnUpdate(){
        for(int x = 0;x < _entity.Count;x++){
            _entity[x].OnUpdate();
        }
        
    }
    
    //Header
    public Header GetHeader(){
        return _header;
    }
    
    public void SetHeader(Header header){
        _header = header;
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