public class LinearScan{
    

    // key words to search during revision: 
    // must solve, tip, struggled, 

    public static void Run()
    {
        int[] b = [10, 20, -2, 80, 0, -10, 30, 40, 50, 80, 20, 70, 20, 70, 20, -10, 11, 17, -7, -19, 15];

        int[] a = [10, 20, 80, 0, 30, 40, 50, 80, 20, 70, 20, 70, 20, 11, 17, 15];
        int target = 20;
        Console.WriteLine("=== Starting Linear Scan ===");
        
        int arrayIndexFinderResult = ArrayIndexFinder(a, target);
        //Console.WriteLine($"ArrayTargetFinderResult: {arrayTargetFinderResult}");

        Console.WriteLine("ArrayIndexFinderResult:"+ arrayIndexFinderResult);

        int arrayLargestNumFinder = ArrayLargestNumFinder(a);
        Console.WriteLine("ArrayLargestNumFinder:"+ arrayLargestNumFinder);        

        int arraySecondLargestNumFinder = ArraySecondLargestNumFinder(a);
        Console.WriteLine("ArraySecondLargestNumFinder:"+ arraySecondLargestNumFinder);
       
        int arrayTargetFrequency = ArrayTargetFrequency(a, target);
        Console.WriteLine("ArrayTargetFrequency:"+ arrayTargetFrequency);

        int arrayEvenNumCount = ArrayEvenNumCount(a);
        Console.WriteLine("ArrayEvenNumCount:"+ arrayEvenNumCount);

        int arrayEvenNumSum = ArrayEvenNumSum(a);
        Console.WriteLine("ArrayEvenNumSum:"+ arrayEvenNumSum);

        int arrayFirstRepeatedNum = ArrayFirstRepeatedNum(a);
        Console.WriteLine("ArrayFirstRepeatedNum:"+ arrayFirstRepeatedNum);


    }

    public static int ArrayIndexFinder(int[] a, int target)
    {
        Console.WriteLine("Running ArrayIndexFinder...");

        for(int i=0; i<a.Length;i++){
            if(a[i] == target ){
                return(i);
            }
        }       
        return -1; 
        //note and tip: without this return, if the if condition fails for all elements of array - program throws build error
    }

    //// must solve
    public static int ArrayLargestNumFinder(int[] a)
    {
        Console.WriteLine("Running ArrayLargestNumFinder...");
        int max = a[0];
        for(int i=1; i<a.Length;i++){          
            if(a[i] > max ){
                max = a[i];               
            }           
        }
        // tip: start the for loop at i=1 instead of i=0 to prevent 1 iteration   
        return max;              
    }

    //Problem: Given an integer array, return the second largest number in the array
    // must solve
    public static int ArraySecondLargestNumFinder(int[] a)
    {
        Console.WriteLine("Running ArraySecondLargestNumFinder...");
        int max = a[0];
        int secondLargest=int.MinValue;
        // int.MinValue returns minimum intezer value- used to chandle 
        for(int i=1; i<a.Length;i++){          
            if(a[i] > max ){
                secondLargest = max;
                max = a[i];           
            }
            else if(a[i]> secondLargest && a[i]< max){ 
                secondLargest= a[i];
            }
            // tip: second else if: a[i]> secondLargest condition is to check elements in the array after max is found
            // also add a[i] < max because if there are duplicates elseif loop misses and not checked         
        } 
        return secondLargest;
    }

    //Problem: Given an integer array, return freq of target in the array
    public static int ArrayTargetFrequency(int[] a, int target)
    {
        int arrayTargetFrequency=0;
        Console.WriteLine("Running ArrayTargetFrequency...");
        for(int i=0;i<a.Length;i++){
            if(a[i]==target){
                arrayTargetFrequency++;
            }
        }
        return arrayTargetFrequency;
    }

    //Problem: Given an integer array, return the number of even numbers.
    public static int ArrayEvenNumCount(int[] a)
    {
        int arrayEvenNumCount=0;
        Console.WriteLine("Running ArrayEvenNumCount...");
        for(int i=0;i<a.Length;i++){
            if(a[i]%2 == 0){
                arrayEvenNumCount++;
            }
        }
        return arrayEvenNumCount;
    }

    public static int ArrayEvenNumSum(int[] a)
    {
        int arrayEvenNumSum=0;
        Console.WriteLine("Running ArrayEvenNumSum...");
        for(int i=0;i<a.Length;i++){
            if(a[i]>0){
                if(a[i]%2 == 0){
                    arrayEvenNumSum = arrayEvenNumSum + a[i] ;
                }
            }           
        }
        return arrayEvenNumSum;
    }

    //Problem: Given an integer array, return the first number that appears more than once, 
    // based on the earliest second occurrence.
    //Input:  [10, 20, 30, 20, 10]
    //Output: 20
    // must solve
    public static int ArrayFirstRepeatedNum(int[] a)
    {
        //int arrayFirstRepeatedNum=0;
        Console.WriteLine("Running ArrayFirstRepeatedNum...");
        for(int i=0;i<a.Length;i++){
            for(int j=i-1;j>=0;j--){
                if(a[i]==a[j]){
                    // arrayFirstRepeatedNum = a[i];
                    // return arrayFirstRepeatedNum; 
                    return a[i]; 
                }                 
            }                  
        }
        return -1;
    }

    // note and tip: instead of comparing 1st element with after elements of array --- do reverse approach:
    // compare current element with previous element , the first previous match is the answer
    //also immediately return the first previous match, no need to iterate the other/rest array elements since we need 1st match

    //tip and where I struggled: nested loop j conditional which is j>=0


}