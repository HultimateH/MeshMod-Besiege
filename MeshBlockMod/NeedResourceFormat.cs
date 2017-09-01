﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace XultimateX.MeshBlockMod
{

    /// <summary>
    /// 资源格式化
    /// </summary>
    public class NeedResourceFormat
    {

        /// <summary>
        /// 模组名
        /// </summary>
        public static string ModName = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>
        /// 模组资源文件夹路径
        /// </summary>
        public static string ModResourcePath { get; } = "/" + ModName + "/";

        /// <summary>
        /// 模组资源文件夹全路径
        /// </summary>
        public static string ModResourceFullPath { get; private set; } = Application.dataPath + "/Mods/Blocks/Resources/" + ModName + "/";

        /// <summary>
        /// 资源列表
        /// </summary>
        public List<NeededResource> NeedResources = new List<NeededResource>();

        /// <summary>
        /// 网格名列表
        /// </summary>
        public List<string> MeshNames = new List<string>();

        /// <summary>
        /// 网格全名列表
        /// </summary>
        public List<string> MeshFullNames = new List<string>();

        /// <summary>
        /// 贴图名列表
        /// </summary>
        public List<string> TextureNames = new List<string>();

        /// <summary>
        /// 贴图全名列表
        /// </summary>
        public List<string> TextureFullNames = new List<string>();


        /// <summary>
        /// 获取资源名列表
        /// </summary>
        public NeedResourceFormat()
        {
            ResourceFormat();
        }

        /// <summary>
        /// 资源格式化
        /// </summary>
        void ResourceFormat()
        {


            if (Directory.Exists(ModResourceFullPath))
            {
                FileInfo[] files = new DirectoryInfo(ModResourceFullPath).GetFiles("*", SearchOption.AllDirectories);
#if DEBUG
                Debug.Log("文件数量" + files.Length);
#endif
                for (int i = 0; i < files.Length; i++)
                {

                    string Name = files[i].Name;
                    string Fullname = ModResourcePath + Name;

                    if (Fullname.EndsWith(".obj"))
                    {

                        //Meshs.Add(MeshFromObj(files[i].FullName));
                        //LNR.Add(new NeededResource(ResourceType.Mesh, "/MeshBlockMod/" + files[i].Name));
                        //Meshs.Add(new Obj("/MeshBlockMod/"+files[i].Name).importedMesh);
                        
                        NeedResources.Add(new NeededResource(ResourceType.Mesh, Fullname));
                        MeshNames.Add(Name.Substring(0, Name.Length - 4));
                        MeshFullNames.Add(Fullname);
                        //Debug.Log(new Obj("/MeshBlockMod/" + files[i].Name, new VisualOffset(Vector3.one * 0.325f, new Vector3(0, 0, 0.5f), Vector3.zero)).objName);
                        //Debug.Log("Name:" + files[i].Name);
                        //Debug.Log("FullName:" + files[i].FullName);
                        //Debug.Log("DirectoryName:" + files[i].DirectoryName);
                        continue;
                    }

                    if (files[i].Name.EndsWith(".png"))
                    {
                        //Textures.Add(new WWW("File:///"  + ResourcePath).texture);
                        //TextureNames.Add(files[i].Name.Substring(0, files[i].Name.Length - 4));
                        NeedResources.Add(new NeededResource(ResourceType.Texture, Fullname));
                        TextureNames.Add(Name.Substring(0, Name.Length - 4));
                        TextureFullNames.Add(Fullname);
                        continue;
                    }


                }
            }
            else
            {
                Directory.CreateDirectory(ModResourceFullPath);
            }
        }      
    }

}