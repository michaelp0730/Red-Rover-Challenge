using RedRoverChallenge.Helpers;

const string inputString = "(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)";
var output1NestedLists = Output1Helper.ConvertStringToNestedLists(inputString);
var output1String = Output1Helper.ConvertNestedListsToString(output1NestedLists);
Console.WriteLine("Output 1");
Console.WriteLine(output1String);
