using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LZWDescomprimir
{
    public class Operaciones
    {

        public string path = "";
        public string raiz = "";

        public Operaciones(string path, string root)
        {
            this.path = path;
            this.raiz = root;

        }

        public void Comprimir()
        {
            string raiz2 = raiz;
            raiz = raiz + @"\\Escritoriovpn.hdef";
            HuffmanEncodeFile hef = new HuffmanEncodeFile(@path, @raiz);
            byte[] b = hef.Encode();
            raiz = @"..\\..\\..\\Comprimido.huff";
            File.WriteAllBytes(@raiz, b);
        }

        public void Descomporimir()
        {
            string raiz2 = raiz;
            string raiz3 = raiz;
            raiz = @"..\\..\\..\\Comprimido.huff";
            byte[] fileBytes = Archivo.GetArchivoBytes(@"..\\..\\..\\Comprimido.huff");
            raiz3 = @"Arbol\\Escritoriovpn.hdef";
            string bb = HuffmanEncodeFile.Decode(fileBytes, @raiz3);
            raiz = raiz2 + @"..\\..\\DescomprimidoHuff.txt";
            File.WriteAllText(@raiz, bb);
        }
    }
}
