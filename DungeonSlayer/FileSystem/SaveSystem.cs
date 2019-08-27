using System.IO;
using System.Runtime.Serialization.Json;

namespace DungeonSlayer.FileSystem
{
    static class SaveSystem
    {
        public static void SaveCharacter()
        {
            JsonHero jsonHero = new JsonHero();
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(JsonHero));
            using (FileStream fs = new FileStream(Game.player.name + ".json", FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, jsonHero);
            }
        }

        public static void LoadCharacter(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(JsonHero));
                JsonHero jsonHero = (JsonHero)jsonFormatter.ReadObject(fs);
                jsonHero.SetValuesInPlayer();
            }
        }

        public static void DelCharacter()
        {
            if (File.Exists(Game.player.name + ".json"))
            {
                File.Delete(Game.player.name + ".json");
            }
        }
    }
}
