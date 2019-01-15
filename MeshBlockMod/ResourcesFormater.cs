using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Modding;
using UnityEngine;


public class ResourceFormater
{
    //自带预制模型的路径
    public static string PrefabPath = @"Resources\Prefabs";

    //用户自定模型路径
    public static string CustomPath = "";

    public class mResource
    {
        public string name;
        public ModMesh mesh;
        public ModTexture texture;

        public mResource(string name,string path,bool data = true)
        {
            this.name = name;
            try
            {
                mesh = ModResource.CreateMeshResource("Mesh" + name, path + name + ".obj", data);
            }
            catch(Exception e)
            {
                Debug.Log(e.Message);
            }

            try
            {
                texture = ModResource.CreateTextureResource("Texture" + name, path + name + ".png", data);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
            
        }

        public mResource(string name, ModMesh modMesh, ModTexture modTexture)
        {
            this.name = name; mesh = modMesh; texture = modTexture;
        }

        public mResource(string name)
        {
            this.name = name;mesh = ModResource.GetMesh("Mesh");texture = ModResource.GetTexture("Texture");
        }
    }

    public List<mResource> mResources;

    public ResourceFormater()
    {
        mResources = new List<mResource>();
        mResources.Add(new mResource("Default", ModResource.GetMesh("Mesh"), ModResource.GetTexture("Texture")));

        ReadResource();
        //ReadMeshs(PrefabPath);

    }


    void ReadMeshs(string path,bool data = false)
    {
        List<ModMesh> modMeshes = new List<ModMesh>();

        string[] vs = ModIO.GetFiles(path, data);

        Debug.Log("read...");
        Debug.Log(vs.Length);
        Debug.Log(vs[0]);
   

        
        //ModResource.CreateMeshResource("",)

        //foreach (var str in vs)
        //{
        //    Debug.Log(str.ToString());
        //}

    }

    void ReadResource()
    {
        if (!ModIO.ExistsDirectory("", true))
        {
            ModIO.CreateDirectory("", true);
        }

        if (!ModIO.ExistsFile("list.txt", true))
        {
            ModIO.CreateText("list.txt", true);
        }

        List<string> strs = new List<string>();

        //var textReader = ModIO.OpenText("list.txt", true);
        strs = ModIO.ReadAllLines("list.txt", Encoding.UTF8, true).ToList();
        //while (textReader.Peek()!=-1)
        //{
        //    strs.Add(textReader.ReadLine());
        //}

        if (!(strs.Count > 0)) return;

        foreach (var str in strs)
        {
            mResources.Add(new mResource(str, ""));
        }

    }

    //List<ModTexture> ReadTextures(string path,bool data = false )
    //{


    //}

    public List<string> toListString()
    {
        List<string> strs = new List<string>();
        foreach (var re in mResources)
        {
            strs.Add(re.name);
        }
        return strs;
    }

}

