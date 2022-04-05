using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;

namespace Task2_ITransition
{
    public class DataExtractor
    {
        public byte [] GetBinaryData()
        {
            
            using (BinaryReader reader = new BinaryReader(File.Open("Sample/file_00.data", FileMode.Open)))
            {
                int count = 0;
                while (reader.PeekChar() > -1)
                {
                    byte data1 = reader.ReadByte();
                    count++;
                }
                byte[] data = new byte[count];
                while (reader.PeekChar() > -1)
                {
                    data = reader.ReadBytes(count);
                }
                return data;
            }
        }

        public void PutBinaryData(byte [] data)
        {
            using (var writer = new BinaryWriter(File.Open("Sample/new.data", FileMode.OpenOrCreate)))
            {
                writer.Write(data);
            }
        }
    }
}
