using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ArtisticSanctuarySkating
{
    class FileLogger
    {
        #region Instanced Variables

        string _strFileName = null, _strFileType = null;

        #endregion

        #region Constructors

        public FileLogger(string pStrFileName, string pStrFileType)
        {
            _strFileName = pStrFileName;
            _strFileType = pStrFileType;
        }

        #endregion

        #region Accessors

        /// <method>
        /// Reads the error
        /// </method>
        public void read()
        {
            if (_strFileType == "Text")
            {
                readFromTextFile();
            }
            else if (_strFileType == "Binary")
            {
                readFromBinaryFile();
            }
        }

        /// <method>
        /// Checks if error is alraedy logged
        /// on current line.
        /// </method>
        private void readFromTextFile()
        {
            FileStream inFile = new FileStream(_strFileName, FileMode.Open, FileAccess.Read);

            StreamReader reader = new StreamReader(inFile);

            string strInText = reader.ReadLine();
            Console.Write(strInText);
            Console.ReadLine();

            reader.Close();
            inFile.Close();
        }

        /// <method>
        /// Checks if error is alraedy logged
        /// on current line.
        /// </method>
        private void readFromBinaryFile()
        {
            FileStream inFile = new FileStream(_strFileName, FileMode.Open, FileAccess.Read);

            BinaryReader reader = new BinaryReader(inFile);

            string strInText = reader.ReadString();
            Console.Write(strInText);
            Console.ReadLine();

            reader.Close();
            inFile.Close();
        }

        #endregion

        #region Mutators

        /// <method>
        /// Writes data to textfile or binary file
        /// </method>
        /// <param name="pStrText">Get's the current error in C# Output</param>
        public void write(string pStrText)
        {
            if (_strFileType == "Text")
            {
                writeToTextFile(pStrText);
            }
            else if (_strFileType == "Binary")
            {
                writeToBinaryFile(pStrText); 
            }
        }

        /// <method>
        /// Appends writing to the end of current line.
        /// </method>
        /// <param name="pStrText">Get's the current error in C# Output</param>
        private void writeToTextFile(string pStrText)
        {
            FileStream outFile = new FileStream(_strFileName, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(outFile);

            writer.Write(pStrText);
            writer.Close();
            outFile.Close();
        }

        /// <method>
        /// Appends writing to the end of current line.
        /// </method>
        /// <param name="pStrText">Get's the current error in C# Output</param>
        private void writeToBinaryFile(string pStrText)
        {
            FileStream outFile = new FileStream(_strFileName, FileMode.Append, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(outFile);

            writer.Write(pStrText);
            writer.Close();
            outFile.Close();
        }

        #endregion
    }
}
