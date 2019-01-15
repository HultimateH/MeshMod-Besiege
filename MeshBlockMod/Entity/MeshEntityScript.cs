using UnityEngine;
using System.Collections;
using Modding;
using Modding.Levels;
using System.Collections.Generic;

public class MeshEntityScript :MonoBehaviour
{
    public ResourceFormater resourcesFormater;
    public MeshEntityData meshEntityData;
    public Entity entity;

    MMenu SkinMenu;

    MSlider redSlider;
    MSlider greenSlider;
    MSlider blueSlider;
    MSlider alphaSlider;

    MeshFilter meshFilter;
    Material material;

    void Start()
    {
        if (!StatMaster.levelSimulating)
        {
    
            if (meshEntityData == null)
            {
                meshEntityData = new MeshEntityData(entity.Id);
            }

            Debug.Log(meshEntityData.ToString());

            SkinMenu = entity.InternalObject.EntityBehaviour.AddMenu("Skin", MeshMod.MeshMod.resourcesFormater.toListString().IndexOf(meshEntityData.MaterialName), MeshMod.MeshMod.resourcesFormater.toListString());
            SkinMenu.ValueChanged += (value) => { ChandedPropertise(); };

            redSlider= entity.InternalObject.EntityBehaviour.AddSlider("Red", "Red", Mathf.Clamp( meshEntityData.Color.r*255f,0,255f), 0, 255);           
            greenSlider = entity.InternalObject.EntityBehaviour.AddSlider("Green", "Green", Mathf.Clamp(meshEntityData.Color.g*255f, 0, 255f), 0, 255);          
            blueSlider = entity.InternalObject.EntityBehaviour.AddSlider("Blue", "Blue", Mathf.Clamp(meshEntityData.Color.b*255f, 0, 255f), 0, 255);           
            alphaSlider = entity.InternalObject.EntityBehaviour.AddSlider("Alpha", "Alpha", Mathf.Clamp(meshEntityData.Color.a*255f, 0, 255f), 0, 255);

            redSlider.ValueChanged += (value) => { ChandedPropertise(); };
            greenSlider.ValueChanged += (value) => { ChandedPropertise(); };
            blueSlider.ValueChanged += (value) => { ChandedPropertise(); };
            alphaSlider.ValueChanged += (value) => { ChandedPropertise(); };

            meshFilter = new List<MeshFilter>(entity.InternalObject.GetComponentsInChildren<MeshFilter>()).Find(match => match.name == "Vis");
            //material = entity.InternalObject.visualController.renderers[0].material;
            material = meshFilter.gameObject.GetComponent<MeshRenderer>().material;
            
            ChandedPropertise();
        }
      

    }

    void ChandedPropertise()
    {
        Color color = new Color(redSlider.Value / 255f, greenSlider.Value / 255f, blueSlider.Value / 255f, alphaSlider.Value / 255f);
        meshEntityData.Color = material.color = color;
        if (color.a >= 1)
        {
            material.shader = Shader.Find("Diffuse");
        }
        else
        {
            material.shader = Shader.Find("Transparent/Diffuse");
        }

        ResourceFormater.mResource mResource = MeshMod.MeshMod.resourcesFormater.mResources[SkinMenu.Value];
        meshEntityData.MaterialName = mResource.name;
        material.mainTexture = mResource.texture;
        meshFilter.mesh = mResource.mesh;
       
    }

    void Update()
    {

    }
}
