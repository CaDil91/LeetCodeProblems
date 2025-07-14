using System.Collections;
using InterviewPrep;
using Xunit;

namespace InterviewPrepTests;

public class AlgorithmsTests
{
    private Algorithms _subjectUnderTest;

    public AlgorithmsTests()
    {
        _subjectUnderTest= new Algorithms();
    }
    
    [Fact]
    public void GetDecimalValue_EmptyList_ReturnsZero()
    {
        // Arrange
        var head = new ListNode(0, null);

        // Act
        int result = Algorithms.GetDecimalValue(head);

        // Assert
        Assert.Equal(0, result);
    }
    
    [Fact]
    public void GetDecimalValue_WithNodes101_ReturnsNodeValue()
    {
        // Arrange
        var third = new ListNode(1, null);
        var second = new ListNode(0, third);
        var head = new ListNode(1, second);

        // Act
        int result = Algorithms.GetDecimalValue(head);

        // Assert
        Assert.Equal(5, result);
    }
    
    [Fact]
    public void TwoSum_WithNoSolution_ReturnsEmptyArray()
    {
        // Arrange
        var algorithms = new Algorithms();
        int[] nums = [2, 7, 11, 15];
        const int target = 5;

        // Act
        int[] result = Algorithms.TwoSum(nums, target);

        // Assert
        Assert.Empty(result);
    }
    
    
    [Theory]
    [MemberData(nameof(TwoSumTestData))]
    public void TwoSum_WithSolution_ReturnsIndices(int[] nums, int target, int[] expectedResult)
    {
        // Arrange

        // Act
        int[] result = Algorithms.TwoSum(nums, target);

        // Assert
        Assert.Equal(result[0], expectedResult[0]);
        Assert.Equal(result[1], expectedResult[1]);
    }
    
    [Theory]
    [ClassData(typeof(AddTwoNumbersTestDataClass))]
    public void AddTwoNumbers_WithTwoNumbers_ReturnsSum(ListNode? l1, ListNode? l2, ListNode expectedResult)
    {
        // Arrange
        // Act
        ListNode result = _subjectUnderTest.AddTwoNumbers(l1, l2);

        // Assert
        Assert.True(AreLinkedListsEqual(expectedResult, result));
    }
    
    private bool AreLinkedListsEqual(ListNode? list1, ListNode? list2)
    {
        // Both lists are null, they're equal
        if (list1 == null && list2 == null)
            return true;
    
        // One list is null but the other isn't, they're not equal
        if (list1 == null || list2 == null)
            return false;
    
        // Compare current nodes
        if (list1.Val != list2.Val)
            return false;
    
        // Recursively compare the rest of the lists
        return AreLinkedListsEqual(list1.Next, list2.Next);
    }

    
    public static TheoryData<int[], int, int[]> TwoSumTestData()
    {
        var data = new TheoryData<int[], int, int[]>
        {
            { [2, 7, 11, 15], 9, [0,1] },
            { [3, 2, 4], 6, [1,2] },
            { [3, 3], 6, [0,1] }
        };
        return data;
    }
    
    public static TheoryData<ListNode, ListNode, ListNode> AddTwoNumbersTestData()
    {
        var data = new TheoryData<ListNode, ListNode, ListNode>
        {
            {
                new ListNode(2, new ListNode(4, new ListNode(3))),
                new ListNode(5, new ListNode(6, new ListNode(4))),
                new ListNode(7, new ListNode(0, new ListNode(8)))
            },
            {
                new ListNode(0),
                new ListNode(0),
                new ListNode(0)
            },
            {
                new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))))))),
                new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))),
                new ListNode(8, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(1))))))))
            }
        };
        return data;
    }


}

public class AddTwoNumbersTestDataClass : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return
        [
            new ListNode(2, new ListNode(4, new ListNode(3))),
            new ListNode(5, new ListNode(6, new ListNode(4))),
            new ListNode(7, new ListNode(0, new ListNode(8)))
        ];
        
        yield return
        [
            new ListNode(0),
            new ListNode(0),
            new ListNode(0)
        ];
        
        yield return
        [
            new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))))))),
            new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))),
            new ListNode(8, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(1))))))))
        ];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
