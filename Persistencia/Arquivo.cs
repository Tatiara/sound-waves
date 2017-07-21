using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Modelo;

namespace Persistencia //mary que fez
{
    public class Arquivo<T> where T : Modelo.IId  
    {
        public static List<T> AbrirJson(string arquivo)
        {
            List<T> ret = null;
            try
            {
                using (StreamReader streamReader = new StreamReader(arquivo, Encoding.Default)) // ler as linhas de um arquivo de texto padrão.
                using (JsonReader jsonReader = new JsonTextReader(streamReader))//leitor que fornece acesso rápido para a transmissão de dados JSON serializados.
                {
                    JsonSerializer json = new JsonSerializer(); //controle de como os objetos são codificados no JSON.
                    ret = json.Deserialize<List<T>>(jsonReader);
                }
            }
            catch
            {
                ret = new List<T>();
            }
            return ret;
        }

       /* internal static List<Modelo.Usuario> Select(Arquivo<T> arquivo)// so funciona com isso 
        {
            throw new NotImplementedException();
        }*/

        public static void SalvarJson(string arquivo, List<T> objs)
        {
            using (StreamWriter streamWriter = new StreamWriter(arquivo, false, Encoding.Default))//Inicializa uma nova instância da classe StreamWriter para o arquivo especificado usando a codificação especificada e o tamanho do buffer padrão.
            using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))//Representa um escritor que fornece uma maneira rápida, não armazenada em cache, apenas para a frente de gerar dados JSON.
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
            T x = objs.Where(r => r.Id == obj.Id).Single();//O LINQ possui o método de extensão Single que pode ser usado para retornar somente um elemento em uma sequência que satisfaça uma condição específica.
            objs.Remove(x);
            objs.Add(obj);
            SalvarJson(arquivo, objs);
        }

        public static void Delete(string arquivo, T obj)
        {
            List<T> objs = Select(arquivo);
            T x = objs.Where(r => r.Id == obj.Id).Single();//O LINQ possui o método de extensão Single que pode ser usado para retornar somente um elemento em uma sequência que satisfaça uma condição específica.
            objs.Remove(x);
            SalvarJson(arquivo, objs);
        }
    }
}
//Serializar nada mais é do que colocar os valores que o objeto está utilizando juntamente com suas propriedades de uma forma que fique em série. A serialização é o processo de armazenar um objeto , incluindo todos os atributos públicos e privados para um stream.
//Deserializar é restaurar os atributos de um objeto gravado em um stream. (Este stream pode ser um arquivo binário , xml , etc.)
