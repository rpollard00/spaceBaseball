// See https://aka.ms/new-console-template for more information

using SpaceBaseball.Core.NameGeneration;


var nameFileReader = new TrainingFileDataReader();

NameGenerator nameGen = new(nameFileReader);

var firstNameMarkov = new NameGeneration(lookbackSize: 2);
var lastNameMarkov = new NameGeneration(lookbackSize: 2);
nameGen.TryAddNamePool("firstName", firstNameMarkov);
nameGen.TryAddNamePool("lastName", lastNameMarkov);

int numGenerate = 40;

for (int i = 0; i < numGenerate; i++)
{
    Console.WriteLine($"{nameGen.GetNameFromPool("firstName")} {nameGen.GetNameFromPool(selector: "lastName")}");
}