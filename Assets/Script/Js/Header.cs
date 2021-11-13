using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using Newtonsoft.Json;

[Serializable]
public class Header{
    private User _user;
    
    public Header(){
        SetUser(new User());
    }
    
    public Header(string json){
        var values =  JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
        if(values.ContainsKey("user")){
            SetUser(new User(values["user"].ToString()));
        }else{
            SetUser(new User());
        }
        
    }
    
    
    //User
    public User GetUser(){
        return _user;
    }
    
    public void SetUser(User user){
        _user = user;
    }
    
    public void Destroy()
    {
        _user.Destroy();
    }
    
    
}
