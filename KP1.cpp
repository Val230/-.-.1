// KP1.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

int min; 
int min_index;

int checkArrSize(int n)
{
    while (n > 100 || n < 1)
    {
        if (n > 100)
        {
            printf("Entered value is over the size limit of 100 of the array. Reenter size: ");
            scanf_s("%d", &n);
        }
        else if (n < 1)
        {
            printf("Entered value is under the size minimum of 1 of the array. Reenter size: ");
            scanf_s("%d", &n);
        }
    }
    return n;
}
void outputArr(int* arr, int n)
{
    for (int i = 0; i < n; i++)
    {
        printf("\narr[%d]=%d", i, arr[i]);
    }
    return;
}
void getMin(int *arr, int n)
{
    min = arr[0];
    min_index = 0;
    for (int i = 0; i < n; i++)
    {
        if (min > arr[i])
        {
            min = arr[i];
            min_index = i;
        }
    }
    return;
}
int findK(int* arr, int n, int k)
{
    for (int i = 0; i < n; i++)
    {
        if (arr[i] == k)
        {
            return i;
        }
    }
    return -1;
}
int main()
{
    int n;
    printf("Enter size of array: ");
    scanf_s("%d", &n);
    int* arr = new int[checkArrSize(n)];
    for (int i = 0; i < n; i++)
    {
        printf("Enter value for index %d: ", i);
        scanf_s("%d", &arr[i]);
    }
    getMin(arr, n);
    printf("Minimal number in array is %d with index %d.", min, min_index);
    int k;
    printf("\nEnter searched integer value: ");
    scanf_s("%d", &k);
    printf("First instance of the number %d in the array is in index %d.", k, findK(arr, n, k));
    outputArr(arr, n);
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
