using RedRoverChallenge.Helpers;

const string inputString = "(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)";
var alphabetizedInputString = OutputHelper.AlphabetizeInputString(inputString);
var output1NestedLists = OutputHelper.ConvertStringToNestedLists(inputString);
var output1String = OutputHelper.ConvertNestedListsToString(output1NestedLists);
var output2NestedLists = OutputHelper.ConvertStringToNestedLists(alphabetizedInputString);
var output2String = OutputHelper.ConvertNestedListsToString(output2NestedLists);

Console.WriteLine("Output 1");
Console.WriteLine(string.Empty);
Console.WriteLine(output1String);
Console.WriteLine(string.Empty);
Console.WriteLine("Output 2");
Console.WriteLine(string.Empty);
Console.WriteLine(output2String);
