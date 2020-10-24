using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LZWDescomprimir
{
    public class LZWIMP
    {

        public string path = "";
        public string root = "";

        public LZWIMP(string path, string root)
        {
            this.path = path;
            this.root = root;
        }

        public void Comprimir()
        {
            List<int> comprimido = new List<int>();
            string text = System.IO.File.ReadAllText(@path);
            comprimido = LZW.Compresion(text);
            List<char> bytecompress = new List<char>();

            foreach (int numero in comprimido)
            {
                bytecompress.Add((char)numero);
            }
            root = root + @"\\Upload\\comprimido.lzw";
            using (StreamWriter outputFile = new StreamWriter(root))
            {
                foreach (char caracter in bytecompress)
                {
                    outputFile.Write(caracter.ToString());
                }
            }
        }

        public void Descomprimir()
        {
            string descomprimido = "";

            const int bufferLength = 100;
            List<int> bytedecompress = new List<int>();

            var buffer = new char[bufferLength];
            using (var file = new FileStream(path, FileMode.Open))
            {
                using (var reader = new BinaryReader(file))
                {
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        buffer = reader.ReadChars(bufferLength);
                        foreach (var item in buffer)
                        {

                            bytedecompress.Add((int)Convert.ToChar(item));
                        }


                    }

                }

            }

            descomprimido = LZW.Descompresion(bytedecompress);
            root = root + @"\\Upload\\decomprimidoLZW.txt";
            File.WriteAllText(@root, descomprimido);
            int a = 0;
        }


    }
}
