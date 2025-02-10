namespace RedRoverChallenge.Helpers;

public static class OutputHelper
{
    public static string AlphabetizeInputString(string input)
    {
        string SortStringSegment(string stringSegment)
        {
            var stringsList = new List<string>();
            var startIndex = 0;
            var parenthesisCount = 0;

            for (var i = 0; i < stringSegment.Length; i += 1)
            {
                switch (stringSegment[i])
                {
                    case '(':
                        parenthesisCount++;
                        break;

                    case ')':
                        parenthesisCount--;
                        break;

                    case ',' when parenthesisCount == 0:
                        stringsList.Add(stringSegment.Substring(startIndex, i - startIndex).Trim());
                        startIndex = i + 1;
                        break;
                }
            }

            stringsList.Add(stringSegment.Substring(startIndex).Trim());
            var sortedStrings = new List<string>();

            foreach (var item in stringsList)
            {
                if (item.Contains('('))
                {
                    var openParenIndex = item.IndexOf('(');
                    var itemBeforeParens = item.Substring(0, openParenIndex);
                    var itemsInParens = item.Substring(openParenIndex + 1, item.Length - openParenIndex - 2);
                    sortedStrings.Add($"{itemBeforeParens}({SortStringSegment(itemsInParens)})");
                }
                else
                {
                    sortedStrings.Add(item);
                }
            }

            sortedStrings.Sort(StringComparer.OrdinalIgnoreCase);
            return string.Join(", ", sortedStrings);
        }

        var innerContent = input.Trim().Substring(1, input.Length - 2);
        return $"({SortStringSegment(innerContent)})";
    }

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
