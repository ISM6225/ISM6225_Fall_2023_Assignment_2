/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;

namespace ISM6225_Fall_2023_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3, 50, 75 };
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();

            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()[]{}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "69";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 3, 1, 1, 3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();
        }

        /*
        
        Question 1:
        You are given an inclusive range [lower, upper] and a sorted unique integer array nums, where all elements are within the inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums. Return the shortest sorted list of ranges that exactly covers all the missing numbers. That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
        Example 1:
        Input: nums = [0,1,3,50,75], lower = 0, upper = 99
        Output: [[2,2],[4,49],[51,74],[76,99]]  
        Explanation: The ranges are:
        [2,2]
        [4,49]
        [51,74]
        [76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */

        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            try
            {
                IList<IList<int>> result = new List<IList<int>>();
                int len = nums.Length;

                if (len == 0)
                {
                    // If there are no elements in the 'nums' array,
                    // add a single range from 'lower' to 'upper' to the 'result'.
                    result.Add(new List<int> { lower, upper });
                    return result;
                }

                if (nums[0] - lower > 0)
                    // If the first element of 'nums' is greater than 'lower',
                    // add a range from 'lower' to 'nums[0] - 1' to the 'result'.
                    result.Add(new List<int> { lower, nums[0] - 1 });

                int i;
                for (i = 1; i < len; i++)
                {
                    if (nums[i] - nums[i - 1] > 1)
                        // If there's a gap between 'nums[i-1]' and 'nums[i]',
                        // add a range from 'nums[i-1] + 1' to 'nums[i] - 1' to the 'result'.
                        result.Add(new List<int> { nums[i - 1] + 1, nums[i] - 1 });
                }

                if (upper - nums[i - 1] > 0)
                    // If there's a gap between the last element of 'nums' and 'upper',
                    // add a range from 'nums[i-1] + 1' to 'upper' to the 'result'.
                    result.Add(new List<int> { nums[i - 1] + 1, upper });

                return result;

            }
            catch (Exception)
            {
                throw;
            }

        }

        /*
         
        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
 
        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

        public static bool IsValid(string s)
        {
            try
            {
                if (s.Length <= 1)
                    return false;

                var bracketQueue = new List<int>();
                for (var i = 0; i < s.Length; i++)
                {
                    if (s[i] == '(')
                    {
                        // If an opening parenthesis is encountered, add '1' to the bracketQueue.
                        bracketQueue.Add(1);
                        continue;
                    }
                    if (s[i] == '[')
                    {
                        // If an opening square bracket is encountered, add '2' to the bracketQueue.
                        bracketQueue.Add(2);
                        continue;
                    }
                    if (s[i] == '{')
                    {
                        // If an opening curly brace is encountered, add '3' to the bracketQueue.
                        bracketQueue.Add(3);
                        continue;
                    }
                    if (bracketQueue.Count == 0)
                        // If there's no opening bracket to match the current closing bracket, return false.
                        return false;
                    if (s[i] == ')' && bracketQueue[bracketQueue.Count - 1] == 1)
                    {
                        // If a closing parenthesis matches the last opened parenthesis, remove it from bracketQueue.
                        bracketQueue.RemoveAt(bracketQueue.Count - 1);
                        continue;
                    }
                    if (s[i] == ']' && bracketQueue[bracketQueue.Count - 1] == 2)
                    {
                        // If a closing square bracket matches the last opened square bracket, remove it from bracketQueue.
                        bracketQueue.RemoveAt(bracketQueue.Count - 1);
                        continue;
                    }
                    if (s[i] == '}' && bracketQueue[bracketQueue.Count - 1] == 3)
                    {
                        // If a closing curly brace matches the last opened curly brace, remove it from bracketQueue.
                        bracketQueue.RemoveAt(bracketQueue.Count - 1);
                        continue;
                    }
                    // If none of the above conditions are met, return false.
                    return false;
                }
                // If all brackets are properly matched, the bracketQueue should be empty.
                return bracketQueue.Count == 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104

        Time complexity: O(n), space complexity:O(1)
        */

        public static int MaxProfit(int[] prices)
        {
            try
            {
                int buy = 0, sell = 0, profit = 0;

                while (sell < prices.Length)
                {
                    // Calculate the profit by finding the maximum difference between the selling price
                    // at the current index and the buying price at the 'buy' index.
                    profit = Math.Max(prices[sell] - prices[buy], profit);

                    if (prices[sell] < prices[buy])
                    {
                        // If the current selling price is lower than the buying price,
                        // update the 'buy' index to the current 'sell' index to potentially
                        // find a better buying opportunity.
                        buy = sell;
                    }
                    sell++;
                }

                return profit;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */

        public static bool IsStrobogrammatic(string s)
        {
            try
            {
                var d = new Dictionary<char, char> { { '6', '9' }, { '9', '6' }, { '8', '8' }, { '1', '1' }, { '0', '0' } };

                for (int i = 0; i <= s.Length / 2; i++)
                {
                    // Check if the character at index 'i' is in the dictionary 'd',
                    // and if its corresponding character at the opposite index is the same.
                    if (!d.ContainsKey(s[i]) || d[s[i]] != s[^(i + 1)])
                        return false;
                }

                // If all characters are valid and symmetrically matched, return true.
                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

        */

        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                Dictionary<int, int> id = new(); // Initialize a dictionary to track the count of each number.
                int ans = 0;

                for (int i = 0; i < nums.Length; i++)
                {
                    int c = id.GetValueOrDefault(nums[i], 0); // Get the count of the current number, default to 0 if not found.
                    ans += c; // Add the current count to the running sum 'ans'.
                    id[nums[i]] = c + 1; // Increment the count of the current number in the dictionary.
                }

                return ans; // Return the total count of pairs that meet the specified condition.

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2's are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(n)
        */

        public static int ThirdMax(int[] nums)
        {
            try
            {
                List<int> list = nums.Distinct().ToList(); // Remove duplicates from 'nums' and convert it to a list.
                list.Sort(); // Sort the list in ascending order.

                if (list.Count < 3)
                {
                    // If there are fewer than three unique elements, return the largest element.
                    return list[list.Count - 1];
                }

                // Otherwise, return the third-largest element in the sorted list.
                return list[list.Count - 3];

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []
 
        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static IList<string> GeneratePossibleNextMoves(string currentState)
        {
            try
            {
                var list = new List<string>(); // Initialize a list to store the transformed strings.
                var arr = currentState.ToCharArray(); // Convert the input 'currentState' into a character array.

                for (int i = 0; i < currentState.Length - 1; i++)
                {
                    // Check for consecutive '+' symbols and replace them with '-' to create a new state.
                    if (arr[i] == arr[i + 1] && arr[i] == '+')
                    {
                        arr[i] = arr[i + 1] = '-'; // Transform the characters.
                        list.Add(new string(arr)); // Add the modified state to the list.
                        arr[i] = arr[i + 1] = '+'; // Restore the original state for the next iteration.
                    }
                }

                return list; // Return the list of transformed states.

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 8:

        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: s = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: s = "aeiou"
        Output: ""

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static string RemoveVowels(string s)
        {
            var set = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u' }; // Initialize a set of vowels.
            var sb = new StringBuilder();

            foreach (var c in s)
            {
                // Iterate through each character in the string 's'.
                if (!set.Contains(c))
                {
                    // If the character is not in the set of vowels, append it to the StringBuilder.
                    sb.Append(c);
                }
            }

            return sb.ToString(); // Return the result as a string with vowels removed.

        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<string> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}
