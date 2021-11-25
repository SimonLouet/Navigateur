using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using System.Reflection.Emit;
using System.IO;

public class Documentation : MonoBehaviour
{

    public Type[] _className = {(typeof(Entity)),(typeof(TransformWeb)),(typeof(Page)),(typeof(Header)), (typeof(User))};
    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0;x < _className.Length;x++){
            // Get the public methods.
            GenerateHtml(_className[x]);
        }
    }


    
    public string TypeToHtml(Type type){
        for(int x = 0;x < _className.Length;x++){
            if(_className[x] == type){
                return "<a href=\"./"+type+".html\">"+type+"</a>";
            }
        }
        return "" + type;
    
    }
    
    // Update is called once per frame
    public void GenerateHtml(Type type)
    {
        string html = "<h2>"+type.Name+"</h2></br>";
        html += "<h3>Description</h3></br></br>";
        
        html += "<h3>Fonction</h3></br>";
        MethodInfo[] methods = type.GetMethods(BindingFlags.Public|BindingFlags.Instance|BindingFlags.DeclaredOnly);
        
        for(int x = 0;x< methods.Length;x++){
            string param = "";
            ParameterInfo[] paramaterInfos = methods[x].GetParameters();
            
            foreach (ParameterInfo p in paramaterInfos)
            {
                if(param != ""){
                    param += " , ";
                }
                param += "<b>" + TypeToHtml(p.ParameterType) + "</b> " + p.Name;
            }
            html += "<b>" + TypeToHtml(methods[x].ReturnType) + "</b> " + methods[x].Name + " ( " + param+" )  <br><br>";
            
        }
        
        
        
        
        try
        {
            //Pass the filepath and filename to the StreamWriter Constructor
            StreamWriter sw = new StreamWriter("C:/Users/chloe/My project/DocJs/" + type.Name + ".html");
            //Write a line of text
            sw.WriteLine(html);
            //Close the file
            sw.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
        }

    }
}
