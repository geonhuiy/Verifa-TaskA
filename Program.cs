using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace Task0703
{
    class Program
    {

        static void Main(string[] args)
        {
            Splitter splitter = new Splitter();
            splitter.Split();
        }
    }

    public class Splitter
    {
        //Directory to json here ("input.json" if located in the same directory)
        private string fileDir = "input.json";
        //Dynamic lists to store desired results
        private List<dynamic> redList = new List<dynamic>();
        private List<dynamic> blueList = new List<dynamic>();
        private List<dynamic> otherList = new List<dynamic>();


        public void Split()
        {

            using (StreamReader streamReader = new StreamReader(fileDir))
            {
                //Reads json object and deserializes into a dynamic object
                var json = streamReader.ReadToEnd();
                dynamic list = JsonConvert.DeserializeObject(json);
                //Iterates through all items and checks for the colour values
                foreach (var item in list)
                {
                    //Adds objects based on criteria to respective lists, which is then serialized and written to corresponding json files
                    if (item.colour == "red")
                    {
                        redList.Add(item);
                        File.WriteAllText(Directory.GetCurrentDirectory() + @"\" + item.colour + ".json", JsonConvert.SerializeObject(redList));
                    }
                    else if (item.colour == "blue")
                    {
                        blueList.Add(item);
                        File.WriteAllText(Directory.GetCurrentDirectory() + @"\" + item.colour + ".json", JsonConvert.SerializeObject(blueList));
                    }
                    else
                    {
                        otherList.Add(item);
                        File.WriteAllText(Directory.GetCurrentDirectory() + @"\other.json", JsonConvert.SerializeObject(otherList));
                    }
                }
            }
        }
    }
}
