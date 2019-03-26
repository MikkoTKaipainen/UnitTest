using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using UnitTestExample.Models;
using UnitTestExample;

namespace UnitTestDemo
{
    public class DataAccessTests
    {
        [Fact]
        public void AddPersonToPeopleList_ShouldAddNewPerson_ReturnTrue()
        {
            //Arrange
            PersonModel newPerson = new PersonModel {FirstName = "James", LastName = "Bond", Age = 55 };
            List<PersonModel> people = new List<PersonModel>();
            //Act
            DataAccess.AddPersonToPeopleList(people, newPerson);
            //Assert
            Assert.True(people.Count == 1);
        }

        [Fact]
        public void AddPersonToPeopleList_ShouldAddNewPerson_ReturnContains()
        {
            //Arrange
            PersonModel newPerson = new PersonModel { FirstName = "James", LastName = "Bond", Age = 55 };
            List<PersonModel> people = new List<PersonModel>();
            //Act
            DataAccess.AddPersonToPeopleList(people, newPerson);
            //Assert
            Assert.Contains<PersonModel>(newPerson, people);
        }

        [Theory]
        [InlineData("","Bond",55,"FirstName")]
        [InlineData("James", "", 55, "LastName")]
        [InlineData("James", "Bond", null, "Age")]
        [InlineData("James", "Bond", -55, "Age")]
        [InlineData("James", "Bond", 0, "Age")]
        [InlineData(null, "Bond", 55, "FirstName")]
        [InlineData("James", null, 55, "LastName")]
        public void AddPersonToPeopleList_ShouldAddNewPerson_ReturnThrows(string firstName, string lastName, int age, string param)
        {
            //Arrange
            PersonModel newPerson = new PersonModel { FirstName = firstName, LastName = lastName, Age = age };
            List<PersonModel> people = new List<PersonModel>();
            //Act
            //DataAccess.AddPersonToPeopleList(people, newPerson);
            //Assert
            Assert.Throws<ArgumentException>(param, () => DataAccess.AddPersonToPeopleList(people, newPerson));
        }

        [Fact]
        public void ConvertModelToCsv_ShouldWork_ReturnEqual()
        {
            //Arrange
            PersonModel newPerson0 = new PersonModel { FirstName = "James", LastName = "Bond", Age = 55 };
            PersonModel newPerson1 = new PersonModel { FirstName = "James", LastName = "Bond", Age = 65 };

            List<PersonModel> people = new List<PersonModel>();
            people.Add(newPerson0);
            people.Add(newPerson1);
            List<string> expected = new List<string>() { "James,Bond,55", "James,Bond,65" };
            //Act
            var actual = DataAccess.ConvertModelsToCsv(people);
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
