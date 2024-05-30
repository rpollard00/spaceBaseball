// See https://aka.ms/new-console-template for more information

using SpaceBaseball.Core.Services.Generators.NameGeneration;

NameGenerator nameGen = new();
TrainingFileDataReader trainingFileDataReader = new();

nameGen.BuildNamePool("firstName", trainingFileDataReader.ReadNamesFromFile("../data/sampleFirstNames.txt")); 
nameGen.BuildNamePool("lastName", trainingFileDataReader.ReadNamesFromFile("../data/sampleLastNames.txt")); 

var firstNameMarkov = new MarkovGenerator(lookbackSize: 2);
var lastNameMarkov = new MarkovGenerator(lookbackSize: 2);
nameGen.TryAddNamePool("firstName", firstNameMarkov);
nameGen.TryAddNamePool("lastName", lastNameMarkov);

int numGenerate = 40;

for (int i = 0; i < numGenerate; i++)
{
    Console.WriteLine($"{nameGen.GetNameFromPool("firstName")} {nameGen.GetNameFromPool(selector: "lastName")}");
}