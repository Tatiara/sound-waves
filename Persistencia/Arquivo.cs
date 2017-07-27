using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Modelo;

namespace Persistencia 
{
    public class Arquivo<T> where T : Modelo.IId  
    {
        public static List<T> AbrirJson(string arquivo)
        {
            List<T> ret = null;
            try
            {
                using (StreamReader streamReader = new StreamReader(arquivo, Encoding.Default)) 
                using (JsonReader jsonReader = new JsonTextReader(streamReader))
                {
                    JsonSerializer json = new JsonSerializer();
                    ret = json.Deserialize<List<T>>(jsonReader);
                }
            }
            catch
            {
                ret = new List<T>();
            }
            return ret;
        }

     
        public static void SalvarJson(string arquivo, List<T> objs)
        {
            using (StreamWriter streamWriter = new StreamWriter(arquivo, false, Encoding.Default))
            using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
            {
                JsonSerializer json = new JsonSerializer();
                json.Serialize(jsonWriter, objs);
            }
        }

        public static List<T> Select(string arquivo)
        {
            return AbrirJson(arquivo);
        }

        public static void Insert(string arquivo, T obj)
        {
            List<T> objs = Select(arquivo);
            objs.Add(obj);
            SalvarJson(arquivo, objs);
        }

        public static void Update(string arquivo, T obj)
        {
            List<T> objs = Select(arquivo);
            T x = objs.Where(r => r.Id == obj.Id).Single();
            objs.Remove(x);
            objs.Add(obj);
            SalvarJson(arquivo, objs);
        }

        public static void Delete(string arquivo, T obj)
        {
            List<T> objs = Select(arquivo);
            T x = objs.Where(r => r.Id == obj.Id).Single();
            objs.Remove(x);
            SalvarJson(arquivo, objs);
        }
    }
}
