using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Logical
{
  internal class Utilities
  {
    public static T DeepClone<T>(T obj)
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize((Stream) memoryStream, (object) obj);
        memoryStream.Position = 0L;
        return (T) binaryFormatter.Deserialize((Stream) memoryStream);
      }
    }
  }
}
