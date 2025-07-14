namespace InterviewPrep;

public class Algorithms
{
    /// <summary>
    /// So `101` in binary means: (1 × 2²) + (0 × 2¹) + (1 × 2⁰)
    /// Which is also:
    ///     (1 x 2) + 1 = 1
    ///     (1 x 2) + 0 = 2
    ///     (2 * 2) + 1 = 5
    /// Where 
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public static int GetDecimalValue(ListNode? head) 
    {
        var result = 0;
        ListNode? current = head;

        while (current != null)
        {
            result = (result * 2) + current.Val;
            current = current.Next;
        }

        return result;
    }
    
    public static int[] TwoSum(int[] nums, int target)
    {
        // Dictionary to store values we've seen and their indices
        var seen = new Dictionary<int, int>();
    
        for (var i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
        
            // If we've seen the complement before, we found our pair
            if (seen.TryGetValue(complement, out int value)) return [value, i];
        
            // Add the current number and its index to the dictionary if not already present
            seen.TryAdd(nums[i], i);
        }
    
        // No solution found
        return [];
    }
    
    public ListNode AddTwoNumbers(ListNode? l1, ListNode? l2) 
    {
        // Create a dummy head node to simplify list building
        var dummyHead = new ListNode();
        ListNode? current = dummyHead;
        var carry = 0;
    
        // Process both lists until we reach the end of both
        while (l1 != null || l2 != null || carry > 0)
        {
            // Get values from current nodes (or 0 if node is null)
            int val1 = l1?.Val ?? 0;
            int val2 = l2?.Val ?? 0;
        
            // Calculate sum including carry from previous step
            int sum = val1 + val2 + carry;
        
            // Calculate new carry and the digit to add
            carry = sum / 10;
            int digit = sum % 10;
        
            // Add new node with calculated digit
            current.Next = new ListNode(digit);
            current = current.Next;
        
            // Move to next nodes in both lists if available
            l1 = l1?.Next;
            l2 = l2?.Next;
        }
    
        // Return the result list (skip the dummy head)
        return dummyHead.Next!;

    }
}



public class ListNode(int val = 0, ListNode? next = null)
{
    public int Val = val;
    public ListNode? Next = next;
}