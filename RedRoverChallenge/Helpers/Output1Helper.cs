namespace RedRoverChallenge.Helpers;

public static class Output1Helper
{
    public static List<object> ConvertStringToNestedLists(string inputString)
    {
        var currIndex = 0;

        List<object> ConstructList()
        {
            var resultList = new List<object>();
            var currentWord = string.Empty;

            while (currIndex < inputString.Length)
            {
                var character = inputString[currIndex++];
                currentWord = currentWord.Trim();

                switch (character)
                {
                    case '(':
                        if (!string.IsNullOrEmpty(currentWord))
                        {
                            resultList.Add(currentWord);
                            currentWord = string.Empty;
                        }
                        // Recursively process nested items
                        resultList.Add(ConstructList());
                        break;

                    case ')':
                        if (!string.IsNullOrEmpty(currentWord))
                        {
                            resultList.Add(currentWord);
                        }
                        return resultList;

                    case ',':
                        if (!string.IsNullOrEmpty(currentWord))
                        {
                            resultList.Add(currentWord);
                            currentWord = "";
                        }
                        break;

                    default:
                        currentWord += character;
                        break;
                }
            }

            return resultList;
        }

        return ConstructList();
    }

    public static string ConvertNestedListsToString(List<object> items, int level = 0)
    {
        var result = string.Empty;
        var indentation = new string(' ', level * 2); // Indentation for nesting

        foreach (var item in items)
        {
            if (item is List<object> nestedList)
            {
                result += ConvertNestedListsToString(nestedList, level + 1);
            }
            else
            {
                result += $"{indentation}- {item}\n";
            }
        }

        return result;
    }
}
