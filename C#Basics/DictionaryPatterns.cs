using System;
using System.Collections.Generic;

public class DictionaryPatterns{
    public static void Run(){
        int[] a = [10, -10, 20, -2, 80, 0, -10, 30, 40, 50, -1, 80, 20, 70, 20, 70, 20, 20, 11, 17, -10, -19, 15, -10];

        int[] b = [10, 20, 80, 0, 30, 40, 50, 80, 20, 70, 20, 70, 20, 11, 15];

        int[] c = [3, 1, 6, 0, 2, 4, 11];

        int target = 10;
        
        Dictionary<int,int> FreqCounterDict = FreqCounter(c);
        Console.WriteLine("Printing dictionary:");
        foreach(var item in FreqCounterDict){            
            Console.WriteLine(item.Key+"--->"+item.Value);
        }

        int returnFirstRepeatedNum = ReturnFirstRepeatedNum(a);
        Console.WriteLine("returnFirstRepeatedNum:"+returnFirstRepeatedNum);


        int returnFrequentlyRepeatedNum = ReturnFrequentlyRepeatedNum(a);
        Console.WriteLine("ReturnFrequentlyRepeatedNum:"+returnFrequentlyRepeatedNum);

        //List<int> returnTwoSumIndicesArray = new List<int>();
        List<int> returnTwoSumIndicesArray = ReturnTwoSumIndicesArray(c, target);
        // required o/p but without array:
        // foreach(int i in returnTwoSumIndicesArray){
        //     Console.WriteLine(i);
        // }
        /// required o/p in array format:
        Console.WriteLine("ReturnTwoSumIndicesArray: [" + string.Join(", ", returnTwoSumIndicesArray) + "]");
    }

    //Problem: Given an integer array, count how many times each number appears.
    public static Dictionary<int,int> FreqCounter(int[] a){
        Dictionary<int,int> counts = new Dictionary<int,int>();

        foreach(var item in a){
            if(counts.ContainsKey(item)){
                counts[item]++;
                //Console.WriteLine(item);
            }
            else{
                counts[item]=1;
            }
        }
        return counts;        
    }
    //time: O(n) and space: O(n)


    //Problem: Given an integer array, return the first number that repeats as you scan from left to right. If no number repeats, return -1
    public static int ReturnFirstRepeatedNum(int[] a){
        Dictionary<int,int> counts = new Dictionary<int,int>();

        foreach(var item in a){
            if(counts.ContainsKey(item)){
                //counts[item]++;   //this line is not needed for this prob, for the first repeated num -> this loop hits and return the value            
                return item;
            }
            else{
                counts[item]=1;
            }
        }
        return -1;
    }

    //must try problem -- think and solve
    //Problem: Given an integer array, find the number that appears most frequently.
    public static int ReturnFrequentlyRepeatedNum(int[] a){
        Dictionary<int,int> counts = new Dictionary<int,int>();

        foreach(var item in a){
            if(counts.ContainsKey(item)){
                counts[item]++;                      
            }
            else{
                counts[item]=1;
            }
        }
            
        int maxFrequency =0;
        int mostFreq=-1;
        for(int i=0;i<a.Length;i++){
            if(counts[a[i]]> maxFrequency){
                maxFrequency = counts[a[i]];
                mostFreq=a[i];               
            }           
        }       
        return mostFreq;       
    }
    // time: O(n) -- two sequential loops, space: O(n) -- one dictionary



    // must must solve --- very very important
    //Problem: Two Sum: Problem: Given an integer array and a target number, return the indices of two different elements whose sum equals the target.
    public static List<int> ReturnTwoSumIndicesArray(int[] a, int target){
        Dictionary<int,int> counts = new Dictionary<int,int>();

        
        //List<int> finalArray = new List<int>();
        for(int i=0;i<a.Length; i++){
            
            int complement = target - a[i];

            if(counts.ContainsKey(complement)){
                // finalArray.Add(i);
                // finalArray.Add(counts[complement]);
                // return finalArray;  

                //below steps instead of creating another new final array List like above (.Add method works only for List not for array)
                //return new List<int> {i, counts[complement]};
                //return indices in readable order instead of above order 
                // which checks from reverse since we are checking first and then building dictionary
                return new List<int> { counts[complement], i };
                              
            } 

            counts[a[i]]=i;
            
        }
        return [];

           
    }
}