using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Logical
{
  internal class FileSave
  {
    public static void saveFile(string equation, List<Gates.GateObject> diagram, List<Gates.GateObject> processing, string path)
    {
      FileSave.SaveData saveData = new FileSave.SaveData();
      saveData.equation = equation;
      saveData.diagram = diagram;
      saveData.processing = processing;
      Stream serializationStream = (Stream) File.Open(path, FileMode.Create);
      new BinaryFormatter().Serialize(serializationStream, (object) saveData);
      serializationStream.Close();
    }

    public static FileSave.SaveData loadFile(string path)
    {
      Stream serializationStream = (Stream) File.Open(path, FileMode.Open);
      FileSave.SaveData saveData = (FileSave.SaveData) new BinaryFormatter().Deserialize(serializationStream);
      serializationStream.Close();
      return saveData;
    }

    public static void saveOptions(string defPath, bool binary)
    {
      FileSave.OptionData optionData = new FileSave.OptionData();
      optionData.defaultPath = defPath;
      optionData.useBinary = binary;
      Stream serializationStream = (Stream) File.Open("settings.set", FileMode.Create);
      new BinaryFormatter().Serialize(serializationStream, (object) optionData);
      serializationStream.Close();
    }

    public static FileSave.OptionData grabOptions()
    {
      try
      {
        Stream serializationStream = (Stream) File.Open("settings.set", FileMode.Open);
        FileSave.OptionData optionData = (FileSave.OptionData) new BinaryFormatter().Deserialize(serializationStream);
        serializationStream.Close();
        return optionData;
      }
      catch (IOException ex)
      {
        FileSave.saveOptions("C:", true);
        int num = (int) MessageBox.Show("Options reverted back to defaults.");
        return new FileSave.OptionData();
      }
    }

    [Serializable]
    public struct SaveData
    {
      public string equation;
      public List<Gates.GateObject> diagram;
      public List<Gates.GateObject> processing;
    }

    [Serializable]
    public struct OptionData
    {
      public bool useBinary;
      public string defaultPath;
    }
  }
}
