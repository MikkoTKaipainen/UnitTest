using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using UnitTestExample;
using System.IO;

namespace UnitTestDemo
{
    public class FileExampleTest
    {
        [Fact]
        public void LoadTextFile_ValidFileNameLenght_ReturnTrue()
        {
            //Ei staattinen joten tehdään olio
            FileExample fileExample = new FileExample();
            ////Actual
            var actual = fileExample.LoadTextFile("Tämä on validi tiedoston nimi");
            //Assert
            Assert.True(actual.Length > 0);           
        }

        [Fact]
        public void LoadTextFile_InvalidFileNameLenght_ReturnException()
        {
            //Ei staattinen joten tehdään olio
            FileExample fileExample = new FileExample();
            //Actual, ei tarvittu lambda lauseen vuoksi(Assert)
            //var actual = fileExample.LoadTextFile("Tämä on validi tiedoston nimi");
            //Assert vaihtoehtoinen
            //Assert.Throws<FileNotFoundException>(() => fileExample.LoadTextFile(""));
            Assert.Throws<ArgumentException>("file", () => fileExample.LoadTextFile(""));

        }
    }
}
