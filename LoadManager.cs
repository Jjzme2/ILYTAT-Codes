using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

namespace ILYTATTools
{
    
    public class LoadManager : MonoBehaviour
    {
   
        public static LoadManager instance;

        public DataToSave data;
        public string DataFileName = "";
        public string DataFileType = "ilytat";

        private void Awake()
        {
            if (instance == null)
            {
                DontDestroyOnLoad(this.gameObject);
                instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        private void OnEnable()
        {
            Load();
        }

        public void SaveAsNew()
        {
            string filePath = (Application.persistentDataPath + "/" + DataFileName + "." + DataFileType);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(filePath);
            bf.Serialize(file, data);
            file.Close();

            Debug.Log("Saving Data as new at " + filePath);
        }

        public void OverwriteSave()
        {
            string filePath = (Application.persistentDataPath + "/" + DataFileName + "." + DataFileType);
            BinaryFormatter bf = new BinaryFormatter();

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                FileStream file = File.Create(filePath);
                bf.Serialize(file, data);
                file.Close();
            }

            Debug.Log("Overwriting data at " + filePath);
        }

        public void DeleteSave()
        {
            string filePath = (Application.persistentDataPath + "/" + DataFileName + "." + DataFileType);
            BinaryFormatter bf = new BinaryFormatter();

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            else
            {
                Debug.Log("Unable to delete file at " + filePath + ", no file was able to be found.");
            }

            Debug.Log("Deleting data at " + filePath);
        }

        public void Load()
        {
            string filePath = (Application.persistentDataPath + "/" + DataFileName + "." + DataFileType);
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filePath))
            {
                FileStream file = File.Open(filePath, FileMode.Open);
                DataToSave loaded = (DataToSave)bf.Deserialize(file);
                data = loaded;
                file.Close();

                Debug.Log("Loading data from " + filePath);
            }
        }
    }


    [System.Serializable]
    //This is the data that will be saved to the Load manager, this must be changed per game
    public class DataToSave
    {
        
    }
}