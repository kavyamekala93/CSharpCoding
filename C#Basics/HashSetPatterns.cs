
// A HashSet<int> stores unique numbers.

// HashSet<int> seen = new HashSet<int>();

// seen.Add(10);
// seen.Add(20);
// seen.Add(10); // Duplicate, not added

// Console.WriteLine(seen.Contains(10)); // True
// Console.WriteLine(seen.Contains(30)); // False

// Three important methods:
// Method	Purpose
// Add(value)	Adds a value if it doesn't exist
// Contains(value)	Checks whether a value exists
// Remove(value)	Removes a value



//note and tips: 
//give arrays have duplicate values, so we are using HashSet datatype here to avoid duplicates

// for ArrayReturnDistinctNum method return logic:
// if using Console.WriteLine inside the method to write/show o/p console, 
// return type can be void and inside main Run method, 
// just call your method (no need to assign a value to method and return that value)



using System;
using System.Linq;

public class HashSetPatterns{
    public static void Run(){

        int[] a = [10, 20, -2, 80, 0, -10, 30, 40, 50, -10, 20, 70, 20, 70, 20, -10, 11, 17, -7, -19, 15];

        int[] b = [10, 20, 80, 0, 30, 40, 50, 80, 20, 70, 20, 70, 20, 11, 15];

        //int[] b =[-1, -28];

        int arrayFirstRepeatedNum = ArrayFirstRepeatedNum(a);
        Console.WriteLine("ArrayFirstRepeatedNum:"+ arrayFirstRepeatedNum);

        Console.WriteLine("ArrayReturnDistinctNum:");
        ArrayReturnDistinctNum(a);

        // int arrayReturnDistinctNum = ArrayReturnDistinctNum(a);
        // Console.WriteLine("ArrayReturnDistinctNum:"+ arrayReturnDistinctNum);

        Console.WriteLine("ReturnCommonElementsArrayOfGivenTwoArrays");
        int[] returnCommonElementsArrayOfGivenTwoArrays = ReturnCommonElementsArrayOfGivenTwoArrays(a, b);
        foreach (var item in returnCommonElementsArrayOfGivenTwoArrays)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("returnCommonElementsArrayOfGivenTwoArrays in array format:");
        Console.WriteLine($"[{string.Join(", ", returnCommonElementsArrayOfGivenTwoArrays)}]");

        

        //Console.WriteLine("ReturnCommonElementsArrayOfGivenTwoArrays");
        int[] returnDistinctElementsArrayOfGivenTwoArrays = ReturnDistinctElementsArrayOfGivenTwoArrays(a, b);
        foreach (var item in returnDistinctElementsArrayOfGivenTwoArrays)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("ReturnDistinctElementsArrayOfGivenTwoArrays in array format:");
        Console.WriteLine($"[{string.Join(", ", returnDistinctElementsArrayOfGivenTwoArrays)}]");


        bool hasCommonElement = HasCommonElement(a,b);
        Console.WriteLine("HasCommonElement:"+ hasCommonElement);
       
        int firstUniqueNumber = FirstUniqueNumber(a);
        Console.WriteLine("FirstUniqueNumber:"+ firstUniqueNumber);



       
    }

    public static int ArrayFirstRepeatedNum(int[] a){
        HashSet<int> seen = new HashSet<int>();

        for(int i=0;i<a.Length;i++){
            if(!seen.Contains(a[i])){
                seen.Add(a[i]);
            }
            else{
               return a[i];      
            }           
        }
        return -1;
    }
    // time: O(n), space: O(n)


    //Problem: Given an integer array, return the number of distinct (unique) values.
    public static void ArrayReturnDistinctNum(int[] a){
        HashSet<int> seen = new HashSet<int>();

        for(int i=0;i<a.Length;i++){
            //if(!seen.Contains(a[i])){
                seen.Add(a[i]);
            //}          
        }
        foreach(int i in seen){
            Console.WriteLine(i);
        }
        //return -1;
    }
    // time: O(n), space: O(n)
    //no need to check .contains with if condition since Hashset automatically ignores


    //Problem: Given two integer arrays, return the distinct numbers that appear in both arrays.
    public static int[] ReturnCommonElementsArrayOfGivenTwoArrays(int[] a, int[] b){
        HashSet<int> seen1 = new HashSet<int>();

        HashSet<int> seen2 = new HashSet<int>();

        for(int i=0;i<a.Length;i++){
            seen1.Add(a[i]);       
        }
        
        for(int i=0;i<b.Length;i++){
            if(seen1.Contains(b[i]))         
            seen2.Add(b[i]);       
        }
        // foreach(int i in seen2){
        //      Console.WriteLine(i);
        // }
        return seen2.ToArray();
    }
    // time: O(n+m), space: O(n+m)


    //Problem: Given two integer arrays a and b, return the distinct elements that exist in a (which is first array) but not in b (which is 2nd array).
    public static int[] ReturnDistinctElementsArrayOfGivenTwoArrays(int[] a, int[] b){
        HashSet<int> seen1 = new HashSet<int>();

        HashSet<int> seen2 = new HashSet<int>();

        for(int i=0;i<b.Length;i++){
            seen1.Add(b[i]);       
        }
        
        for(int i=0;i<a.Length;i++){
            if(!seen1.Contains(a[i])){
                seen2.Add(a[i]);
            }               
        }
        return seen2.ToArray();
    }
    // time: O(n+m), space: O(n+m)
    // first test b elements and make one hash set, compare with each element of a array next


    //Problem: Given two integer arrays, determine whether they share at least one common number.
    public static bool HasCommonElement(int[] a, int[] b)
    {
        HashSet<int> seen1 = new HashSet<int>();

        for(int i=0;i<a.Length;i++){
            seen1.Add(a[i]);
        }

        for(int i=0;i<b.Length;i++){
            if(seen1.Contains(b[i])){
                return true;
            }
        }
        return false;
    }

    public static int FirstUniqueNumber(int[] a)
    {
        HashSet<int> seen = new HashSet<int>();

        HashSet<int> repeated = new HashSet<int>();

        for(int i=0;i<a.Length;i++){
            if(!seen.Contains(a[i])){
                seen.Add(a[i]);                
            }
            else{
                repeated.Add(a[i]);               
            }                  
        }
        for(int i=0;i<a.Length;i++){
            if(!repeated.Contains(a[i])){
                return a[i];                
            }                 
        }       
        return -1;       
    }

    //note and tip: time: O(n+n)--> O(n) but not O(n+m) which is running for loops on two separate arrays
    //space: O(2n--> O(n))
    // Two HashSets storing up to n elements each give O(2n) = O(n) space complexity.
    // But it's not because they have the same data type. It's because both HashSets grow in proportion to the same input size, n.

}