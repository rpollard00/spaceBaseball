// See https://aka.ms/new-console-template for more information

using SpaceBaseball.Core.NameGeneration;


NameGenerator nameGen = new();
var firstNameMarkov = new MarkovGenerator(lookbackSize: 2);
var lastNameMarkov = new MarkovGenerator(lookbackSize: 2);
nameGen.TryAddNamePool("firstName", firstNameMarkov);
nameGen.TryAddNamePool("lastName", lastNameMarkov);

var firstNameInput = GeneratorUtils.NameFileReader("./sampleFirstNames.txt");
var lastNameInput = GeneratorUtils.NameFileReader("./sampleLastNames.txt");

firstNameInput.ForEach(name => nameGen.TrainPoolOn("firstName", name));
lastNameInput.ForEach(name => nameGen.TrainPoolOn("lastName", name));

int numGenerate = 40;

for (int i = 0; i < numGenerate; i++)
{
    Console.WriteLine($"{nameGen.GetNameFromPool("firstName")} {nameGen.GetNameFromPool(selector: "lastName")}");
}